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
            //İş sınıflarının tanımlanması
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //Veritabanına eklenecek Araba,Marka,Renk  değerlerinin oluşturulması
;            List<Car> cars = new List<Car> {
             new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 100, ModelYear =2018,  Description = "Masrafsız Araç" },
             new Car { Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 300, ModelYear = 2020, Description = "Sahibinden Araç" },
             new Car { Id = 3, BrandId = 3, ColorId = 3, DailyPrice = 200, ModelYear = 2015, Description = "Temis Araç" },
             new Car { Id = 4, BrandId = 1, ColorId = 1, DailyPrice = 150, ModelYear = 2019, Description = "Cimri Araç" },
             new Car { Id = 5, BrandId = 2, ColorId = 2, DailyPrice = 250, ModelYear = 2021, Description = "Yeni Araç" },
             new Car { Id = 6, BrandId = 2, ColorId = 2, DailyPrice = 100, ModelYear = 2000, Description = "Hasar kayıtsız",  }
        };
            Car car1 = new Car { Id = 6, BrandId = 2, ColorId = 2, DailyPrice = 100, Description = "Hasar kayıtlı", ModelYear = 2000 };
            Car car2 = new Car { Id = 7, BrandId = 5, ColorId = 5, DailyPrice = 50, Description = "Ruhsatsız Araç ", ModelYear = 1995 };
            //carManager.Add(car1); Tek bir satırı update edebilmek için tek kayıt ekliyoruz
            List<Brand> brands = new List<Brand> {
            new Brand{BrandId=1,BrandName="Toyata"},
            new Brand{BrandId=2,BrandName="Honda"},
            new Brand{BrandId=3,BrandName="Tofaş"},
            new Brand{BrandId=4,BrandName="Mercedes"}, 
            };
            Brand brand1 = new Brand { BrandId = 3, BrandName = "Tofaşk" };
            List<Color> colors = new List<Color>
            {
                new Color{ColorId=1,ColorName="Siyah"},
                new Color{ColorId=2,ColorName="Mavi"},
                new Color{ColorId=3,ColorName="White"},
            };
            Color color1 = new Color { ColorId = 3, ColorName = "Beyaz" }; //İsmi yanlış girilen rengi değiştirmek için veritabanından güncelleyeceğimiz yeni bir renk oluşturuyoruz(Aynı primary key ile)

            //Oluşturulan değerlerin Veritabanlarına teker teker eklenmesi
            foreach (var brand in brands)
            {
                //brandManager.Add(brand);
            }
            foreach (var car in cars)
            {
               // carManager.Add(car);
            }
            //carManager.Add(car2); Sonradan silmek için tek kayıt ekliyoruz

            foreach (var color in colors)
            {
                //colorManager.Add(color);
            }

            //Veritabanındaki bilgilerin görüntülenmesi-Update ve Delete komutlarının test edilmesi
            //carManager.Update(car1);
            //carManager.Delete(car2);

            //colorManager.Update(color1);
            //colorManager.Delete(color1);

            //brandManager.Update(brand1);
            //brandManager.Delete(brand1);
            Console.WriteLine("Araç Id   Marka Id   Renk Id   Günlük Ücreti Üretim Yılı     Açıklama  ");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "          " + car.BrandId + "           " + car.ColorId + "            " + car.DailyPrice + "       " + car.ModelYear + "         " + car.Description);
            }
            Console.WriteLine("Renk Id  Renk Adı");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId+"         "+color.ColorName);
            }

            Console.WriteLine("Marka Id  Marka Adı");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + "         " + brand.BrandName);
            }
            Console.WriteLine("-------------Marka numarasına göre araçları gösterme------");
            Console.WriteLine("Araç Id   Marka Id   Renk Id   Günlük Ücreti Üretim Yılı     Açıklama  ");
            foreach (var car in carManager.GetByBrandId(2))
            {
                Console.WriteLine(car.Id + "          " + car.BrandId + "           " + car.ColorId + "            " + car.DailyPrice + "       " + car.ModelYear + "         " + car.Description);

            }
            Console.WriteLine("-------------Renk numarasına göre araçları gösterme------");
            Console.WriteLine("Araç Id   Marka Id   Renk Id   Günlük Ücreti Üretim Yılı     Açıklama  ");
            foreach (var car in carManager.GetByColorId(1))
            {
                Console.WriteLine(car.Id + "          " + car.BrandId + "           " + car.ColorId + "            " + car.DailyPrice + "       " + car.ModelYear + "         " + car.Description);

            }

        }
    }
}