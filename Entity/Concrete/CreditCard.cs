using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class CreditCard:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public string HolderName { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }

    }
}
