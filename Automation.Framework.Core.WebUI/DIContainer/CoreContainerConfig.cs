using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.DriverContext;
using Automation.Framework.Core.WebUI.Params;
using Automation.Framework.Core.WebUI.Reports;
using Automation.Framework.Core.WebUI.Selenium.LocalWebDrivers;
using Automation.Framework.Core.WebUI.Selenium.WebDrivers;
using Automation.Framework.Core.WebUI.WebElements;
using BoDi;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.DIContainer
{
    public class CoreContainerConfig
    {
        public static IServiceProvider ConfigureService()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IDefaultVariables, DefaultVariables>();
            serviceCollection.AddSingleton<ILogging, Logging>();
            serviceCollection.AddSingleton<IGlobalProperties, GlobalProperties>();

            return serviceCollection.BuildServiceProvider();
        }

        //In CoreContainerConfig set AppContainerConfig
        public static IObjectContainer SetAppContainer(IObjectContainer iobjectContainer)
        {
            iobjectContainer.RegisterTypeAs<ChromeWebDriver, IChromeWebDriver>();
            iobjectContainer.RegisterTypeAs<FirefoxWebDriver, IFirefoxWebDriver>();
            iobjectContainer.RegisterTypeAs<Driver, IDriver>();
            iobjectContainer.RegisterTypeAs<AtBy, IAtBy>();
            iobjectContainer.RegisterTypeAs<AtWebElement, IAtWebElement>();
            return iobjectContainer;
        }
    }
}
