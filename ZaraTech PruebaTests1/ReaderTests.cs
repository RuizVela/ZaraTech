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
            DateTime thursday = reader.GetLastWeekDayOfMonth(2017, 12, DayOfWeek.Thursday);
            DateTime day = new DateTime(2017, 12, 28);
            Assert.IsTrue(thursday == day);
        }
    }
}