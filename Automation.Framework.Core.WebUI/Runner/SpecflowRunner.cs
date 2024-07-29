using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.DIContainer;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TechTalk.SpecFlow;

namespace Automation.Framework.Core.WebUI.Runner
{
    [Binding]
    public class SpecflowRunner
    {
        public static IServiceProvider _iserviceProvider;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _iserviceProvider = CoreContainerConfig.ConfigureService();

            //DI container creates an instance of GlobalProperties
            _iserviceProvider.GetRequiredService<IGlobalProperties>();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Log.CloseAndFlush();
        }

    }
}
