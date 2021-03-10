using Core.Entities;
using Core.Entities.Concrete;
using Core.Utilities.Helpers.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.Security
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
