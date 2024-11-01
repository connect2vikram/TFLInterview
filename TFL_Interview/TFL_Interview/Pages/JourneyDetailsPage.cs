using Microsoft.Playwright;
using System.Runtime.InteropServices;
using TFL_Interview.Base;

namespace TFL_Interview.Pages
{
    public class JourneyDetailsPage : BasePage
    {
        public JourneyDetailsPage(IPage page) : base(page)
        {
        }

        public void WaitForPageLoaded() 
        {
            Page.Locator("#journey-banner-advice").IsVisibleAsync().Wait();
            //Page.GetByTitle("Journey results - Transport for London").WaitForAsync();            
        }

        public ILocator EditPreferencesButton
        {
            get
            {
                Assertions.Expect(Page.Locator("headline-container")).ToBeVisibleAsync();
                return Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { Name = "Edit preferences" });                
            }
        }

        public ILocator ViewDetails 
        { 
            get 
            {
                Assertions.Expect(Page.Locator(".end-location")).ToBeVisibleAsync();                
                return Page.GetByLabel("Option 1: walking, Piccadilly").GetByText("View details"); //TODO - THIS WILL NOT WORK WITH OTHER STATIONS                
            } 
        }


        public async Task ScrollToEditPreferences() 
        {
            Thread.Sleep(5000);            
            await this.Page.Mouse.WheelAsync(-1000, -1000);            
        }

        public bool IsJourneyOptionValid(string journeytypeclass)
        {
            Page.Locator(".journey-row-container.left-journey-options").WaitForAsync();
            var hrefs = Page.Locator("a").AllAsync().Result;            
            foreach (var href in hrefs) 
            {
                var value = href.InnerHTMLAsync().Result;
                if (value.Contains(journeytypeclass)) 
                {
                    return true;
                }
            }         
    
            return false;
        }

        public async Task SelectRadioButton_WithText(string preferredjourney)
        {
             await Page.GetByText(preferredjourney).ClickAsync();
        }

        public async Task UpdateJourney()
        {
            await Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { Name = "Update journey" }).ClickAsync();
        }
    }
}