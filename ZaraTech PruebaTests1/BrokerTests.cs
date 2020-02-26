using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZaraTech_Prueba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaraTech_Prueba.Tests
{
    [TestClass()]
    public class BrokerTests
    {
        [TestMethod()]
        public void BuyStocksTest()
        {
            var broker = new Broker();
            var stocks = broker.BuyStocks(1);
            var expected = 49;
            Assert.AreEqual(expected, stocks);
        }
    }
}