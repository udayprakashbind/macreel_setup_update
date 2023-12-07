using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace macreel_setup.Models.admin
{
    public class manage_pi
    {
        public string id { get; set; }
        public string PINo { get; set; }
        public string OrderNo { get; set; }
        public string QuotationReference { get; set; }
        public string LeadReference { get; set; }
        public string Employee { get; set; }
        public string Branch { get; set; }
        public string SelectBillTO { get; set; }
        public string Date { get; set; }
        public string SelectShipTO { get; set; }
        public string Add_PORNo { get; set; }
        public string LANID { get; set; }
        public string PromoCode { get; set; }
        public string DomainID { get; set; }
        public string RenewalStatus { get; set; }
        public string RenewalPeriod { get; set; }
        public string RenewalEndDate { get; set; }
        public string RenewalCount { get; set; }
        public string BillingStatus { get; set; }
        public string BillingPeriod { get; set; }
        public string BillingEndDate { get; set; }
        public string BillingCount { get; set; }
        public string InState_OutState { get; set; }
        public string Tax { get; set; }
        public string TAXAmount { get; set; }
        public string PriceBeforeTAX { get; set; }
        public string PriceAfterTAX { get; set; }
        public string SaleGeneratedDate { get; set; }
    }
}