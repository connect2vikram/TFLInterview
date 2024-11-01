using Microsoft.Playwright;

namespace TFL_Interview.Base
{
    public class PlaywrightDriver
    {
        public IPage Page { get; set; }
        public IBrowserContext Context { get; set; }

        public async Task<IPage> InitalizePlaywright()
        {
            var browser = await InitBrowserAsync();
            Context = await browser.NewContextAsync(new BrowserNewContextOptions {ViewportSize = ViewportSize.NoViewport });
            Page = await Context.NewPageAsync();                        
            return Page;
        }

        private async Task<IBrowser> InitBrowserAsync()
        {
            var playwright = await Playwright.CreateAsync();
            BrowserTypeLaunchOptions launchOptions = new BrowserTypeLaunchOptions { Headless = false,Args = new[] { "--start-maximized" } };
            return await playwright.Chromium.LaunchAsync(launchOptions);
        }

        //public async Task<IPage> InitalizePlaywrightTracingAsync()
        //{
        //    var browser = await InitBrowserAsync();
        //    Context = await browser.NewContextAsync();            
        //    await Context.Tracing.StartAsync(new TracingStartOptions
        //    {
        //        Screenshots = true,
        //        Snapshots = true
        //    });
        //    Page = await Context.NewPageAsync();
        //    return Page;
        //}

    }
}
