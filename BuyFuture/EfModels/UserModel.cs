﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace BuyFuture.EfModels
{
    public partial class UserModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ModelId { get; set; }

        public virtual Model Model { get; set; }
        public virtual User User { get; set; }
    }
}