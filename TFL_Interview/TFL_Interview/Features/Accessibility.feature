Feature: View Details Shows All Accessibilty of the Station

A short summary of the feature


Scenario: Preferences can be edited
	Given I browse to TFL Journey Planner	
	And I plan my journey from 'Leicester Square Underground Station' to 'Covent Garden Underground Station'
	And I click on Plan my journey
	When I get Edit Page
	And I edit my journey preferences
	And I select 'Routes with least walking'
	And I update journey
	And I select View Details
	Then Accessibility 'Up lift' is shown
	And Accessibility 'Level walkway' is shown
	And Accessibility 'Up stairs' is shown
	

