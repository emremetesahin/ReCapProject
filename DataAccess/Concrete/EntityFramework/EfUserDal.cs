using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Entities;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentCarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context=new RentCarContext())
            {
                var result = from userOperationClaim in context.UserOperationClaims
                             join operationClaim in context.OperationClaims
                             on userOperationClaim.OperationClaimId equals operationClaim.Id
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id,Name=operationClaim.Name };
                return result.ToList();

            }

        }
    }
}
