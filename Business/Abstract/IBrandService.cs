using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBrandService
    {
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
        IDataResult<List<Brand>> GetAll();
    }
}
