﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace BuyFuture.EfModels
{
    public partial class User
    {
        public User()
        {
            UserStock = new HashSet<UserStock>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }

        public virtual ICollection<UserStock> UserStock { get; set; }
    }
}