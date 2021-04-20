using Core.Entities;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<UserDetailDto> GetDetailsByMail(string email);
         List<OperationClaim>GetClaims(User user);
        User GetByMail(string email);
    }
}
