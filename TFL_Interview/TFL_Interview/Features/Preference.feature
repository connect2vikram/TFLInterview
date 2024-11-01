Feature: Preferences of Journey can be updated

A short summary of the feature


Scenario: Preferences can be edited
	Given I browse to TFL Journey Planner	
	And I plan my journey from 'Leicester Square Underground Station' to 'Covent Garden Underground Station'
	And I click on Plan my journey
	When I get Edit Page
	And I edit my journey preferences
	And I select 'Routes with least walking'
	And I update journey
	Then the journey time is not empty	

