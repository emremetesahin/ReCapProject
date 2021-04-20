using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCarDal;

        public CreditCardManager(ICreditCardDal creditCarDal)
        {
            _creditCarDal = creditCarDal;
        }
        public IResult Add(CreditCard creditCard)
        {
           
            _creditCarDal.Add(creditCard);
            return new SuccessResult(Messages.CreditCardAdded);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCarDal.Delete(creditCard);
            return new SuccessResult(Messages.CreditCardDeleted);
        }

        public IDataResult<List<CreditCard>> GetByUserId(int userId)
        {
          return new SuccessDataResult<List<CreditCard>>(_creditCarDal.GetAll(u=>u.UserId==userId),Messages.CreditCardsListed);
        }
    }
}
