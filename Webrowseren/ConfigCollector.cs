using System;
using System.Configuration;

namespace Webrowseren
{
    /// <summary>
    /// ConfigCollector class has the purpose of collecting the data from App.config file
    /// </summary>
    public class ConfigCollector
    {
        /// <summary>
        /// method GetWebPage
        /// </summary>
        /// <returns>webPage</returns>
        public string GetWebPage()
        {
            return ConfigurationSettings.AppSettings["webPage"];
        }
        
        /// <summary>
        /// method GetWithOutHtml returns the boolean value of withoutHtml value.
        /// </summary>
        /// <returns>withoutHtml</returns>
        public Boolean GetWithOutHtml()
        {
            return Convert.ToBoolean(ConfigurationSettings.AppSettings["withoutHtml"]);
        }
    }
}

