using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace macreel_setup.Models.admin    
{
    public class manage_po
    {
        public string id { get; set; }
        public string PO_Number { get; set; }
        public string Vendor_Id { get; set; }
        public string Client_ID { get; set; }
        public string PO_Date { get; set; }
        public string Manager { get; set; }
        public string Vendor_Email { get; set; }
        public string LAN { get; set; }
        public string PromoCode { get; set; }
        public string SDF_Order { get; set; }
        public string MS_Account_Manager { get; set; }
        public string Payment_InDays { get; set; }
        public string Delivery_In_Days { get; set; }
        public string Delivery_Mode { get; set; }
        public string MPN_ID { get; set; }
        public string AEP_Authorization_No { get; set; }
        public string DomainID { get; set; }
        public string CDC_Discount { get; set; }
        public string CDC_Discount_Amount { get; set; }
        public string After_Discount_Amount { get; set; }
        public string IGST_Tax { get; set; }
        public string Tax_Amount { get; set; }
        public string After_Tax_Amount { get; set; }
        public string CN { get; set; }
        public string CN_Amount { get; set; }
        public string Grand_Total_Amount { get; set; }
        public string Purchase_Amount { get; set; }
        public string Total_Sales_Amount { get; set; }
        public string PL_Amount { get; set; }
    }
}