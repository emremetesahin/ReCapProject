using Core.DataAccess.EntityFramework;
using Core.Entities;
using Core.Entities.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        UserDetailDto GetDetailsByMail(string mail);
    }
}
