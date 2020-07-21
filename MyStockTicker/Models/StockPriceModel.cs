using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyStockTicker.Models
{
    //Stock data model
    public class StockPriceModel
    {
        public string Ticker { get; set; }
        public string Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal AdjustedClose { get; set; }
        public decimal Volume { get; set; }
        public decimal ExDividend { get; set; }
        public decimal SplitRatio { get; set; }
        public decimal AdjOpen { get; set; }
        public decimal AdjHigh { get; set; }
        public decimal AdjLow { get; set; }
        public decimal AdjClose { get; set; }
        public decimal AdjVolume { get; set; }
    }
}
