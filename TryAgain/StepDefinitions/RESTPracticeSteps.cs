using System;
using TechTalk.SpecFlow;
using TryAgain.REST;
using NUnit.Framework;

namespace TryAgain.StepDefinitions
{
    [Binding]
    public class RESTPracticeSteps
    {
        [Given(@"the base URL: (.*)")]
        public void baseURL(String url)
        {
            RestDefault.createClient(url);
        }
        
        [Given(@"resource: (.*)")]
        public void resource(String resource)
        {
            RestDefault.createRequest(resource);
        }
        
        [Given(@"body:")]
        public void body(String body)
        {
            RestDefault.addJsonBody(body);
        }
        
        [When(@"I perform the call with method: (.*)")]
        public void performCallWithMethod(String method)
        {
            switch (method)
            {
                case "GET":
                    RestDefault.performGetCall();
                    break;
                case "POST":
                    RestDefault.performPostCall();
                    break;
            }
        }
        
        [Then(@"the response message should be (.*)")]
        public void VerifyResponseMessage(String expectedCode)
        {
            Assert.AreEqual(RestDefault.getResponseMessage(), expectedCode);
        }

        [Then(@"the response code should be (.*)")]
        public void VerifyResponseCode(int expectedCode)
        {
            Assert.AreEqual(expectedCode,RestDefault.getResponseCode());
        }
    }
}
