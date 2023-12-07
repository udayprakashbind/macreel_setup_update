using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace macreel_setup.Models.admin
{
    public class manage_leadsheet
    {
        public string id { get; set; } 
        public string client_name { get; set; }
        public string contact_no { get; set; }
        public string eMAIL_ID { get; set;}
        public string address { get; set; }
        public string uploadedby { get; set; }
        public string uploadedbytype { get; set; }
        public string generateStatus { get; set; }
        public string assignStatus { get; set; }
        public HttpPostedFileBase fileupload1 { get; set; }
    }
    public class agentlist
    {
        public string agentId { get; set; }
        public string agentName { get; set;}
    }

    public class assignLead
    {
        public string id { get; set; }
        public string assignBy_Id { get; set; }
        public string reAssignTo { get; set; }
        public string agentId { get; set; }

        public string  AssignLead_Id { get; set; }
        public int leadId { get; set; }
        public string assignStatus { get; set; }
        public string rpmId { get; set; }
        public string uploadedby { get; set; }
        public string uplodedbytype { get; set; }
    }
}