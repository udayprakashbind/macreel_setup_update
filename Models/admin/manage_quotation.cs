using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace macreel_setup.Models.admin
{
    public class manage_quotation
    {
        public string id { get; set; }
        public string Quotation_No { get; set; }
        public string Lead_Reference { get; set; }
        public string Client_Name { get; set; }
        public string Contact_Person_No { get; set; }
        public string Email { get; set; }
        public string Company_Number { get; set; }
        public string Address { get; set; }
        public string Employee { get; set; }
        public string Branch { get; set; }
        public string Select_Bill_TO { get; set; }
        public string Date { get; set; }
        public string Select_Ship_TO { get; set; }
        public string Add_PORNo { get; set; }
        public string LAN_ID { get; set; }
        public string PromoCode { get; set; }
        public string DomainID { get; set; }
        public string InState_OutState { get; set; }
        public string Tax { get; set; }
        public string TAX_Amount { get; set; }
        public string Price_Before_TAX { get; set; }
        public string Price_After_TAX { get; set; }
        public string Generated_Date { get; set; }
        public string GeneratedBy { get; set; }
    }
}