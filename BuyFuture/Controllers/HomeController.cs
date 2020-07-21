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

namespace BuyFuture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            BuyfutureContext db = new BuyfutureContext();
            var users = (from x in db.User select x).ToList();
            ViewBag.users = users;


            return View();
        }
        [HttpGet]
        public JsonResult GetPrices()
        {
            BuyfutureContext db = new BuyfutureContext();
            var stock = (from x in db.StockBasic where x.StockNum == 1101 select x).FirstOrDefault();
            DateTime dt_start = DateTime.Parse("2010-01-04");
            DateTime dt_end = DateTime.Parse("2015-01-14");
            var stock_prices = (from x in db.StockPrice where x.StockNum == stock.StockNum && x.Date >= dt_start && x.Date <= dt_end select x).ToList();

            var stock_high = (from x in stock_prices select new { x.High }).ToList();
            var stock_date = (from x in stock_prices select new { x.Date }).ToList();

            var data = new
            {
                highes = stock_high.Select(x => x.High).ToArray(),
                dates = stock_date.Select(x => x.Date).ToArray(),

            };

            return Json(data);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
