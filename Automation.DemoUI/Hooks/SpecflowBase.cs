﻿using Automation.Framework.Core.WebUI.Abstraction;
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
            IExtentReport extentReport = (IExtentReport)fc["iextentReport"];
            extentReport.CreateScenario(sc.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterSteps(ScenarioContext sc, FeatureContext fc)
        {
            IExtentReport extentReport = (IExtentReport)fc["iextentReport"];
            if (sc.TestError != null)
            {
                extentReport.Fail(sc.StepContext.StepInfo.Text);
            }
            else
            {
                IGlobalProperties iglobalProperties = SpecflowRunner._iserviceProvider.GetRequiredService<IGlobalProperties>();
                extentReport.Pass(sc.StepContext.StepInfo.Text);
            }
        }


        [AfterScenario]
        public void AfterScenario()
        {
            //flush HTML reports to loacl device
            IExtentFeatureReport extentFeatureReport = SpecflowRunner._iserviceProvider.GetRequiredService<IExtentFeatureReport>();
            extentFeatureReport.FlushExtent();
            //quit browser after a scenario
            _idriver.CloseBrowser();
        }
    }
}
