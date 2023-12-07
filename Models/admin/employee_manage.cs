using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace macreel_setup.Models.admin
{
    public class employee_manage
    {
        public string id { get; set; }
        public string employee_branch { get; set; }
        public string employee_type { get; set; }
        public string employee_designation { get; set; }
        public string employee_id { get; set; }
        public string login_userid { get; set; }
        public string password { get; set; }
        public string employee_first_name { get; set; }
        public string employee_last_name { get; set; }
        public string mobile_no { get; set; }
        public string phone_no { get; set; }
        public string gender { get; set; }
        public string alternate_number { get; set; }
        public string dob { get; set; }
        public string join_date { get; set; }
        public string salary_ctc { get; set; }
        public string qualification { get; set; }
        public string aadhar_no { get; set; }
        public string pan_no { get; set; }
        public string profile_picture { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string area_code { get; set; }
        public string address { get; set; }
        public string employee_department { get; set; }
        public string reporting_manager { get; set; }
        public string reporting_tl { get; set; }
        public string exit_date { get; set; }
        public string current_status { get; set; }
        public HttpPostedFileBase fileupload { get; set; }

        public List<manage_branch> manage_branch { get; set; }
        public List<reporting_manger_list> reporting_manger_list { get; set; }
        public List<reportingTL_list> reportingTL_list { get; set; }
    }

    public class countrylist
    {
        public string cName { get; set; }
        public string id { get; set; }
        public string iso { get; set; }

        public string countryid { get; set; }
    }

    public class reporting_manger_list
    {
        public string name { get; set; }
        public string id { get; set; }
        public string employee_id { get; set; }

    }

    public class reportingTL_list
    {
        public string name { get; set; }
        public string id { get; set; }
        public string employee_id { get; set; }
    }
}