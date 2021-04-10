using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using Business.Constants;
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
            //AddRentalTest();
            //GetAllRentalTest();
            //GetRentalDetailTest();
            //GetAllCustomerTest();

        }

        private static void GetAllCustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var item in customerManager.GetAll().Data)
            {
                Console.WriteLine(item.UserId + " " + item.CompanyName);
            }
        }

        private static void GetRentalDetailTest()
        {
            var result = new RentalManager(new EfRentalDal());
            foreach (var car in result.GetRentalDetails().Data)
            {
                Console.WriteLine(car.Id + "     " + car.CarId + "    " + car.CarName + "     " + car.CompanyName + "    " + car.RentDate+"   " + car.ReturnDate);
            }
        }

        private static void AddRentalTest()
        {
            var result = new RentalManager(new EfRentalDal());
            var result2=result.Add(new Rental { CarId = 2, CustomerId = 4, Id = 4, RentDate = new DateTime(2021, 02, 16)});
            Console.WriteLine(result2.Message);
        }

        private static void GetAllRentalTest()
        {
            var result = new RentalManager(new EfRentalDal());
            Console.WriteLine("No       Car ID      CustomerId     RentDate                  ReturnDate");
            foreach (var rental in result.GetAll().Data)
            {
                Console.WriteLine(rental.Id + "          " + rental.CarId + "         " + rental.CustomerId + "          " + rental.RentDate+ "      " + rental.ReturnDate);
            }
            Console.WriteLine(result.GetAll().Message);
        }

        private static void GetCarDetailsTest()
        {
            var result= new CarManager(new EfCarDal());

            foreach (var car in result.GetCarDetails().Data)
            {
                Console.WriteLine(car.Id + " " + car.ColorName + " " + car.BrandName);
            }
            Console.WriteLine();
        }

        private static void UpdateCarTest()
        {
            var result = new CarManager(new EfCarDal());
            result.Update(new Car { Id = 1, BrandId = 3, ColorId = 2, Description = "Hasarlı araç" });
        }

        private static void GetAllColorTest()
        {
            var result = new ColorManager(new EfColorDal());
            foreach (var color in result.GetAll().Data)
            {
                Console.WriteLine(color.ColorId+" "+color.ColorName);
            }
            Console.WriteLine(result.GetAll().Message);
        }

        private static void AddColorTest(int colorId,string colorName)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId = colorId, ColorName = colorName });
        }

        private static void GetAllBrandTest()
        {
            var result = new BrandManager(new EfBrandDal());
            foreach (var brand in result.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
            Console.WriteLine(result.GetAll().Message);
        }

        private static void AddBrandTest(int brandId,string brandName)
        {
           var result= new BrandManager(new EfBrandDal());
            result.Add(new Brand { BrandId =brandId,BrandName = brandName });

        }

        private static void GetByBrandIdTest(int brandId)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetByBrandId( brandId).Data)
            {
                Console.WriteLine(car.Id + " " + car.BrandId);
            }
        }

        private static void GetAllCarTest()
        {
            var result = new CarManager(new EfCarDal());
            foreach (var car in result.GetAll().Data)
            {
                Console.WriteLine("{0} {1} {2}", car.Id, car.BrandId, car.Description);
            }
            Console.WriteLine(result.GetAll().Message);
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