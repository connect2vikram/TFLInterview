using Microsoft.Playwright;
using TFL_Interview.Base;

namespace TFL_Interview.Pages
{
    public class PlanAJourneyPage : BasePage
    {
        public PlanAJourneyPage(IPage page) : base(page)
        {
        }

        public async Task GotoAsync() => await this.GotoPageAsync(Constants.BaseAddress + Constants.PLAN_JOURNEY_ADDRESS);

        public ILocator AcceptCookiesButton
        {
            get
            {                
                return Page.GetByRole(AriaRole.Button, new() { Name = "Accept all cookies"});                
            }
        }

        public async Task IsPageAvailable() 
        {
            await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }

        public ILocator FromJourney 
        {
            get 
            {
                return Page.Locator("#InputFrom");                
            }
        }

        public ILocator ToJourney
        {
            get
            {
                return Page.Locator("#InputTo");
            }
        }

        public ILocator PlanJourneyButton 
        {
            get 
            {
                return Page.Locator("#plan-journey-button");
            }
        }

        public ILocator AmbigousContainer
        {
            get 
            {
                return Page.Locator("info-message disambiguation");
            }
        }

        public ILocator JourneyTime
        {
            get 
            {
                return Page.Locator(".journey-time").First;
            }
        
        }

        public ILocator ErrorContainer 
        {
            get 
            {
                return Page.Locator("#InputFrom-error").First;
            }
        }

        public ILocator GetMatchedAccessibility(string accessibiliyname) 
        {
            return Page.GetByRole(AriaRole.Link, new PageGetByRoleOptions() { Name = accessibiliyname });
        }

        public void ClickOnMatchedStation(string matchedstation) 
        {
            ILocator stationMatchedLocator = null;
            var retry = 0;
            List<string> matchedsuggestions = new List<string>();

            stationMatchedLocator = Page.Locator("xpath=//div[@class='tt-suggestion']").AllAsync().Result.Where(r => r.InnerHTMLAsync().Result.Replace("</strong>", "").Contains(matchedstation)).FirstOrDefault();            
            while (stationMatchedLocator == null && retry < 5)
            {
                stationMatchedLocator = Page.Locator("xpath=//div[@class='tt-suggestion']").AllAsync().Result.Where(r => r.InnerHTMLAsync().Result.Replace("</strong>", "").Contains(matchedstation)).FirstOrDefault();
                if (stationMatchedLocator != null)
                {                    
                    break;
                }
                Thread.Sleep(3000); //TODO - Remove this
                retry++;                
            }
            //Assertions.Expect(startstationMatchedLocator.GetByRole(AriaRole.Option)).ToBeEnabledAsync();
            //Thread.Sleep(3000); //TODO - Remove this
            var selectedOption = stationMatchedLocator.GetByRole(AriaRole.Option).ClickAsync();            
        }
    }
}
