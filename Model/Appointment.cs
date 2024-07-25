using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using XBYNUM_C969_Application_Development.Model;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace XBYNUM_C969_Application_Development
{
    public class Appointment : Patient
    {
        public int appointmentId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string contact { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }

    }
}
