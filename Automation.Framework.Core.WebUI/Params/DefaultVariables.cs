﻿using Automation.Framework.Core.WebUI.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Params
{
    public class DefaultVariables : IDefaultVariables
    {
        // create Report folder end with timestamp and get Report folder directory 
        public string getReport
        {
            get
            {
                return System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName
                    + "\\Results\\Report "
                    + DateTime.Now.ToString("yyyyMMdd HHmmss");
            }
        }

        //get log.txt directory
        public string getLog
        {
            get
            {
                return getReport + "\\log.txt";
            }
        }

        //get applicationConfig.json directory
        public string getAppplicationConfigjson
        {
            get
            {
                return System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName
                    + "\\Resources\\applicationConfig.json";
            }
        }

        //get frameworkSetting.json directory
        public string getframeworkSettingjson
        {
            get
            {
                return System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName
                    + "\\Resources\\frameworkSettings.json";
            }
        }

        //get DataSet folder directory
        public string dataSetLocation
        {
            get
            {
                return System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName
                    + "\\DataSet";
            }
        }

        //get HTML report directory
        public string getExtentReport
        {
            get
            {
                return getReport + "\\index.html";
            }
        }
    }
}
