using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace ZaraTech_Prueba
{
    public class Reader
    {
            decimal totalShares;
            public List<DateTime> dates = new List<DateTime>();
            List<string> openings = new List<string>();
            List<string> closures = new List<string>();
            const string path = @"c:\Users\usuario\source\repos\ZaraTech Prueba\stocks-ITX.csv";
            CultureInfo provider = new CultureInfo("es-US");

        public void Read()
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] columns = line.Split(';');
                if (columns[0] != "Fecha")
                {
                dates.Add(Convert.ToDateTime(columns[0], provider));
                }
                if (columns[1] != "Cierre")
                {
                closures.Add(columns[1]);
                }
                if (columns[2] != "Apertura")
                { 
                openings.Add(columns[2]);
                }
            }
        }
        private DateTime GetLastWeekDayOfMonth(int year, int month, System.DayOfWeek day)
        {
            var monthDays = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            monthDays = Convert.ToDateTime(monthDays, provider);
            while (monthDays.DayOfWeek != day)
            {
                monthDays = monthDays.AddDays(-1);
            }
            while (!dates.Contains(monthDays))
            {
                monthDays = monthDays.AddDays(-1);
            }
            return monthDays;
        }
        public decimal BuyShares(int year, int month, DayOfWeek day)
        {
            var buyingDay = GetLastWeekDayOfMonth(year, month, day);
            var position = dates.IndexOf(buyingDay) - 1;
                decimal shares = BuyPartialShare(position);
                totalShares = totalShares + shares;
            return totalShares;
        }
        private decimal BuyPartialShare(int position)
        {
            var inversion = 49;
            var openingValue = openings[position].Replace(".", ",");
            decimal divisor = decimal.Parse(openingValue);
            divisor = Math.Round(divisor, 3);
            decimal shares = inversion / divisor;
            shares = Math.Round(shares, 3);
            return shares;
        }
        public decimal GetAllShares(DateTime initialDate, DateTime endDate, DayOfWeek day)
        {
            while(initialDate < endDate)
            {
                BuyShares(initialDate.Year, initialDate.Month, day);
                initialDate = initialDate.AddMonths(+1);
            }
            return totalShares;
        }
        public decimal SellAllShares(DateTime initialDate, DateTime endDate, DayOfWeek day)
        {
            var totalShares = GetAllShares(initialDate, endDate, day);
            decimal euros = Math.Round(29.17m * totalShares, 3);
            return euros;
        }
    }
}
