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
    public class ReaderTests
    {
        [TestMethod()]
        public void GetLastWeekDayOfMonthTest()
        {
            var reader = new Reader();
            reader.Read();
            var privateReader = new PrivateObject(reader);
            object thursday = privateReader.Invoke("GetLastWeekDayOfMonth", 2014, 12, DayOfWeek.Thursday);
            DateTime day = new DateTime(2014, 12, 24);
            Assert.AreEqual(day, thursday);
        }

        [TestMethod()]
        public void BuySharesTest()
        {
            Reader reader = new Reader();
            reader.Read();
            var totalShares = reader.BuyShares(2017, 11, DayOfWeek.Thursday);
            var expected = 1.648m;
            Assert.AreEqual(expected, totalShares);
        }

        [TestMethod()]
        public void BuySharesTest1()
        {
            Reader reader = new Reader();
            reader.Read();
            var totalShares = reader.BuyShares(2014, 12, DayOfWeek.Thursday);
            var expected = 2.057m;
            Assert.AreEqual(expected, totalShares);
        }

        [TestMethod()]
        public void GetAllSharesTest()
        {
            Reader reader = new Reader();
            reader.Read();
            var initialDate = new DateTime(2001, 05, 23);
            var endDate = new DateTime(2017, 12, 23);
            var day = DayOfWeek.Thursday;
            var totalShares = reader.GetAllShares(initialDate, endDate, day);
            var expected = 1254.219m;
            Assert.AreEqual(expected, totalShares);
        }

        [TestMethod()]
        public void SellAllSharesTest()
        {
            Reader reader = new Reader();
            reader.Read();
            var initialDate = new DateTime(2001, 05, 23);
            var endDate = new DateTime(2017, 12, 23);
            var day = DayOfWeek.Thursday;
            var totalShares = reader.SellAllShares(initialDate, endDate, day);
            var expected = 36585.568m;
            Assert.AreEqual(expected, totalShares);
        }
    }
}