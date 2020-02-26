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
    public class InvestorTests
    {
        [TestMethod()]
        public void GetLastWeekDayOfMonthTest()
        {
            var file = new Reader();
            file.StoreData();
            var investor = new Investor();
            var privateReader = new PrivateObject(investor);
            object thursday = privateReader.Invoke("GetLastWeekDayOfMonth", 2014, 12, DayOfWeek.Thursday, file);
            DateTime day = new DateTime(2014, 12, 24);
            Assert.AreEqual(day, thursday);
        }

        [TestMethod()]
        public void BuyStocksTest()
        {
            var file = new Reader();
            file.StoreData();
            var investor = new Investor();
            var privateReader = new PrivateObject(investor);
            privateReader.Invoke("BuyStocks", 2017, 11, DayOfWeek.Thursday, file);
            var totalStocks = investor.GetTotalStocks();
            var expected = 1.648m;
            Assert.AreEqual(expected, totalStocks);
        }

        [TestMethod()]
        public void BuyStocksTest1()
        {
            var file = new Reader();
            file.StoreData();
            var investor = new Investor();
            var privateReader = new PrivateObject(investor);
            privateReader.Invoke("BuyStocks", 2014, 12, DayOfWeek.Thursday, file);
            var totalStocks = investor.GetTotalStocks();
            var expected = 2.057m;
            Assert.AreEqual(expected, totalStocks);
        }

        [TestMethod()]
        public void GetAllStocksTest()
        {
            var file = new Reader();
            file.StoreData();
            var investor = new Investor();
            var initialDate = new DateTime(2001, 05, 23);
            var endDate = new DateTime(2017, 12, 23);
            var day = DayOfWeek.Thursday;
            var privateReader = new PrivateObject(investor);
            var totalStocks = privateReader.Invoke("GetAllStocks", initialDate, endDate, day, file);
            var expected = 1254.219m;
            Assert.AreEqual(expected, totalStocks);
        }

        [TestMethod()]
        public void SellAllStocksTest()
        {
            var file = new Reader();
            file.StoreData();
            var investor = new Investor();
            var initialDate = new DateTime(2001, 05, 23);
            var endDate = new DateTime(2017, 12, 28);
            var day = DayOfWeek.Thursday;
            var totalStocks = investor.SellAllStocks(initialDate, endDate, day, file);
            var expected = 36585.568m;
            Assert.AreEqual(expected, totalStocks);
        }

    }
}