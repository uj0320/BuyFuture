using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BuyFuture.Models;
using BuyFuture.EfModels;
using System.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BuyFuture.Controllers
{
    public class BaseController : Controller
    {
        
        protected BuyfutureContext db = new BuyfutureContext();

    }
}
