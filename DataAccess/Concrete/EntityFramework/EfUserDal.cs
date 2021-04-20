using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Entities;
using Entity.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentCarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context=new RentCarContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim{ Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();
            }


        }

        public UserDetailDto GetDetailsByMail(string email)
        {
            using (var context=new RentCarContext())
            {
                var result = from us in context.Users
                             join cu in context.Customers
                             on us.Id equals cu.UserId
                             where us.Email==email
                             select new UserDetailDto
                             {
                                 UserId = us.Id,
                                 CompanyName = cu.CompanyName,
                                 CustomerId = cu.UserId,
                                 Email = us.Email,
                                 Name = us.FirstName + " " + us.LastName
                             };
                return result.FirstOrDefault();
                

            }

        }

       
    }
}
