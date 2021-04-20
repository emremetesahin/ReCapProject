using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _cardal;

        public CarManager(ICarDal cardal)
        {
            _cardal = cardal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin,car.list")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //ValidationTool.Validate(new CarValidator(), car);

            _cardal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _cardal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IResult DeleteById(int Id)
        {
            Car DeleteToCar = _cardal.Get(c => c.Id == Id);
            _cardal.Delete(DeleteToCar);
            return new SuccessResult(Messages.CarDeleted);

        }
        //[PerformanceAspect(0)]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(), Messages.CarListed);
        }

      

        public IDataResult<CarDetailDto>GetByCarId(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_cardal.GetCarDetail(c => c.Id == carId)[0], Messages.CarListed);
        }

       
        public IDataResult<List<Car>> GetByPriceRange(double min, double max)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(c => min <= c.DailyPrice && c.DailyPrice <= max), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetail(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetail(c=>c.BrandName==brandName), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandNameAndColorName(string brandName, string colorName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetail(c => c.BrandName == brandName&&c.ColorName==colorName), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColordName(string colorName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetail(c => c.ColorName == colorName), Messages.CarListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _cardal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        //[TransactionScopeAspect]


    }
}
