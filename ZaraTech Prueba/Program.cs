using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaraTech_Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new Reader();
            file.StoreData();
            var investor = new Investor();
            var initialDate = new DateTime(2001, 05, 23);
            var endDate = new DateTime(2017, 12, 28);
            var day = DayOfWeek.Thursday;
            var finalNumber = investor.SellAllStocks(initialDate, endDate, day, file);
            Console.WriteLine(finalNumber);
        }
    }
}
