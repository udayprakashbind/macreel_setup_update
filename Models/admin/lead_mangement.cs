using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace macreel_setup.Models.admin
{
    public class lead_mangement
    {
        public string id { get; set; }
        public string LeadID { get; set; }
        public string LeadSegment { get; set; }
        public string Branch { get; set; }
        public string Client { get; set; }
        public string ContactPerson { get; set; }
        public string ContactDesignation { get; set; }
        public string ContactEmail { get; set; }
        public string ContactMobileNumber { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string City { get; set; }
        public string PIN { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ClientSegment { get; set; }
        public string ClientTurnover { get; set; }
        public string ClientPCsOrNoOfEmployee { get; set; }
        public string ExpectedAnnualBusiness { get; set; }
        public string ProductRequired { get; set; }
        public string ProductDescription { get; set; }
        public string ProductQuantity { get; set; }
        public string ServiceRequired { get; set; }
        public string ServicesDescription { get; set; }
        public string EstimatedLeadValue { get; set; }
        public string LeadGeneratedBy { get; set; }
        public string LeadGeneratedByType { get; set; }
        public string LeadGenerationDate { get; set; }
        public string LeadAssignedTo { get; set; }
        public string LeadStatus { get; set; }
        public string employee_first_name { get; set; }
        public List<countrylist> countrylist { get; set; }
        public List<employe_list> employe_list { get; set; }
    }

    public class employe_list
    {
        public string name { get; set; }
        public string id { get; set; }
        public string employee_id { get; set; }

    }
}