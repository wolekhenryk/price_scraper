using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace price_scraper.Core
{
    public class Product
    {
        public string QueriedName { get; }
        public string TmeName { get; }
        public string OriginalName { get; }
        public string Description { get; }
        public string PriceData { get; }
        public int Stock { get; }
        public string QuantityType { get; }

        public Product(string queriedName, string tmeName, string originalName, string description, string priceData, int stock, string qType)
        {
            QueriedName = queriedName;
            TmeName = tmeName;
            OriginalName = originalName;
            Description = description;
            PriceData = priceData;
            Stock = stock;
            QuantityType = qType;
        }
    }
}
