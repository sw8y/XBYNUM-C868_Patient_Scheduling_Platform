using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBYNUM_C969_Application_Development.Model
{
    public class Address : City
    {
        public int addressId {  get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string postalCode { get; set; }
        public string phone { get; set; }

    }
}
