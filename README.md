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


