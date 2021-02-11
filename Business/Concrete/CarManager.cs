using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
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

        public void Add(Car car)
        {
            if (car.DailyPrice>0)
            {
                _cardal.Add(car);
            }
            else
            {
                Console.WriteLine("Arabanın günlük ücreti 0dan büyük olmalıdır");
            }
        }

        public void Delete(Car car)
        {
            _cardal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _cardal.GetAll();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _cardal.GetAll(c=>c.BrandId==brandId);
        }

        public List<Car> GetByColorId(int colorId)
        {
            return _cardal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _cardal.Update(car);
        }
    }
}
