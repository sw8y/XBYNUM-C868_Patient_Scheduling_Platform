using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace XBYNUM_C969_Application_Development.Model
{
    public class User : DataLog
    {
        public static int userId { get; set; }
        public static string username { get; set; }
        public static string password { get; set; }
        public static string location { get; set; }
        public static string IP { get; set; }

    }

    public class UserLocationData
    {
        public string ip { get; set; }
        public string region_name { get; set; }
        public string country_name { get; set; }

    }
}
