using Core.DataAccess.EntityFramework;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IPaymentDal:IEntityRepository<Payment>
    {
        List<PaymentDetailDto> GetPaymentDetails(Expression<Func<PaymentDetailDto, bool>> filter = null);
    }
}
