using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand brand)
        {
            using (RentCarContext context=new RentCarContext())
            {
                var AddedBrand = context.Entry(brand);
                AddedBrand.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand brand)
        {
            using (RentCarContext context=new RentCarContext())
            {
                var DeletedBrand = context.Entry(brand);
                DeletedBrand.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (RentCarContext context=new RentCarContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (RentCarContext context=new RentCarContext())
            {
                return filter == null
                    ? context.Set<Brand>().ToList()
                    : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand brand)
        {
            using (RentCarContext context=new RentCarContext())
            {
                var UpdatedBrand = context.Entry(brand);
                UpdatedBrand.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
