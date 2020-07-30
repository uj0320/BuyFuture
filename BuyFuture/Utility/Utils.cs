using BuyFuture.Controllers.cls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BuyFuture.Utility
{
    public class Utils
    {
        public static decimal Predict1(decimal p1, decimal p2, 
            decimal p3, decimal p4, decimal p5, decimal p6) 
        {
            var avg = (p1 + p2 + p3 + p4 + p5 + p6) / 6;
            Random ran = new Random(DateTime.Now.Millisecond);
            decimal p = (decimal)ran.Next(-10, 10);

            return avg + p;
        }
        public static decimal[] PredictPrices(List<decimal> prices)
        {
            List<decimal> li = new List<decimal>();

            var prices_36 = prices.ToArray();
            for(int i = 0; i < 30; i++)
            {
                decimal p1 = prices_36[i];
                decimal p2 = prices_36[i + 1];
                decimal p3 = prices_36[i + 2];
                decimal p4 = prices_36[i + 3];
                decimal p5 = prices_36[i + 4];
                decimal p6 = prices_36[i + 5];

                var p = Utils.Predict1(p1, p2, p3, p4, p5, p6);
                li.Add(p);
            }
            return li.ToArray();
        }

        public static Parameters JstrToParametersObj(string jstr)
        {
            return JsonConvert.DeserializeObject<Parameters>(jstr);
        }
    }
}
