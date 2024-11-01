using Microsoft.Playwright;
using TechTalk.SpecFlow;
using TFL_Interview.Base;
using TFL_Interview.Pages;

namespace TFL_Interview.Steps
{
    [Binding]
    public class PlanAJourneySteps 
    {
        protected IPage page;
        protected PlanAJourneyPage planAJourneyPage;
        protected JourneyDetailsPage journeyDetailsPage;

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            PlaywrightDriver playwrightDriver = new PlaywrightDriver();
            page = await playwrightDriver.InitalizePlaywright();
            planAJourneyPage = new PlanAJourneyPage(page);
        }

        [Given(@"I browse to TFL Journey Planner")]
        public async Task GivenIBrowseToTFLJourneyPlanner()
        {
            await planAJourneyPage.GotoAsync();      
            await planAJourneyPage.AcceptCookiesButton.WaitForAsync();
            await planAJourneyPage.AcceptCookiesButton.ClickAsync();
            await planAJourneyPage.IsPageAvailable();
        }

        
        [Given(@"I plan my journey from '([^']*)' to '([^']*)'")]
        [When(@"I plan my journey from '([^']*)' to '([^']*)'")]
        public async Task WhenIPlanMyJourneyFromTo(string station1, string station2)
        {
            await planAJourneyPage.FromJourney.FillAsync(station1);
            await planAJourneyPage.ToJourney.FillAsync(station2);
        }


        [When(@"I plan my journey '([^']*)' stationname starting with '([^']*)' for station '([^']*)'")]
        public async Task WhenIPlanMyJourneyStationnameStartingWithForStation(string from_to, string stationkeyword, string actualstation)
        {
            if (from_to == "from") 
            {
                await planAJourneyPage.FromJourney.FillAsync(stationkeyword);
                planAJourneyPage.ClickOnMatchedStation(actualstation);
                await planAJourneyPage.TakeScreenshot(actualstation);
            }
            else
            {
                await planAJourneyPage.ToJourney.FillAsync(stationkeyword);
                planAJourneyPage.ClickOnMatchedStation(actualstation);
                await planAJourneyPage.TakeScreenshot(actualstation);
            }
        }
                

        [Given(@"I click on Plan my journey")]
        [When(@"I click on Plan my journey")]
        public async Task WhenIClickOnPlanMyJourney()
        {
            await planAJourneyPage.PlanJourneyButton.ClickAsync();            
            journeyDetailsPage = new JourneyDetailsPage(page);
            journeyDetailsPage.WaitForPageLoaded();            
            journeyDetailsPage.TakeScreenshot("JourneyDetails");
        }

        [When(@"I get Edit Page")]
        public void WhenIGetEditPage()
        {
            //throw new PendingStepException();
        }

        [When(@"I edit my journey preferences")]
        public async Task WhenIEditMyJourneyPreferences()
        {
            await journeyDetailsPage.ScrollToEditPreferences();
            await journeyDetailsPage.EditPreferencesButton.ClickAsync();            
        }

        [When(@"I select '([^']*)'")]
        public async Task WhenISelect(string preferredjourney)
        {
            await journeyDetailsPage.SelectRadioButton_WithText(preferredjourney);
        }

        [When(@"I update journey")]
        public async Task WhenIUpdateJourney()
        {
            await journeyDetailsPage.UpdateJourney();
        }

        [When(@"I select View Details")]
        public async Task WhenISelectViewDetails()
        {
            await journeyDetailsPage.ViewDetails.ClickAsync();
        }


        [Then(@"journey contains '([^']*)'")]
        public void ThenJourneyContains(string journeytype)
        {            
            var divclass = string.Format("method {0} notranslate", journeytype.ToLower());
            Assert.That(journeyDetailsPage.IsJourneyOptionValid(divclass),Is.True);//,string.Format("Journey  { 0} not found" ,journeytype));            
        }

        [Then(@"I get error")]
        public void ThenIGetError()
        {
            Assert.That(planAJourneyPage.ErrorContainer,Is.Not.Null, "Error message not displayed");
        }

        [Then(@"I get multiple results")]
        public void ThenIGetMultipleResults()
        {
            Assert.That(planAJourneyPage.AmbigousContainer, Is.Not.Null, "Error message not displayed");
        }

        [Then(@"the journey time is not empty")]
        public void ThenTheJourneyTimeIsNotEmpty()
        {
            Assert.That(planAJourneyPage.JourneyTime.InnerHTMLAsync().Result, Is.Not.Null, "Journey time is not empty");
        }

        [Then(@"Accessibility '([^']*)' is shown")]
        public void ThenAccessibilityIsShown(string accessibilityname)
        {
            throw new PendingStepException();
        }

        [AfterScenario]
        public void CloseBrowser() 
        {
            this.CloseBrowser();
        }
    }
}
