using System;
using System.Collections.Generic;
using log4net;

namespace ZaraTech_Prueba
{
    public class Investor
    {
        private static readonly ILog log = LogManager.GetLogger
(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        decimal totalStocks;

        private DateTime GetLastWeekDayOfMonth(int year, int month, DayOfWeek day, Reader file)
        {
            var monthDays = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            monthDays = Convert.ToDateTime(monthDays, file.GetProvider());
            while (monthDays.DayOfWeek != day)
            {
                monthDays = monthDays.AddDays(-1);
            }
            while (!file.GetDates().Contains(monthDays))
            {
                monthDays = monthDays.AddDays(-1);
            }
            return monthDays;
        }
        private void BuyStocks(int year, int month, DayOfWeek day, Reader file)
        {
            var buyingDay = GetLastWeekDayOfMonth(year, month, day, file);
            var position = file.GetDates().IndexOf(buyingDay) - 1;
            if (position == -1)
            {
                return;
            }
            decimal stocks = BuyPartialStock(position, file);
            totalStocks += stocks;
            log.Info("Fecha de compra: " + buyingDay);
            log.Info("Acciones compradas: " +stocks);
            log.Info("Acciones totales hasta la fecha: " + totalStocks);
            //TODO: guardar dato en log.
        }

        private decimal BuyPartialStock(int position, Reader file)
        {
            List<decimal> openings = file.GetOpeningValues();
            decimal price = openings[position];
            price = Math.Round(price, 3);
            var broker = new Broker();
            decimal stocks = broker.BuyStocks(price);
            return stocks;
        }
        public decimal GetTotalStocks()
        {
            return totalStocks;
        }
        private decimal GetAllStocks(DateTime initialDate, DateTime endDate, DayOfWeek day, Reader file)
        {
            while (initialDate < endDate)
            {
                BuyStocks(initialDate.Year, initialDate.Month, day, file);
                initialDate = initialDate.AddMonths(+1);
            }
            return totalStocks;
        }
        public decimal SellAllStocks(DateTime initialDate, DateTime endDate, DayOfWeek day, Reader file)
        {
            List<decimal> closures = file.GetClosureValues();
            decimal sellingPrice = closures[file.GetDates().IndexOf(endDate)];
            var allStocks = GetAllStocks(initialDate, endDate, day, file);
            decimal euros = Math.Round(sellingPrice * allStocks, 3);
            log.Info("Euros ganados por la venta de todas las acciones: " + euros);
            return euros;
        }
    }
}
