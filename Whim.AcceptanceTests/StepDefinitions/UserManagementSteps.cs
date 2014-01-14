using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;
using Whim.Models;
using Whim.Presentation;

namespace Whim.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class UserManagementSteps
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }

        [Given(@"I have a user with first name of ""(.*)""")]
        public void GivenIHaveAUserWithFirstNameOf(string firstName)
        {
            FirstName = firstName;
        }

        [Given(@"I have a user with the last name of ""(.*)""")]
        public void GivenIHaveAUserWithTheLastNameOf(string lastName)
        {
            LastName = lastName;
        }

        [Then(@"the user is created")]
        public void ThenTheUserIsCreated()
        {
            var user = new User()
            {
                FirstName = FirstName,
                LastName = LastName
            };

            BasicUserAdministration.Instance.CreateUser(user);
        }

        [When(@"I enter the user into the system")]
        public void WhenIEnterTheUserIntoTheSystem()
        {
            var users = BasicUserAdministration.Instance.GetAllUsers();

            var foundUser = users
                    .FirstOrDefault(i => i.FirstName == FirstName && i.LastName == LastName);

            foundUser.Should().NotBeNull();
        }
    }
}