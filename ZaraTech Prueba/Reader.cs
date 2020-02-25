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
            public List<string> dates = new List<string>();
            List<string> openings = new List<string>();
            List<string> closures = new List<string>();
            const string path = @"c:\Users\usuario\source\repos\ZaraTech Prueba\stocks-ITX.csv";
            CultureInfo provider = new CultureInfo("es-ES");

        public void Read()
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] columns = line.Split(';');
                dates.Add(columns[0]);
                closures.Add(columns[1]);
                openings.Add(columns[2]);
            }
        }
        public string GetLastWeekDayOfMonth(int year, int month, System.DayOfWeek day)
        {
            var monthDays = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            var lastDay = monthDays;
            while (monthDays.DayOfWeek != day)
            {
                lastDay = monthDays.AddDays(-1);
            }

            var lastWeekDay = lastDay.ToString("dd-MMM-yyyy", provider);
            lastWeekDay = lastWeekDay.Replace(".", "");
            return lastWeekDay;
        }
    }
}
