using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class PaymentDetailDto : IDto
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public string CardNumber { get; set; }
        public string HolderName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string CVV { get; set; }
        public int AmountPaid { get; set; }
    }
}
