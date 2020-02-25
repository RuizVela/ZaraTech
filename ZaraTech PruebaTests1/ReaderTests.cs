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
            Reader reader = new Reader();
            string thursday = reader.GetLastWeekDayOfMonth(2017, 11, DayOfWeek.Thursday);
            string day = "30-nov-2017";
            Assert.IsTrue(thursday == day);
        }
    }
}