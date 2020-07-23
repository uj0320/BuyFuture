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
    public class HomeController : BaseController
    {
        protected readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            
            var users = (from x in db.User
                         .Include(x => x.UserStock) 
                         .ThenInclude(x => x.StockNumNavigation)
                         select x).ToList();
            ViewBag.users = users;
            

            return View();
        }
        public class OHLC {
            public string x {get; set;}
            public string[] y {get; set;}
        }
        [Route("Home/Price_30_Day/{stock_num?}")]
        public JsonResult Price_30_Day(int stock_num)
        {
            var stock = (from x in this.db.StockBasic
                      .Include(x => x.StockPrice)
                         where x.StockNum == stock_num
                         select x).FirstOrDefault();

            List<OHLC> ohlc_list = new List<OHLC>();
            var prices = (from x in stock.StockPrice
                          where x.Date > DateTime.Now.AddDays(-30)
                          orderby x.Date ascending
                          select x).ToList();

            foreach (var p in prices) 
            {
                var o = new OHLC
                {
                    x = p.Date.Value.ToString("yyyy-MM-dd"),
                    y = new string[] { 
                        p.Open,
                        p.High,
                        p.Low,
                        p.Close
                    } 
                };
                ohlc_list.Add(o);
            }

            return Json(ohlc_list);
        }
        [Route("Home/StockDetails/{stock_num?}")]
        public IActionResult StockDetails(int stock_num)
        {
            var stock = (from x in this.db.StockBasic 
                      .Include(x => x.TodayPrice)
                      where x.StockNum == stock_num
                       select x).FirstOrDefault();

            ViewBag.stock = stock;
            return View();
        }
        [Route("Home/NowPrice/{stock_num?}")]
        public IActionResult NowPrice(int stock_num)
        {
            var stock = (from x in this.db.StockBasic
                      .Include(x => x.TodayPrice)
                         where x.StockNum == stock_num
                         select x).FirstOrDefault();

            var now_price = (from x in stock.TodayPrice orderby x.Time
                       descending select x).FirstOrDefault();
            
            if (now_price == null) {
                return Content("fail");
            }

            return Content(now_price.Price.ToString()) ;
        }
        [HttpGet]
        public JsonResult GetPrices()
        {
            
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
