using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace XBYNUM_C969_Application_Development.Model
{
    public class Patient : Address
    {
        public int patientId { get; set; }
        public string patientName { get; set; }
        public int active { get; set; }
    }
}
