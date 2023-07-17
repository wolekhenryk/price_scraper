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
    private const int EmptyStock = 0;

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
                    var productNotFound = new Product(BlankParam, BlankParam, BlankParam, BlankParam, BlankParam, EmptyStock, BlankParam);
                    result.Add(productNotFound);
                }
                else
                {
                    await page.WaitForSelectorAsync("div.c-price-table__cell");
                    //await page.WaitForSelectorAsync("b.stock_number.stock_number--white-space");

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

                    foreach (var trElement in trElements)
                    {
                        var productSymbolText = BlankParam;
                        var productDescriptionText = BlankParam;
                        var originalSymbolText = BlankParam;
                        var manufacturerText = BlankParam;
                        var stock = EmptyStock;
                        var priceStepsHeaderText = BlankParam;
                        var qType = BlankParam;

                        //Get product name on TME site
                        productSymbolText =
                            await trElement.EvaluateFunctionAsync<string>("e => e.getAttribute('data-id')");

                        //Get product description
                        var spanElement =
                            await trElement.QuerySelectorAsync("div.c-product-row__name-cell-sub-row span");
                        if (spanElement != null)
                            productDescriptionText = await spanElement.EvaluateFunctionAsync<string>("e => e.innerText");

                        //Get manufacturer name
                        var manufacturerElement = await trElement.QuerySelectorAsync("b.c-product-row__producer-link");
                        if (manufacturerElement != null)
                            manufacturerText = await manufacturerElement.EvaluateFunctionAsync<string>("e => e.innerText");

                        //Get original symbol
                        var originalSymbolElement = await trElement.QuerySelectorAsync("b.c-product-row__original-symbol");
                        if (originalSymbolElement != null)
                            originalSymbolText = await originalSymbolElement.EvaluateFunctionAsync<string>("e => e.innerText");

                        //Get stock status
                        var stockStatusElement =
                            await trElement.QuerySelectorAsync("b.stock_number.stock_number--white-space");
                        if (stockStatusElement != null)
                            stock = int.Parse(await stockStatusElement.EvaluateFunctionAsync<string>("e => e.innerText") ?? throw new InvalidOperationException());

                        //Get quantity type
                        var qTypeElement = await trElement.QuerySelectorAsync("div.c-product-row__cell_row.stany");
                        if (qTypeElement != null)
                        {
                            var nestedDiv = await qTypeElement.QuerySelectorAsync("div") ?? throw new InvalidOperationException();
                            var bTag = await nestedDiv.QuerySelectorAsync("b") ?? throw new InvalidOperationException();

                            qType = await bTag.EvaluateFunctionAsync<string>("e => e.innerText");
                        }

                        //Get prices
                        var priceSteps =
                            await trElement.QuerySelectorAllAsync("div.c-price-table__cell.prices_range_amount");
                        var priceAmounts =
                            await trElement.QuerySelectorAllAsync("div.c-price-table__cell[data-price]");
                        var priceHeaderElement =
                            await trElement.QuerySelectorAllAsync("div.c-price-table__cell.c-price-table__cell-header");
                        var priceData = BlankParam;

                        if (priceSteps != null && priceAmounts != null)
                        {
                            priceData = "";
                            var quantityHeaderText =
                                await priceHeaderElement[0].EvaluateFunctionAsync<string>("e => e.innerText");
                            var priceHeaderText =
                                await priceHeaderElement[1].EvaluateFunctionAsync<string>("e => e.innerText");

                            for (var i = 0; i < priceSteps.Length; i++)
                            {
                                var priceStep = priceSteps[i];
                                var priceAmount = priceAmounts[i];

                                var priceStepText = await priceStep.EvaluateFunctionAsync<string>("e => e.innerText");
                                var priceAmountText = await priceAmount.EvaluateFunctionAsync<string>("e => e.innerText");

                                priceData += $"{priceStepText}: {priceAmountText};";
                            }
                        }

                        result.Add(new Product(queriedProduct.ProductName, productSymbolText, originalSymbolText, productDescriptionText, priceData, stock, qType));
                    }
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