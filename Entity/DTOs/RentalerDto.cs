using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class RentalerDto:IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string CompanyName { get; set; }
        public string ColorName { get; set; }
        public string Name { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
