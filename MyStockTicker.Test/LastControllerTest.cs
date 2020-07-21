using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStockTicker.Controllers;
using MyStockTicker.Models;
using System.Web.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyStockTicker.Test
{
    [TestClass]
    public class LastControllerTest
    {
        [TestMethod]
        public async Task<List<StockPriceModel>> GetTicker()
        {
            // Arrange
            LastController controller = new LastController(); // <1>

            // Act
            var result = await controller.Get("AAPL");

            // Assert // <3>
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
           

            return result;
        }

        public async Task<List<StockPriceModel>> GetTickerDays()
        {
            // Arrange
            LastController controller = new LastController(); // <1>

            // Act
            var result = await controller.Get("AAPL",10);

            // Assert // <3>
            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Count);


            return result;
        }

        
    }
}
