# TFLInterview
Repository for automating Plan My Journey

Following has been used to Setup the Automation using Playwright
1) Installed Visual Studio 2022 (Community) - https://github.com/SpecFlowOSS/SpecFlow.VS/releases/tag/v2022.1.93-net8 on Personal Laptop
2) Make sure Specflow has been configured to work with Visual Studio as show
   ![Specflow_VisualStudio_Integration](https://github.com/user-attachments/assets/9deb155b-75f2-4736-be6a-3741e6d7ae46)
3) Open the downloaded solution from the Github from your local machine in Visual Studio
4) Make sure to update all the nuget packages before building the solution
5) Build the solution to have a directory in solution as /bin/Debug/net8.0 where the file 'playwright.ps1' will exist
6) From Visual Studio now open Tools -> Command Line -> Developer Powershell (see screenshot)
   ![Powershell](https://github.com/user-attachments/assets/8fa39d8c-3cef-48b3-9561-781b6c0418de)
7) Run below command from here (Please make sure to run the command from where bin exist in your local folder structure)
	pwsh bin/Debug/net8.0/playwright.ps1 install 
   This process will take some time as it downloads all the browsers kits


**Issues with Test**
1) The tests are bit fragile and the scenario 'Plan a Journey' has Thread.Sleep (as due to lack of time I could not find the right element to wait for the dynamic dropdown) and I wanted to experiment with Playwright rather than Selenium which is fairly new to me as well. You might have to put a breakpoint inside method 'planAJourneyPage.ClickOnMatchedStation' to see it working
2) Other tests also run (sometimes run again) as the 'Accept cookies) makes the background screen unavailable at times
3) I have not asserted on things like timings etc as that would have made the tests fragile and this could be done on the lower API layer testing where stubs etc can be used. UI tests are more for testing the existing of elements after actions and hence validation of route (stations / timings etc has not been done as per the document)


**Other Testing Scenarios**
1) Invalid characters accepted in stations
2) More than 100 characters not allowed
3) Does 'My location' works
4) Does all other links on the Plan my journey work
5) What does selecting on 'My location' work and how does it behaves if the google maps is not available
6) Accessibility of the page (images with no alt text, link with no proper description)
7) Performance of the Start and End drop down menu as that gets data based on input
8) Performance of the Plan my journey between 2 stations
9) What happens when API behind getting data between source and destination fails. How graceully TFL handles the data
10) There is no security in general for this page unless the user is logged in



