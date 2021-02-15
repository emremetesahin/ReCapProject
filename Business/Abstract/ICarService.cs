using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

        IResult DeleteById(int Id);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByColorId(int colorId);
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetails();


    }
}
