using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Findeks:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Score { get; set; }
    }
}
