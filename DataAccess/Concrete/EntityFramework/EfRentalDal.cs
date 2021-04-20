using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
       
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (var context = new RentCarContext())
            {
                var result = from re in context.Rentals
                             join ca in context.Cars
                             on re.CarId equals ca.Id

                             join br in context.Brands
                             on ca.BrandId equals br.BrandId


                             
                             join cu in context.Customers
                             on re.CustomerId equals cu.UserId
                             
                             join us in context.Users
                             on cu.UserId equals us.Id 

                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             
                             select new RentalDetailDto
                             {
                                 Id = re.Id,
                                 BrandName = br.BrandName,
                                 CompanyName=cu.CompanyName,
                                 ColorName=co.ColorName,
                                 Name=us.FirstName+" "+us.LastName,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate

                             };
                return result.ToList();

            }
        }
    }
}