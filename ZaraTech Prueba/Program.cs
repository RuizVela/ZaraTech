using System;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace ZaraTech_Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
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
