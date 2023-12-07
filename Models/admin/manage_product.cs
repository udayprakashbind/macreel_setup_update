using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace macreel_setup.Models.admin
{
    public class manage_product
    {
        public string id { get; set; }
        public string ProductName { get; set; }
        public string OEM { get; set; }
        public string licenceNo { get; set; }
        public string PartNo { get; set; }
        public string Price { get; set; }
        public string HSNNo { get; set; }
        public string AMCPrice { get; set; }
        public string Description { get; set; }
        public string File_Path { get; set; }
        public string File_Name { get; set; }
        public HttpPostedFileBase fileupload1 { get; set; }
    }
}