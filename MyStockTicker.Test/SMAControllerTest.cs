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
    public class SMAControllerTest
    {
        [TestMethod]
        public async Task<SMAClassModel> GetSMA()
        {
            // Arrange
            SMAController controller = new SMAController(); // <1>

            // Act
            var result = await controller.Get("AAPL", 3);

            // Assert // <3>
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(SMAClassModel));


            return result;
        }
    }
}
