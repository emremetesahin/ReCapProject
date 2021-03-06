﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class CarDetailDto:IDto
    {
        public  int Id { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int DailyPrice { get; set; }
        public int ModelYear { get; set; }
        public string Description { get; set; }
        public int MinFindeksScore { get; set; }
    }
}
