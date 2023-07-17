using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace price_scraper.Core
{
    public class Query
    {
        public string ProductName { get; }
        public string Currency { get; }
        public int ProductsPerPage { get; }
        public int PageNumber {get; }

        public Query(string productName, string currency, int ppp, int pn)
        {
            ProductName = productName;
            Currency = currency;
            ProductsPerPage = ppp;
            PageNumber = pn;
        }
    }
}
