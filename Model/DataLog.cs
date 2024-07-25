using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBYNUM_C969_Application_Development.Controller;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace XBYNUM_C969_Application_Development.Model
{
    public abstract class DataLog
    {
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }
    }
}
