using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentaldal;
        ICarService _carService;
        IFindeksService _findeksService;
        public RentalManager(IRentalDal rentalDal,IFindeksService findeksService ,ICarService carService)
        {
            _rentaldal = rentalDal;
            _carService = carService;
            _findeksService = findeksService;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result=BusinessRules.Run(CheckCarReturnDate(rental.CarId),CheckFindeksScoreEnough(rental));
            if (result==null)
            {
                _rentaldal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
                return new ErrorResult(Messages.RentalAddedNot);

        }
        public IResult Delete(Rental rental)
        {
            _rentaldal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll(),Messages.RentalListed);
        }

    


        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentaldal.GetRentalDetails(), Messages.RentalListed);
        }

        [ValidationAspect(typeof(RentalValidator))]

        public IResult Update(Rental rental)
        {
            _rentaldal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }


        public IResult CheckCarReturnDate(int CarId)
        {
            var result = _rentaldal.GetAll(r => r.CarId == CarId && r.ReturnDate == null).Any();
            if (result)
            {
                return new ErrorResult(Messages.RentalAddedNot);
            }
            else
            {
                return new SuccessResult(Messages.RentalAdded);
            }

        }
        public IResult CheckFindeksScoreEnough(Rental rental)
        {
            var customerFindeksScore=_findeksService.GetByCustomerId(rental.CustomerId).Data.Score;
            var carFindeksScore = _carService.GetByCarId(rental.CarId).Data.MinFindeksScore;
            if(customerFindeksScore>=carFindeksScore)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Messages.FindeksScoreNotEnough);
            }
        }

        public IDataResult<Rental> GetRentalId(int carId, int customerId, DateTime rentDate, DateTime? returnDate)
        {
            var result=_rentaldal.Get(r => r.CarId == carId & r.CustomerId == customerId & r.RentDate == rentDate & r.ReturnDate == returnDate);
            return new SuccessDataResult<Rental>(result);
        }
    }
}
