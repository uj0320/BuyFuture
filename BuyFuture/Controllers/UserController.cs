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
using BuyFuture.Utility;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace BuyFuture.Controllers
{
    public class UserController : BaseController
    {
        protected readonly ILogger<HomeController> _logger;

        public UserController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


    }
}
