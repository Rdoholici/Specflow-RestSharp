using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TryAgain.PageObject;

namespace TryAgain.StepDefinitions
{
    [Binding]
    public class SeleniumPracticeSteps
    {
        DefaultActions defaultActions = DefaultActions.getInstance();

        [Given(@"that I navigate to the URL: (.*)")]
        public void NavigateTo(String url)
        {
            defaultActions.navigateToUrl(url);
        }

        [Then(@"the page tile is: (.*)")]
        public void verifyPageTitle(String expectedTitle)
        {
            Assert.IsTrue(defaultActions.verifyPageTitle(expectedTitle));
        }

        [When(@"I input the text: (.*) in the element with the label: (.*)")]
        public void InputTextInElement(String text, String elementLabel)
        {
            defaultActions.sendKeysToElement(text, elementLabel);
            Assert.IsTrue(defaultActions.verifyElementHasTextInput(text, elementLabel));
        }

        [When(@"I press the element with the text: (.*)")]
        public void PressElement(String elementText)
        {
            defaultActions.pressElement(elementText);
        }

        [Then(@"the text: (.*) is displayed")]
        public void Verify(String expectedText)
        {
            Assert.IsTrue(defaultActions.verifyTextPresentInPage(expectedText));
        }

        [Then(@"I quit the driver")]
        public void ThenIQuitTheDriver()
        {
            defaultActions.quitDriver();
        }

    }
}
