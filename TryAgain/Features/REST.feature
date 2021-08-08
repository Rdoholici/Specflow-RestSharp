Feature: REST Practice

Scenario: Perform REST call
	Given the base URL: https://reqres.in
	And resource: /api/users
	And body:
		"""
		    {
		        "name": "gigel1",
		        "job": "tractorist1"
		    }
		"""
	When I perform the call with method: POST
	Then the response message should be Created
	And the response code should be 201