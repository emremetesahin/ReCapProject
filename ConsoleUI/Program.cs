using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarDeleteByIdTest(1);
            //AddCarTest(4,2,3,290,2021,"Sıkıntısız Araç");
            //GetAllCarTest();
            //GetByBrandIdTest(2);
            //AddBrandTest(4, "Honda");
            //GetAllBrandTest();
            //AddColorTest(3, "Bej");
            //GetAllColorTest();
            //UpdateCarTest();
            //GetCarDetailsTest();

        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Id + " " + car.ColorName + " " + car.BrandName);
            }
        }

        private static void UpdateCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { Id = 1, BrandId = 3, ColorId = 2, Description = "Hasarlı araç" });
        }

        private static void GetAllColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId+" "+color.ColorName);
            }
        }

        private static void AddColorTest(int colorId,string colorName)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId = colorId, ColorName = colorName });
        }

        private static void GetAllBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
        }

        private static BrandManager AddBrandTest(int brandId,string brandName)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId =brandId,BrandName = brandName });
            return brandManager;
        }

        private static void GetByBrandIdTest(int brandId)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetByBrandId( brandId))
            {
                Console.WriteLine(car.Id + " " + car.BrandId);
            }
        }

        private static void GetAllCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2}", car.Id, car.BrandId, car.Description);
            }
        }

        private static void AddCarTest(int id,int bid,int cid,int dp,int my,string des)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { Id = id, BrandId = bid, ColorId = cid, DailyPrice = dp, ModelYear = my, Description = des});
        }

        private static void CarDeleteByIdTest(int id)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.DeleteById(id);
        }
    }
}