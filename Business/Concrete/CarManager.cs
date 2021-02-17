using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
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

        public IResult Add(Car car)
        {
            if (car.DailyPrice>0)
            {
                _cardal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            return new ErrorResult(Messages.CarAddedNot);

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

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(c=>c.BrandId==brandId),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(c => c.ColorId == colorId),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByPriceRange(double min, double max)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(c => min <= c.DailyPrice&& c.DailyPrice<=max),Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetail(),Messages.CarListed);
        }

        public IResult Update(Car car)
        {
            _cardal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
