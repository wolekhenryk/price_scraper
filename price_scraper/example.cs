using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PuppeteerSharp;

public class BrowserManager : IDisposable
{
    private ConcurrentBag<Browser> browsers;
    private readonly int maxBrowsers; // The maximum number of browsers to use concurrently
    private readonly int maxConnectionsPerBrowser; // The maximum number of connections per browser
    private SemaphoreSlim semaphore;

    public BrowserManager(int maxBrowsers, int maxConnectionsPerBrowser)
    {
        this.maxBrowsers = maxBrowsers;
        this.maxConnectionsPerBrowser = maxConnectionsPerBrowser;
        browsers = new ConcurrentBag<Browser>();
        semaphore = new SemaphoreSlim(maxBrowsers, maxBrowsers);
    }

    public async Task InitializeAsync()
    {
        var tasks = Enumerable.Range(0, maxBrowsers)
            .Select(_ => Task.Run(async () =>
            {
                await semaphore.WaitAsync();
                try
                {
                    var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                    {
                        Headless = true // Set to false if you want to see the browser window for debugging purposes
                    });
                    browsers.Add(browser);
                }
                finally
                {
                    semaphore.Release();
                }
            }));

        await Task.WhenAll(tasks);
    }

    public async Task<IEnumerable<string>> ProcessProductsAsync(IEnumerable<string> productUrls)
    {
        var tasks = productUrls.Select(ProcessProductAsync);
        return await Task.WhenAll(tasks);
    }

    private async Task<string> ProcessProductAsync(string productUrl)
    {
        var browser = await GetAvailableBrowserAsync();

        using (var page = await browser.NewPageAsync())
        {
            // Perform your specific logic here to process the product URL using PuppeteerSharp
            // Example: await page.GoToAsync(productUrl);
            // Example: var content = await page.GetContentAsync();

            // Simulate some processing time (5-7 seconds in this example)
            await Task.Delay(TimeSpan.FromSeconds(5));

            // Return the result (or any data you need)
            return $"Result for {productUrl}";
        }
    }

    private async Task<Browser> GetAvailableBrowserAsync()
    {
        await semaphore.WaitAsync();
        try
        {
            var availableBrowser = browsers.FirstOrDefault(b => b.Connections.Count < maxConnectionsPerBrowser);
            if (availableBrowser == null)
            {
                // If all browsers are busy, wait until one becomes available
                await Task.Delay(100);
                return await GetAvailableBrowserAsync();
            }
            return availableBrowser;
        }
        finally
        {
            semaphore.Release();
        }
    }

    public void Dispose()
    {
        foreach (var browser in browsers)
        {
            browser.CloseAsync().Wait();
            browser.Dispose();
        }
    }
}
