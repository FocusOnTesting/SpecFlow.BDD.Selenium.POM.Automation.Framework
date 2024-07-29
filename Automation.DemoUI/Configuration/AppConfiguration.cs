using Automation.DemoUI.WebAbstraction;
using Automation.Framework.Core.WebUI.Abstraction;
using Automation.Framework.Core.WebUI.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;


namespace Automation.DemoUI.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        IConfiguration _iconfiguration;
        public AppConfiguration()
        {
            IDefaultVariables idefaultVariables = SpecflowRunner._iserviceProvider.GetRequiredService<IDefaultVariables>();
            _iconfiguration = new ConfigurationBuilder().AddJsonFile(idefaultVariables.getAppplicationConfigjson).Build();
        }

        public string GetConfiguration(string key)
        {
            return _iconfiguration[key];
        }
    }
}
