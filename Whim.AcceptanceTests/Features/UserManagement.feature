Feature: UserManagement
	In order to manage user of the system
	As a system user
	I want to be able to manage users, which inlcude create, retrevie, update, and delete

Scenario: A user to the system
	Given I have a user with first name of "Jack"
    And I have a user with the last name of "Blood"
	When I enter the user into the system
	Then the user is created
