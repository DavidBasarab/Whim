Feature: UserManagement
    In order to manage user of the system
    As a system administrator
    I want to be able to manage users, which include create, retrieve, update, and delete

Scenario: A user is added to the system
    Given I have a user with first name of "Jack"
    And I have a user with the last name of "Blood"
    When I enter the user into the system
    Then the user is created