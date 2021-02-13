﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string UserName { get; set; }
        public string CustomerName { get; set; }
        public string BrandName { get; set; }
        public long ModelYear { get; set; }
        public string ColorName { get; set; }
        public int DailyPrice { get; set; }
        public DateTime RentDate { get; set; }
        //Datetime'ın boş olabilme durumuna karşı sonuna ? ekliyoruz.
        public DateTime? ReturnDate { get; set; }
    }
}
