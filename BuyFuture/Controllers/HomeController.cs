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
    public class HomeController : BaseController
    {
        protected readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        // 登入
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginPost([Bind] User u)
        {
            var res = (from x in this.db.User 
                       .Include(x => x.UserRole)
                       .Include("UserRole.Role")
                       where x.Name == u.Name && x.Pwd == u.Pwd select x).FirstOrDefault();

            if (res == null)
            {
                return View("fail");
            }

            var userClaims = new List<Claim>();
            userClaims.Add(new Claim(ClaimTypes.Name, res.Name)); // user name
            foreach(var ur in res.UserRole)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, ur.Role.RoleName)); // role
            }

            var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

            var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [Authorize]
        public IActionResult Test()
        {
            return View();
        }

        public IActionResult Index()
        {
            //抓使用者
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
                          where x.Date > DateTime.Now.AddDays(-100)
                          orderby x.Date ascending
                          select x).ToList().Take(30);

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
        public JsonResult GetUserStockPrices(int user_id, int stock_num)
        {
            var dtNow = DateTime.Now;
            var dtPast_30 = DateTime.Now.AddDays(-200);
            var stockPrices = (from x in this.db.StockPrice 
                               where x.StockNum == stock_num && x.Date < dtNow && x.Date > dtPast_30 
                               orderby x.Date ascending
                               select x).Take(30).ToList();

            var pricesForPredict = (from x in this.db.StockPrice 
                                    where x.StockNum == stock_num && x.Date < dtNow && x.Date > dtPast_30
                                    orderby x.Date ascending
                                    select decimal.Parse(x.High)).Take(36).ToList();
            var res = Utils.PredictPrices(pricesForPredict); 

            var prices = (from x in stockPrices select x.High).ToList().ToArray();
            var predict_prices = (from x in res select x).ToList().ToArray();
            
            var dates = (from x in stockPrices select new { x.Date }).ToList();
            var data = new
            {
                prices = prices,
                predict_prices = predict_prices,
                dates = dates.Select(x => x.Date.Value.ToString("dd")).ToArray()
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
