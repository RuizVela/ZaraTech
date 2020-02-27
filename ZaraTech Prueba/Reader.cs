using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Configuration;

namespace ZaraTech_Prueba
{
    public class Reader
    {
        private readonly List<DateTime> dates = new List<DateTime>();
        private readonly List<decimal> openings = new List<decimal>();
        private readonly List<decimal> closures = new List<decimal>();
        readonly string path = ConfigurationManager.AppSettings["path"].ToString();
        readonly CultureInfo provider = new CultureInfo("es-US");

        public void StoreData()
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] columns = line.Split(';');
                StoreDates(columns[0]);
                StoreClosurePrices(columns[1]);
                StoreOpeningPrices(columns[2]);
            }
        }
        private void StoreDates(string date)
        {
            if (date == "Fecha")
            {
                return;
            }
                dates.Add(Convert.ToDateTime(date, provider));
        }
        private void StoreClosurePrices(string price)
        {
            if (price == "Cierre")
            {
                return;
            }
                closures.Add(Math.Round(decimal.Parse(price.Replace(".",",")),3));
        }
        private void StoreOpeningPrices(string price)
        {
            if (price == "Apertura")
            {
                return;
            }
                openings.Add(decimal.Parse(price.Replace(".", ",")));
        }
        public List<DateTime> GetDates()
        {
            return dates;
        }
        public List<Decimal> GetOpeningValues()
        {
            return openings;
        }
        public List<Decimal> GetClosureValues()
        {
            return closures;
        }
        public CultureInfo GetProvider()
        {
            return provider;
        }
    }
}
