using Microsoft.VisualStudio.TestTools.UnitTesting;

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