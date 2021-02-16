using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (RentCarContext context=new RentCarContext())
            {
                var result = from re in context.Rentals
                             join ca in context.Cars
                             on re.CarId equals ca.Id
                             join br in context.Brands
                             on ca.BrandId equals br.BrandId
                             join cu in context.Customers
                             on re.CustomerId equals cu.UserId

                             select new RentalDetailDto
                             {

                                 Id = re.Id,
                                 CarId=re.CarId,
                                 CarName=br.BrandName,
                                 CompanyName=cu.CompanyName,
                                 RentDate=re.RentDate,
                                 ReturnDate=re.ReturnDate
                              
                                 
                                 







                             };
                return result.ToList();
            }
        }
    }
}