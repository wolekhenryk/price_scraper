using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace price_scraper.Core.Web;

public class HeadlessBrowserPool
{
    private readonly ConcurrentBag<Browser> _browserPool;
    public int PoolSize { get; }

    public HeadlessBrowserPool(int poolSize)
    {
        _browserPool = new ConcurrentBag<Browser>();
        PoolSize = poolSize;
    }
    public async Task<Browser?> GetBrowserAsync()
    {
        if (_browserPool.TryTake(out var browser))
        {
            return browser;
        }

        var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);

        return await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true }) as Browser;
    }

    public void ReturnBrowser(Browser browser)
    {
        _browserPool.Add(browser);
    }
    public async Task CloseAllBrowsersAsync()
    {
        foreach (var browser in _browserPool)
            await browser.CloseAsync();

        _browserPool.Clear();
    }
}