using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace price_scraper.Core.Web;

public class ScrapingHandler
{
    public HeadlessBrowserPool BrowserPool { get; }

    public ScrapingHandler(int poolSize) => BrowserPool = new HeadlessBrowserPool(poolSize);
    
    private const string Failure1 = "Podana przez ciebie fraza";
    private const string Failure2 = "Nie została znaleziona";

    private const string BlankParam = "-";

    public async Task<List<Product>> PerformScraping(IEnumerable<Query> productNames)
    {
        var result = new ConcurrentBag<Product>(); // Use a thread-safe collection for storing results

        await Task.WhenAll(productNames.Select(async queriedProduct =>
        {
            var browser = await BrowserPool.GetBrowserAsync();
            if (browser == null) throw new ArgumentNullException(nameof(browser));

            try
            {
                await using var page = await browser.NewPageAsync();
                await page.GoToAsync($"https://www.tme.eu/pl/katalog/?search={queriedProduct.ProductName}&limit={queriedProduct.ProductsPerPage}&currency={queriedProduct.Currency}");

                var html = await page.GetContentAsync() ?? throw new InvalidOperationException();
                var productsTable = await page.QuerySelectorAsync("table#products.c-products-table");

                //Check if no product has been found
                if (productsTable == null || (html.Contains(Failure1) && html.Contains(Failure2)))
                {
                    //Add this empty product to list, '-' everywhere
                    var productNotFound = new Product(BlankParam, BlankParam, BlankParam, BlankParam, BlankParam);
                    result.Add(productNotFound);
                }
                else
                {
                    await page.WaitForSelectorAsync("div.c-price-table__cell");

                    var allFound = await page.QuerySelectorAsync("a.c-filters__all-found");
                    var allFoundCount = await allFound.EvaluateFunctionAsync<string>("e => e.innerText");

                    var trElements =
                        await page.QuerySelectorAllAsync("table#products.c-products-table tbody tr[data-id]");
                    var trElementsCount = trElements.Length;

                    var match = Regex.Match(allFoundCount, @"\((\d+)\)");
                    if (match.Success)
                    {
                        var matchGroup = match.Groups[1].Value;
                        if (int.TryParse(matchGroup, out var totalCount))
                        {
                        }
                    }

                    foreach (var trElement in trElements) {}
                }

            }
            finally
            {
                BrowserPool.ReturnBrowser(browser);
            }
        }));

        return result.ToList();
    }


    public async Task CloseAllAsync() => await BrowserPool.CloseAllBrowsersAsync();
}