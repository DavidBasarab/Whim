using TechTalk.SpecFlow;

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
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter the user into the system")]
        public void WhenIEnterTheUserIntoTheSystem()
        {
            ScenarioContext.Current.Pending();
        }
    }
}