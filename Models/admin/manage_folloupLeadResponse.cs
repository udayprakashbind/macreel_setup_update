using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace macreel_setup.Models.admin
{
    public class manage_folloupLeadResponse
    {
        public string id { get; set; }
        public string AgentId  { get; set; }
        public string LeadId { get; set; }
        public string response { get; set; }
        public string current_date { get; set; }
        public string nextfollow_up_date { get; set; }
        public string status { get; set; }

    }
}