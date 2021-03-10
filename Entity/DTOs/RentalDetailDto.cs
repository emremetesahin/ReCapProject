﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class RentalDetailDto:IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string CompanyName { get; set; } 
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
