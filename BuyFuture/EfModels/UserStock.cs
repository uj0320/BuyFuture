﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace BuyFuture.EfModels
{
    public partial class UserStock
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? StockNum { get; set; }

        public virtual StockBasic StockNumNavigation { get; set; }
        public virtual User User { get; set; }
    }
}