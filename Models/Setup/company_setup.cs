using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace macreel_setup.Models.Setup
{
    public class company_setup
    {
        public int id { get; set; }
        public string comp_name { get; set; }
        public string address { get; set; }
        public string logo { get; set; }
        public string admin_userid { get; set; }
        public string subs_startdate { get; set; }
        public string subs_enddate { get; set; }
        public string admin_name { get; set; }
        public string contact_no { get; set; }
        public string email { get; set; }
        public string gst_no { get; set; }
        public string user_allowed { get; set; }
        public string software_price { get; set; }
        public string gst_price { get; set; }
        public string total { get; set; }
        public string amc_price { get; set; }
        public string amc_startdate { get; set; }
        public string amc_enddate { get; set; }
        public string support { get; set; }
        public string domain { get; set; }
        public string domain_name { get; set; }
        public string domain_price { get; set; }
        public string domain_renewal_date { get; set; }
        public string server { get; set; }
        public string server_name { get; set; }
        public string server_price { get; set; }
        public string server_renewal_date { get; set; }
        public HttpPostedFileBase fileupload { get; set; }
    }
}