using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace macreel_setup.Models
{
    public class login
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string url { get; set; }
        public Boolean success { get; set; }

    }

    public class admininfo
    {
        public string name { get; set; }
        public string des { get; set; }
        public string ip_address { get; set; }
        public string logintime { get; set; }
        public string agencyid { get; set; }
    }
}