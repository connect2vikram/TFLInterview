using Microsoft.Playwright;

namespace TFL_Interview.Base
{
    public class BasePage
    {
        protected IPage Page;
        public BasePage(IPage page)
        {
            this.Page = page;
        }

        public async Task GotoPageAsync(string page)
        {
            await Page.GotoAsync(page, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });
        }

        public async Task TakeScreenshot(string filename)
        {
            await Page.ScreenshotAsync(new() { Path = filename + ".png" });
        }

        public async Task CloseBrowser() 
        { 
            await Page.CloseAsync();
        }
    }
}

