using System;

namespace ZaraTech_Prueba
{
    public class Broker
    {
        public decimal BuyStocks(decimal stockPrice)
        {
            var comission = 2;
            var inversion = 50;
            decimal comissionValue = 100 - comission;
            comissionValue /= 100;
            var realInversion = inversion * comissionValue;
            decimal stocksBought = Math.Round(realInversion / stockPrice,3);
            return stocksBought;
        }

    }
}
