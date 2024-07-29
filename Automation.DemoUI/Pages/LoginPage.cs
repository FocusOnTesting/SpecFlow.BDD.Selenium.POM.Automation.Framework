using Automation.DemoUI.WebAbstraction;
using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.Base;
using Automation.Framework.Core.WebUI.DIContainer;
using BoDi;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.DemoUI.Pages
{
    public class LoginPage : TestBase, ILoginPage
    {
        IAppConfiguration _iappConfiguration;
        IDriver _idriver;

        IAtBy byUserName => GetBy(LocatorType.Id, "UserName");
        IAtWebElement UserName => _idriver.FindElement(byUserName);
        IAtBy byPassword => GetBy(LocatorType.Name, "Password");
        IAtWebElement Password => _idriver.FindElement(byPassword);
        IAtBy byLogin => GetBy(LocatorType.Xpath, "//input[@value='Log in']");
        IAtWebElement Login => _idriver.FindElement(byLogin);

        public LoginPage(IObjectContainer iobjectContainer)
            : base(iobjectContainer)
        {
            _iappConfiguration = iobjectContainer.Resolve<IAppConfiguration>();
            _idriver = iobjectContainer.Resolve<IDriver>();

            //string dr = _idriver.GetWebDriver().GetHashCode().ToString();
            //Log.Information("The hashcode of browser driver is: " + dr);
        }

        public void LoginWithValidCredentials()
        {
            string url = _iappConfiguration.GetConfiguration("url");
            _idriver.NavigateTo(url);
            UserName.SendKeys(_iappConfiguration.GetConfiguration("username"));
            Password.SendKeys(_iappConfiguration.GetConfiguration("password"));
            Login.Click();
        }
    }
}
