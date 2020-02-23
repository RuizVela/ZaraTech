using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZaraTech_Prueba
{
    public class Reader
    {
            List<string> dates = new List<string>();
            List<string> openings = new List<string>();
            List<string> closures = new List<string>();
        void Read()
        {
            string path = @"c:\Users\usuario\source\repos\ZaraTech Prueba\stocks-ITX.csv";
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {

                string[] columns = line.Split(';');
                dates.Add(columns[0]);
                openings.Add(columns[1]);
                closures.Add(columns[2]);
            }
        }
    }
}
