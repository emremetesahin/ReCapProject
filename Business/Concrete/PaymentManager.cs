﻿using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }
        [TransactionScopeAspect]
        public IResult Add(Payment payment)
        {
            payment.PaymentDate = DateTime.Now;
                _paymentDal.Add(payment);
                return new SuccessResult(Messages.PaymentSuccessfull);
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }
    }
}
