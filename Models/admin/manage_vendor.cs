using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace macreel_setup.Models.admin
{
    public class manage_vendor
    {
        public string id { get; set; }
        public string VendoreName { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNO { get; set; }
        public string EmailId { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public string Pincode { get; set; }
        public string GSTNo { get; set; }
        public string PanNo { get; set; }
        public string Address { get; set; }
    }
}