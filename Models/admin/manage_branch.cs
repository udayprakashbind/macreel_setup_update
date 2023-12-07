using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace macreel_setup.Models.admin
{
    public class manage_branch
    {
        public string id { get; set; }
        public string BranchName { get; set; }
        public string BranchEmail { get; set; }
        public string ContactPerson { get; set; }
        public string LandLineNo { get; set; }
        public string ContactPersonMobile { get; set; }
        public string ContactPersonEmail { get; set; }
        public string GSTNo { get; set; }
        public string PanNo { get; set; }
        public string BranchRegistrationNo { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public string PinCode { get; set; }
        public string RegistrationDate { get; set; }
        public string BranchAddress { get; set; }
    }
}