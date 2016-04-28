using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerLog 
{
    class ConfigUpdate
    {
       private static ConfigUpdate obj;
        private ConfigUpdate()
        { 
        }
        public static ConfigUpdate File
        {
            get
            {
                if(obj==null)
                {
                    obj = new ConfigUpdate();
                }
                return obj;
            }
        }

        public void SetSetting(string key, string value)
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified, true);
            config.SaveAs(@"C:\Users\Muhammad_Usman\Documents\Visual Studio 2015\Projects\VP-projects2016\SerLog\SerLog\App.config", ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");


        }
        public string GetSetting(string key)
        {
            ConfigurationManager.RefreshSection("appSettings");
            return ConfigurationManager.AppSettings[key];

        }

    }
}
