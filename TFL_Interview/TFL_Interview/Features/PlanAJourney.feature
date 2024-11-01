Feature: Planning a Journey
A short summary of the feature

Scenario: Plan a Journey
	Given I browse to TFL Journey Planner
	When I plan my journey 'from' stationname starting with 'lei' for station 'Leicester Square Underground Station'
	And I plan my journey 'to' stationname starting with 'Cov' for station 'Covent Garden Underground Station'
	And I click on Plan my journey	
	Then journey contains 'cycling'
	And journey contains 'walking'
	

Scenario: Empty Journey throws error
	Given I browse to TFL Journey Planner	
	When I click on Plan my journey
	Then I get error
	

Scenario: Invalid Journey gives multiple results
	Given I browse to TFL Journey Planner	
	When I plan my journey from 'doilwala' to 'dalanwala'
	When I click on Plan my journey
	Then I get multiple results

