Feature: GetUserById
	
#second test fails as we are expecting Ramos but original name is Tracey
Scenario Outline: Get user by id
	Given I have initialise user client
	When I get the user by id '<id>'
	Then the response should return status code 'OK' 
	And response contains '<firstname>' and '<lastname>'
	Examples: 
	| id | firstname | lastname |
	| 4  | Eve       | Holt     |
	| 6  | Sergio    | Ramos    |

Scenario: Get user by invalid id
	Given I have initialise user client
	When I get the user by id '23'
	Then the response should return status code 'NotFound' 
