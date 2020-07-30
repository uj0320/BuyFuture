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
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using BuyFuture.Controllers.cls;

namespace BuyFuture.Controllers
{

    [Authorize(Roles = "Admin,AuthUser")]
    public class UserController : BaseController
    {
        protected readonly ILogger<HomeController> _logger;

        public UserController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult UserAdminIndex()
        {
            return View();
        }

        public IActionResult WatchStock()
        {
            var UserName = this.User.Identity.Name;
            var u = (from x in db.User
                     .Include(x => x.UserStock)
                     .Include("UserStock.StockNumNavigation")
                     where x.Name == UserName 
                     select x).FirstOrDefault();
            
            ViewBag.stocks = u.UserStock;
            return View();
        }

        public IActionResult ModelManagement()
        {
            string user_name = this.User.Identity.Name;

            var u = (from x in this.db.User
                     .Include(x => x.UserModel)
                     .Include("UserModel.Model")
                     where x.Name == user_name select x).FirstOrDefault();
            if(u == null)
            {
                // ignore
            }

            ViewBag.user_models = u.UserModel;

            return View();
        }

        public IActionResult UpdateParameters(IFormCollection fc)
        {
            int user_model_id = int.Parse(fc["user_model_id"]);
            double learning_rate = double.Parse(fc["learning_rate"]);

            var um = (from x in this.db.UserModel where x.Id == user_model_id select x).FirstOrDefault();
            string params_jstr = um.Parameters;

            dynamic jo_params = JsonConvert.DeserializeObject<dynamic>(params_jstr);
            jo_params.learning_rate = learning_rate;

            um.Parameters = JsonConvert.SerializeObject(jo_params);
            this.db.SaveChanges();


            /*
            decimal Amount = Convert.ToDecimal(myObject.Amount);
            string Message = myObject.Message;
            */


            return RedirectToAction("ModelManagement", "User");
        }

        public JsonResult GetParametersById(int um_id)
        {
            var um = (from x in this.db.UserModel where x.Id == um_id select x).FirstOrDefault();

            var jo = JsonConvert.DeserializeObject<Parameters>(um.Parameters);

            return Json(jo);
        }
    }
}
