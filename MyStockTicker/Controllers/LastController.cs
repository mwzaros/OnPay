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
    //Controller to get last stock data
    public class LastController : ApiController
    {
        //create asynchronous Get method
        public async Task<List<StockPriceModel>> Get(string ticker)
        {
            var client = new QuandlClient("f7wN3K9Am1haJHeVNovu");


            var hist = await client.Timeseries.GetDataAsync("WIKI",ticker,1);

            if (hist == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //Stock Data Model
            List<StockPriceModel> models = new List<StockPriceModel>();
            var r = hist.DatasetData.Data.First();

            models.Add(new StockPriceModel
            {
                Ticker = ticker,
                Date = hist.DatasetData.ColumnNames[0].ToString()== "Date" ? r[0].ToString() : "",
                Open = hist.DatasetData.ColumnNames[1].ToString() == "Open" ? Convert.ToDecimal(r[1].ToString()) : 0,
                High = hist.DatasetData.ColumnNames[2].ToString() == "High" ? Convert.ToDecimal(r[2].ToString()) : 0,
                Low = hist.DatasetData.ColumnNames[3].ToString() == "Low" ? Convert.ToDecimal(r[3].ToString()) : 0,
                Close = hist.DatasetData.ColumnNames[4].ToString() == "Close" ? Convert.ToDecimal(r[4].ToString()) : 0,
                Volume = hist.DatasetData.ColumnNames[5].ToString() == "Volume" ? Convert.ToDecimal(r[5].ToString()) : 0,
                ExDividend = hist.DatasetData.ColumnNames[6].ToString() == "Ex-Dividend" ? Convert.ToDecimal(r[6].ToString()) : 0,
                SplitRatio = hist.DatasetData.ColumnNames[7].ToString() == "Split Ratio" ? Convert.ToDecimal(r[7].ToString()) : 0,
                AdjOpen = hist.DatasetData.ColumnNames[8].ToString() == "Adj. Open" ? Convert.ToDecimal(r[8].ToString()) : 0,
                AdjHigh = hist.DatasetData.ColumnNames[9].ToString() == "Adj. High" ? Convert.ToDecimal(r[9].ToString()) : 0,
                AdjLow = hist.DatasetData.ColumnNames[10].ToString() == "Adj. Low" ? Convert.ToDecimal(r[10].ToString()) : 0,
                AdjClose = hist.DatasetData.ColumnNames[11].ToString() == "Adj. Close" ? Convert.ToDecimal(r[11].ToString()) : 0,
                AdjVolume = hist.DatasetData.ColumnNames[12].ToString() == "Adj. Volume" ? Convert.ToDecimal(r[12].ToString()) : 0
            });

            return models;
        }
        public async Task<List<StockPriceModel>> Get(string ticker, int days)
        {
            var client = new QuandlClient("f7wN3K9Am1haJHeVNovu");


            var hist = await client.Timeseries.GetDataAsync("WIKI", ticker, days);

            List<StockPriceModel> models = new List<StockPriceModel>();

            List<object[]> tsdata = hist.DatasetData.Data.ToList();
            foreach (var r in tsdata)
            {
                models.Add(new StockPriceModel
                {
                    Ticker = ticker,
                    Date = hist.DatasetData.ColumnNames[0].ToString() == "Date" ? r[0].ToString() : "",
                    Open = hist.DatasetData.ColumnNames[1].ToString() == "Open" ? Convert.ToDecimal(r[1].ToString()) : 0,
                    High = hist.DatasetData.ColumnNames[2].ToString() == "High" ? Convert.ToDecimal(r[2].ToString()) : 0,
                    Low = hist.DatasetData.ColumnNames[3].ToString() == "Low" ? Convert.ToDecimal(r[3].ToString()) : 0,
                    Close = hist.DatasetData.ColumnNames[4].ToString() == "Close" ? Convert.ToDecimal(r[4].ToString()) : 0,
                    Volume = hist.DatasetData.ColumnNames[5].ToString() == "Volume" ? Convert.ToDecimal(r[5].ToString()) : 0,
                    ExDividend = hist.DatasetData.ColumnNames[6].ToString() == "Ex-Dividend" ? Convert.ToDecimal(r[6].ToString()) : 0,
                    SplitRatio = hist.DatasetData.ColumnNames[7].ToString() == "Split Ratio" ? Convert.ToDecimal(r[7].ToString()) : 0,
                    AdjOpen = hist.DatasetData.ColumnNames[8].ToString() == "Adj. Open" ? Convert.ToDecimal(r[8].ToString()) : 0,
                    AdjHigh = hist.DatasetData.ColumnNames[9].ToString() == "Adj. High" ? Convert.ToDecimal(r[9].ToString()) : 0,
                    AdjLow = hist.DatasetData.ColumnNames[10].ToString() == "Adj. Low" ? Convert.ToDecimal(r[10].ToString()) : 0,
                    AdjClose = hist.DatasetData.ColumnNames[11].ToString() == "Adj. Close" ? Convert.ToDecimal(r[11].ToString()) : 0,
                    AdjVolume = hist.DatasetData.ColumnNames[12].ToString() == "Adj. Volume" ? Convert.ToDecimal(r[12].ToString()) : 0
                });
            }
            return models;
        }
    }
}
