using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPaymentDal : EfEntityRepositoryBase<Payment, RentCarContext>, IPaymentDal
    {
        public List<PaymentDetailDto> GetPaymentDetails(Expression<Func<PaymentDetailDto, bool>> filter = null)
        {/*
            using (var context=new RentCarContext())
            {
                var result = from p in context.Payments

                             join c in context.CreditCards
                             on p.CardId equals c.Id

                             join r in context.Rentals
                             on p.RentalId equals r.Id
                             select new PaymentDetailDto
                             {
                                 Id = p.Id,
                                 RentalId = p.RentalId,
                                 UserId = c.UserId,
                                 CardId=c.Id,
                                 CardNumberNumber = c.CardNumber,
                                 HolderName = c.HolderName,
                                 CVV = c.CVV,
                                 ExpirationDate = c.ExpirationDate,
                                 AmountPaid = p.AmountPaid,
                                 PaymentDate=p.PaymentDate

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();*/
            throw new Exception();

        }
        
        }
    }
