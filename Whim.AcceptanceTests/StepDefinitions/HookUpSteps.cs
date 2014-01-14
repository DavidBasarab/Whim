using TechTalk.SpecFlow;

namespace Whim.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class HookUpSteps
    {
        [Given(@"I need to hook up to testing")]
        public void GivenINeedToHookUpToTesting() {}

        [Then(@"I am hooked up and pass")]
        public void ThenIAmHookedUpAndPass() {}

        [When(@"I run a test")]
        public void WhenIRunATest() {}
    }
}