using Automation.DemoUI.Configuration;
using Automation.DemoUI.Pages;
using Automation.DemoUI.WebAbstraction;
using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.DIContainer;
using BoDi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.Container
{
    [Binding]
    public class AppContainerConfig
    {
        [BeforeScenario(Order = 1)]
        public void BeforeScenario(IObjectContainer iobjectContainer)
        {

            iobjectContainer.RegisterTypeAs<AppConfiguration, IAppConfiguration>();
            //Register LoginPage in AppContainerConfig
            iobjectContainer.RegisterTypeAs<LoginPage, ILoginPage>();
            iobjectContainer = CoreContainerConfig.SetAppContainer(iobjectContainer);

        }
    }
}
