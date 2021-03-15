using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
           var result=BusinessRules.Run(CheckBrandNameExists(brand.BrandName));
            if (result!=null)
            {
                return new ErrorResult(Messages.BrandAddedNot);
            }
                _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);

        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);

        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);

        }
        [TransactionScopeAspect]
        public IResult TransactionTest(Brand brand)
        {
            _brandDal.Add(brand);
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        //BusinessRules
        public IResult CheckBrandNameExists(string brandName)
        {
            var result = _brandDal.Get(b => b.BrandName == brandName);
            if (result==null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
