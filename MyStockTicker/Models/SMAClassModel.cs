using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyStockTicker.Models
{
    public class SMAClassModel
    {
        public string Ticker { get; set; }
        public decimal SimpleMovingAverage { get; set; }
    }
}