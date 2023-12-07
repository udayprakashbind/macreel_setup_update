using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace macreel_setup.Models.admin
{
    public class manage_subadmin
    {
        public string id { get; set; }
        public string SubAdminName { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string SubAdminBranch { get; set; }
        public string Gender { get; set; }
        public string Designation { get; set; }
        public string DOB { get; set; }
        public string JoinDate { get; set; }
        public string Salary { get; set; }
        public string Qualification { get; set; }
        public string AadharNo { get; set; }
        public string PanNo { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public string Pincode { get; set; }
        public string Address { get; set; }
        public string File_Name { get; set; }
        public string File_Path { get; set; }
        public HttpPostedFileBase fileupload1 { get; set; }
    }
}