using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Payment:IEntity
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public int AmountPaid { get; set; }
        public DateTime? PaymentDate { get; set; }

    }
}
