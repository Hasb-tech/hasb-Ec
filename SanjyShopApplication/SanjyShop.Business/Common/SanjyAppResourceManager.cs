using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SanjyShop.Business.Common
{
 
    static public class SanjyAppResourceManager
    {
        private static readonly ResourceManager ApplicationResourceManager;

        static SanjyAppResourceManager()
        {
            ApplicationResourceManager = new ResourceManager("SanjyShop.Business.Common.ApplicationResources", Assembly.GetExecutingAssembly());
        }

        static public string GetApplicationString(string code)
        {
            return ApplicationResourceManager.GetString(code);
        }
    }
}
