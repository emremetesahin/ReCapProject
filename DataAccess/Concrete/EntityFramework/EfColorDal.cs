using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public class EfColorDal :EfEntityRepositoryBase<Color,RentCarContext>,IColorDal
    {

    }
}
