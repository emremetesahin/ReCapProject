using Core.DataAccess.EntityFramework;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetail();

        List<RentalerDto> GetRentalers();

    }
}
