using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyFuture.EfModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuyFuture.Controllers
{
    public class StockController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchStock(IFormCollection fc)
        {
            string keyword = fc["keyword"];
            keyword = keyword.Trim();

            // 分解股票代碼
            int stock_num;
            bool isSucc = int.TryParse(keyword, out stock_num);
            

            List<StockBasic> stocks;
            if(isSucc)
            {
                stocks = (from x in this.db.StockBasic where x.StockNum == stock_num select x).ToList();
            }
            else
            {
                stocks = (from x in this.db.StockBasic where keyword != "" && x.StockName.Contains(keyword) select x).ToList();
            }
            

            ViewBag.stocks = stocks;
            return View();
        }

        [Route("Stock/StockDetails/{stock_num?}")]
        public IActionResult StockDetails(int stock_num)
        {
            var stock = (from x in this.db.StockBasic
                      .Include(x => x.TodayPrice)
                         where x.StockNum == stock_num
                         select x).FirstOrDefault();

            if(!stock.QueryCount.HasValue)
            {
                stock.QueryCount = 0;
            }

            stock.QueryCount += 1;
            this.db.SaveChanges();

            ViewBag.stock = stock;
            return View();
        }

        public IActionResult HotSearch()
        {
            var stocks = (from x in this.db.StockBasic 
                       where x.QueryCount > 0 
                       orderby x.QueryCount descending 
                       select x).ToList();

            ViewBag.stocks = stocks;

            return View();
        }

    }
}
