using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using MyStockTicker.Models;
using Quandl.NET;

namespace MyStockTicker.Controllers
{
    public class SMAController : ApiController
    {
        public async Task<SMAClassModel> Get(string ticker, int days)
        {
            var client = new QuandlClient("f7wN3K9Am1haJHeVNovu");


            var hist = await client.Timeseries.GetDataAsync("WIKI", ticker, days);

            if (hist == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            List<object[]> tsdata = hist.DatasetData.Data.ToList();
            decimal closePriceTotal = 0;

            foreach (var r in tsdata)
            {
                if(hist.DatasetData.ColumnNames[4].ToString() == "Close")
                    closePriceTotal = closePriceTotal + Convert.ToDecimal(r[4].ToString());
            }

           

            var simpleMovingAverage = closePriceTotal / tsdata.ToList().Count;

            //Round to 2 decimal point
            simpleMovingAverage = decimal.Round(simpleMovingAverage, 2, MidpointRounding.AwayFromZero);

            //Create the model class and fill it
            SMAClassModel model = new SMAClassModel();
            model.Ticker = ticker;
            model.SimpleMovingAverage=simpleMovingAverage;

            return model;
        }
    }
}
