Feature: CrawfordTests
	
Scenario: Verify crawford facebook page
	Given I have navigated to crawco home page
	When I click on 'contact' link
	Then I navigated to 'contact' page 
	When I click on 'facebook' link
	Then I navigated to 'facebook' page
	And validate the facebook url
	