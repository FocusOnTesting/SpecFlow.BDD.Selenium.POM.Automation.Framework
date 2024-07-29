using Automation.DemoUI.WebAbstraction;
using System;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.Test
{
    [Binding]
    public class LoginStep
    {
        ILoginPage _iloginPage;
        public LoginStep(ILoginPage iloginPage)
        {
            _iloginPage = iloginPage;
        }

        [Given(@"login with valid credentials")]
        public void GivenLoginWithValidCredentials()
        {
            _iloginPage.LoginWithValidCredentials();
        }
    }
}
