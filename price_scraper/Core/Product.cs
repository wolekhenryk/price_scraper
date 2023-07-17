using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace price_scraper.Core
{
    public class Product
    {
        public string QueriedName { get; private set; }
        public string TmeName { get; private set; }
        public string OriginalName { get; private set; }
        public string Description { get; private set; }
        public string PriceData { get; private set; }
        public int Stock { get; private set; }

        public Product(string queriedName, string tmeName, string originalName, string description, string priceData)
        {
            QueriedName = queriedName;
            TmeName = tmeName;
            OriginalName = originalName;
            Description = description;
            PriceData = priceData;
        }
    }
}
