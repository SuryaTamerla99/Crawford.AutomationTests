using APITests.Contexts;
using APITests.Services;
using NUnit.Framework;
using System.Net;
using TechTalk.SpecFlow;

namespace APITests.Steps
{
    [Binding]
    public class UserSteps
    {
        private UserServices _userServices;
        private readonly Contexts.TestContext _testContext;
        public UserSteps(Contexts.TestContext testContext)
        {
            _testContext = testContext;
        }

        [Given(@"I have initialise user client")]
        public void InitialiseUserClient()
        {
            _userServices = new UserServices();
        }

        [When(@"I get the user by id '(.*)'")]
        public void GetUserById(string userId)
        {
            _testContext.Id = userId;
            _testContext.UserResponse = _userServices.GetUserById(_testContext.Id);
        }

        [Then(@"the response should return status code '(.*)'")]
        public void VerifyStatusCode(HttpStatusCode statusCode)
        {
            if (_testContext.UserResponse != null)
            {
                Assert.AreEqual(statusCode, _testContext.UserResponse.StatusCode,
                    $"Expected status code is: '{statusCode}' is not same as actual status code: '{_testContext.UserResponse.StatusCode}'");
            }
            else
            {
                Assert.Fail("Response returns null");
            }
        }

        [Then(@"response contains '(.*)' and '(.*)'")]
        public void ThenResponseContainsFirstnameAndLastname(string firstname, string lastname)
        {
            if (_testContext.UserResponse != null)
            {
                Assert.AreEqual(firstname, _testContext.UserResponse.Content.data.first_name,
                    $"Expected firstname: '{firstname}' is not same as actual firstname: '{_testContext.UserResponse.Content.data.first_name}'");
                Assert.AreEqual(lastname, _testContext.UserResponse.Content.data.last_name,
                    $"Expected lastname: '{lastname}' is not same as actual lastname: '{_testContext.UserResponse.Content.data.last_name}'");
            }
            else
            {
                Assert.Fail("Response returns null");
            }
        }

    }
}
