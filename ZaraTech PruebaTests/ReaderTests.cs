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
        public void ReadDatesTest()
        {
            Reader reader = new Reader();
            string line = reader.ReadDates();
            Assert.IsTrue(line == "28-dic-2017");
        }
    }
}