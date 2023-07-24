using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PuppeteerSharp;

public class PuppeteerManager : IDisposable
{
    private readonly int maxBrowsers;
    private readonly int maxConnectionsPerBrowser;
    private readonly List<Browser> browsers;
    private readonly ConcurrentQueue<Browser> availableBrowsers;
    private readonly SemaphoreSlim browserSemaphore;

    public PuppeteerManager(int maxBrowsers = 5, int maxConnectionsPerBrowser = 5)
    {
        this.maxBrowsers = maxBrowsers;
        this.maxConnectionsPerBrowser = maxConnectionsPerBrowser;
        this.browsers = new List<Browser>();
        this.availableBrowsers = new ConcurrentQueue<Browser>();
        this.browserSemaphore = new SemaphoreSlim(maxBrowsers);
    }

    public async Task<string> ProcessUrlAsync(string url, Func<Page, Task<string>> processAction)
    {
        Browser browser = await GetAvailableBrowserAsync();

        try
        {
            using (Page page = await browser.NewPageAsync())
            {
                // Add any specific configuration here, such as user agent, viewport settings, etc.
                // await page.SetUserAgentAsync("your-user-agent");

                await page.GoToAsync(url, new NavigationOptions { Timeout = 30000 });

                string result = await processAction(page);

                return result;
            }
        }
        finally
        {
            availableBrowsers.Enqueue(browser);
        }
    }

    public async Task ProcessUrlsAsync(IEnumerable<string> urls, Func<Page, Task> processAction)
    {
        List<Task> tasks = urls.Select(url => ProcessUrlAsync(url, async page => await processAction(page))).ToList();
        await Task.WhenAll(tasks);
    }

    private async Task<Browser> GetAvailableBrowserAsync()
    {
        if (availableBrowsers.TryDequeue(out Browser browser))
        {
            return browser;
        }
        else
        {
            await browserSemaphore.WaitAsync();
            try
            {
                if (browsers.Count < maxBrowsers)
                {
                    browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
                    browsers.Add(browser);
                    return browser;
                }
                else
                {
                    throw new Exception("Reached maximum number of browsers.");
                }
            }
            finally
            {
                browserSemaphore.Release();
            }
        }
    }

    public void Dispose()
    {
        foreach (Browser browser in browsers)
        {
            browser.CloseAsync();
            browser.Dispose();
        }
    }
}
