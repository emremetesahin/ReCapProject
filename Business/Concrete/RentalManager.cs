using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
        public RentalManager(IRentalDal rentalDal)
        {
            _rentaldal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result=BusinessRules.Run(CheckCarReturnDate(rental.CarId));
            if (result==null)
            {
                _rentaldal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
                return new ErrorResult(Messages.RentalAddedNot);

        }

        public IResult CheckCarReturnDate(int CarId)
        {
            var result = _rentaldal.GetAll(r => r.CarId == CarId&&r.ReturnDate==null).Any();
            if (result)
            {
                return new ErrorResult(Messages.RentalAddedNot);
            }
            else
            {
                return new SuccessResult(Messages.RentalAdded);
            }
            
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

        public IDataResult<Rental> GetRentalById(int id)
        {
            return new SuccessDataResult<Rental>(_rentaldal.Get(r => r.Id == id), Messages.RentalListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails() {

            return new SuccessDataResult<List<RentalDetailDto>>(_rentaldal.GetRentalDetail(),Messages.CarListed);
        }

        public IDataResult<List<RentalerDto>> GetRentalers()
        {
            return new SuccessDataResult<List<RentalerDto>>(_rentaldal.GetRentalers(), Messages.RentalListed);
        }

        [ValidationAspect(typeof(RentalValidator))]

        public IResult Update(Rental rental)
        {
            _rentaldal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
