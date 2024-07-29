using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.Runner;
using BoDi;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.Hooks
{
    [Binding]
    public class SpecflowBase
    {
        IDriver _idriver;

        [BeforeScenario(Order = 2)]
        public void BeforeScenario(IObjectContainer iobjectContainer, ScenarioContext sc, FeatureContext fc)
        {
            // get a driver from DI container
            _idriver = iobjectContainer.Resolve<IDriver>();
        }


        [AfterScenario]
        public void AfterScenario()
        {
            //quit browser after a scenario
            _idriver.CloseBrowser();
        }
    }
}
