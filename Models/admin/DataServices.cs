using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace macreel_setup.Models.admin
{
    public class DataServices
    {
        public SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);



        #region manage subadmin
        public bool insert_subadmin(macreel_setup.Models.admin.manage_subadmin subadmin)
        {
            SqlCommand cmd = new SqlCommand("sp_SubAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SubAdminName", subadmin.SubAdminName);
            cmd.Parameters.AddWithValue("@Password", subadmin.Password);
            cmd.Parameters.AddWithValue("@MobileNo", subadmin.MobileNo);
            cmd.Parameters.AddWithValue("@SubAdminBranch", subadmin.SubAdminBranch);
            cmd.Parameters.AddWithValue("@Gender", subadmin.Gender);
            cmd.Parameters.AddWithValue("@Designation", subadmin.Designation);
            cmd.Parameters.AddWithValue("@DOB", subadmin.DOB);
            cmd.Parameters.AddWithValue("@JoinDate", subadmin.JoinDate);
            cmd.Parameters.AddWithValue("@Salary", subadmin.Salary);
            cmd.Parameters.AddWithValue("@Qualification", subadmin.Qualification);
            cmd.Parameters.AddWithValue("@AadharNo", subadmin.AadharNo);
            cmd.Parameters.AddWithValue("@PanNo", subadmin.PanNo);
            cmd.Parameters.AddWithValue("@StateName", subadmin.StateName);
            cmd.Parameters.AddWithValue("@StateCode", subadmin.StateCode);
            cmd.Parameters.AddWithValue("@CityName", subadmin.CityName);
            cmd.Parameters.AddWithValue("@CityCode", subadmin.CityCode);
            cmd.Parameters.AddWithValue("@Pincode", subadmin.Pincode);
            cmd.Parameters.AddWithValue("@Address", subadmin.Address);
            cmd.Parameters.AddWithValue("@File_Name", subadmin.File_Name);
            cmd.Parameters.AddWithValue("@File_Path", subadmin.File_Path);
            cmd.Parameters.AddWithValue("@Id", subadmin.id);
            if (subadmin.id != null && subadmin.id != "")
            {
                cmd.Parameters.AddWithValue("@Action", "updatesubadmin");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Action", "insert_subadmin");

            }
            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public List<manage_subadmin> getsubadminlist()
        {
            List<manage_subadmin> subadmins = new List<manage_subadmin>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_SubAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getsubadminlist");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_subadmin sub = new manage_subadmin();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    sub = new manage_subadmin();
                    sub.id = sdr["Id"].ToString();
                    sub.SubAdminName = sdr["SubAdminName"].ToString();
                    sub.Password = sdr["Password"].ToString();
                    sub.MobileNo = sdr["MobileNo"].ToString();
                    sub.SubAdminBranch = sdr["SubAdminBranch"].ToString();
                    sub.Gender = sdr["Gender"].ToString();
                    sub.Designation = sdr["Designation"].ToString();
                    sub.DOB = sdr["DOB"].ToString();
                    sub.JoinDate = sdr["JoinDate"].ToString();
                    sub.Salary = sdr["Salary"].ToString();
                    sub.Qualification = sdr["Qualification"].ToString();
                    sub.AadharNo = sdr["AadharNo"].ToString();
                    sub.PanNo = sdr["PanNo"].ToString();
                    sub.StateName = sdr["StateName"].ToString();
                    sub.StateCode = sdr["StateCode"].ToString();
                    sub.CityName = sdr["CityName"].ToString();
                    sub.CityCode = sdr["CityCode"].ToString();
                    sub.Pincode = sdr["Pincode"].ToString();
                    sub.Address = sdr["Address"].ToString();
                    sub.File_Name = sdr["File_Name"].ToString();
                    sub.File_Path = sdr["File_Path"].ToString();
                    subadmins.Add(sub);
                }

            }
            con.Close();
            return subadmins;
        }

        public manage_subadmin getsubadminById(string id)
        {
            manage_subadmin sub = new manage_subadmin();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_SubAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getsubadminbyId");
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                sub.id = sdr["Id"].ToString();
                sub.SubAdminName = sdr["SubAdminName"].ToString();
                sub.Password = sdr["Password"].ToString();
                sub.MobileNo = sdr["MobileNo"].ToString();
                sub.SubAdminBranch = sdr["SubAdminBranch"].ToString();
                sub.Gender = sdr["Gender"].ToString();
                sub.Designation = sdr["Designation"].ToString();
                sub.DOB = sdr["DOB"].ToString();
                sub.JoinDate = sdr["JoinDate"].ToString();
                sub.Salary = sdr["Salary"].ToString();
                sub.Qualification = sdr["Qualification"].ToString();
                sub.AadharNo = sdr["AadharNo"].ToString();
                sub.PanNo = sdr["PanNo"].ToString();
                sub.StateName = sdr["StateName"].ToString();
                sub.StateCode = sdr["StateCode"].ToString();
                sub.CityName = sdr["CityName"].ToString();
                sub.CityCode = sdr["CityCode"].ToString();
                sub.Pincode = sdr["Pincode"].ToString();
                sub.Address = sdr["Address"].ToString();
                sub.File_Name = sdr["File_Name"].ToString();
                sub.File_Path = sdr["File_Path"].ToString();
            }
            sdr.Close();
            con.Close();
            return sub;
        }
        public bool delete_subadmin(string id)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("sp_SubAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "deletesubadmin");
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        #endregion

        #region manage sequence No
        public bool insert_sequence(macreel_setup.Models.admin.manage_sequence sequence)
        {
            SqlCommand cmd = new SqlCommand("sp_SequenceNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Branch", sequence.Branch);
            cmd.Parameters.AddWithValue("@QuotationPrefixNo", sequence.QuotationPrefixNo);
            cmd.Parameters.AddWithValue("@QuotationNo", sequence.QuotationNo);
            cmd.Parameters.AddWithValue("@SaleBookPrefixNo", sequence.SaleBookPrefixNo);
            cmd.Parameters.AddWithValue("@SaleBookNo", sequence.SaleBookNo);
            cmd.Parameters.AddWithValue("@PIPrefixNo", sequence.PIPrefixNo);
            cmd.Parameters.AddWithValue("@PINo", sequence.PINo);
            cmd.Parameters.AddWithValue("@POPrefixNo", sequence.POPrefixNo);
            cmd.Parameters.AddWithValue("@PONo", sequence.PONo);
            cmd.Parameters.AddWithValue("@InvoicePrefixNo", sequence.InvoicePrefixNo);
            cmd.Parameters.AddWithValue("@InvoiceNo", sequence.InvoiceNo);
            cmd.Parameters.AddWithValue("@Id", sequence.id);
            if (sequence.id != null && sequence.id != "")
            {
                cmd.Parameters.AddWithValue("@Action", "updatesequence");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Action", "insert_sequenceNo");
            }
            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<manage_sequence> get_sequence_list()
        {
            List<manage_sequence> sequences = new List<manage_sequence>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_SequenceNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getAllsequenceno");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_sequence seq = new manage_sequence();
            while (sdr.Read())
            {
                seq = new manage_sequence();
                seq.id = sdr["Id"].ToString();
                seq.Branch = sdr["Branch"].ToString();
                seq.QuotationPrefixNo = sdr["QuotationPrefixNo"].ToString();
                seq.QuotationNo = sdr["QuotationNo"].ToString();
                seq.SaleBookPrefixNo = sdr["SaleBookPrefixNo"].ToString();
                seq.SaleBookNo = sdr["SaleBookNo"].ToString();
                seq.PIPrefixNo = sdr["PIPrefixNo"].ToString();
                seq.PINo = sdr["PINo"].ToString();
                seq.POPrefixNo = sdr["POPrefixNo"].ToString();
                seq.PONo = sdr["PONo"].ToString();
                seq.InvoicePrefixNo = sdr["InvoicePrefixNo"].ToString();
                seq.InvoiceNo = sdr["InvoiceNo"].ToString();
                sequences.Add(seq);
            }
            con.Close();
            return sequences;

        }

        public manage_sequence getsequenceById(string id)
        {
            manage_sequence seq = new manage_sequence();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_SequenceNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getsequencebyId");
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                seq.id = sdr["Id"].ToString();
                seq.Branch = sdr["Branch"].ToString();
                seq.QuotationPrefixNo = sdr["QuotationPrefixNo"].ToString();
                seq.QuotationNo = sdr["QuotationNo"].ToString();
                seq.SaleBookPrefixNo = sdr["SaleBookPrefixNo"].ToString();
                seq.SaleBookNo = sdr["SaleBookNo"].ToString();
                seq.PIPrefixNo = sdr["PIPrefixNo"].ToString();
                seq.PINo = sdr["PINo"].ToString();
                seq.POPrefixNo = sdr["POPrefixNo"].ToString();
                seq.PONo = sdr["PONo"].ToString();
                seq.InvoicePrefixNo = sdr["InvoicePrefixNo"].ToString();
                seq.InvoiceNo = sdr["InvoiceNo"].ToString();
            }
            sdr.Close();
            con.Close();
            return seq;
        }

        public bool delete_sequence(string id)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("sp_SequenceNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "deletesequence");
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region manage product master

        public bool insert_product(macreel_setup.Models.admin.manage_product products)
        {
            SqlCommand cmd = new SqlCommand("sp_ProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", products.id);
            cmd.Parameters.AddWithValue("@ProductName", products.ProductName);
            cmd.Parameters.AddWithValue("@OEM", products.OEM);
            cmd.Parameters.AddWithValue("@licenceNo", products.licenceNo);
            cmd.Parameters.AddWithValue("@PartNo", products.PartNo);
            cmd.Parameters.AddWithValue("@Price", products.Price);
            cmd.Parameters.AddWithValue("@HSNNo", products.HSNNo);
            cmd.Parameters.AddWithValue("@AMCPrice", products.AMCPrice);
            cmd.Parameters.AddWithValue("@Description", products.Description);
            cmd.Parameters.AddWithValue("@File_Path", products.File_Path);
            cmd.Parameters.AddWithValue("@File_Name", products.File_Name);
            if (products.id != null && products.id != "")
            {
                cmd.Parameters.AddWithValue("@Action", "updateproductbyId");

            }
            else
            {
                cmd.Parameters.AddWithValue("@Action", "insert_product");

            }
            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<manage_product> getproductlist()
        {
            List<manage_product> products = new List<manage_product>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getAllproduct");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_product pro = new manage_product();
            while (sdr.Read())
            {
                pro = new manage_product();
                pro.id = sdr["Id"].ToString();
                pro.ProductName = sdr["ProductName"].ToString();
                pro.OEM = sdr["OEM"].ToString();
                pro.licenceNo = sdr["licenceNo"].ToString();
                pro.PartNo = sdr["PartNo"].ToString();
                pro.Price = sdr["Price"].ToString();
                pro.HSNNo = sdr["HSNNo"].ToString();
                pro.AMCPrice = sdr["AMCPrice"].ToString();
                pro.Description = sdr["Description"].ToString();
                pro.File_Path = sdr["File_Path"].ToString();
                pro.File_Name = sdr["File_Name"].ToString();
                products.Add(pro);
            }
            con.Close();
            return products;
        }

        public manage_product getproductbyId(string id)
        {
            manage_product pro = new manage_product();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getproductById");
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                pro.id = sdr["Id"].ToString();
                pro.ProductName = sdr["ProductName"].ToString();
                pro.OEM = sdr["OEM"].ToString();
                pro.licenceNo = sdr["licenceNo"].ToString();
                pro.PartNo = sdr["PartNo"].ToString();
                pro.Price = sdr["Price"].ToString();
                pro.HSNNo = sdr["HSNNo"].ToString();
                pro.AMCPrice = sdr["AMCPrice"].ToString();
                pro.Description = sdr["Description"].ToString();
                pro.File_Path = sdr["File_Path"].ToString();
                pro.File_Name = sdr["File_Name"].ToString();
            }
            sdr.Close();
            con.Close();
            return pro;
        }

        public bool delete_product(string id)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("sp_ProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "deleteproductbyId");
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region manage vendor master

        public bool insert_vendor(macreel_setup.Models.admin.manage_vendor vendor)
        {
            SqlCommand cmd = new SqlCommand("sp_VendorMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", vendor.id);
            cmd.Parameters.AddWithValue("@VendoreName", vendor.VendoreName);
            cmd.Parameters.AddWithValue("@ContactPerson", vendor.ContactPerson);
            cmd.Parameters.AddWithValue("@ContactNO", vendor.ContactNO);
            cmd.Parameters.AddWithValue("@EmailId", vendor.EmailId);
            cmd.Parameters.AddWithValue("@StateName", vendor.StateName);
            cmd.Parameters.AddWithValue("@StateCode", vendor.StateCode);
            cmd.Parameters.AddWithValue("@CityName", vendor.CityName);
            cmd.Parameters.AddWithValue("@CityCode", vendor.CityCode);
            cmd.Parameters.AddWithValue("@Pincode", vendor.Pincode);
            cmd.Parameters.AddWithValue("@GSTNo", vendor.GSTNo);
            cmd.Parameters.AddWithValue("@PanNo", vendor.PanNo);
            cmd.Parameters.AddWithValue("@Address", vendor.Address);
            if (vendor.id != null && vendor.id != "")
            {
                cmd.Parameters.AddWithValue("@Action", "updateVendorbyId");

            }
            else
            {
                cmd.Parameters.AddWithValue("@Action", "insert_Vendor");

            }

            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<manage_vendor> getvendorlist()
        {
            List<manage_vendor> vendors = new List<manage_vendor>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_VendorMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getAllVendor");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_vendor ven = new manage_vendor();
            if (sdr.Read())
            {
                while (sdr.Read())
                {
                    ven = new manage_vendor();
                    ven.id = sdr["Id"].ToString();
                    ven.VendoreName = sdr["VendoreName"].ToString();
                    ven.ContactPerson = sdr["ContactPerson"].ToString();
                    ven.ContactNO = sdr["ContactNO"].ToString();
                    ven.EmailId = sdr["EmailId"].ToString();
                    ven.StateName = sdr["StateName"].ToString();
                    ven.StateCode = sdr["StateCode"].ToString();
                    ven.CityName = sdr["CityName"].ToString();
                    ven.CityCode = sdr["CityCode"].ToString();
                    ven.Pincode = sdr["Pincode"].ToString();
                    ven.GSTNo = sdr["GSTNo"].ToString();
                    ven.PanNo = sdr["PanNo"].ToString();
                    ven.Address = sdr["Address"].ToString();
                    vendors.Add(ven);
                }
            }
            sdr.Close();
            con.Close();
            return vendors;
        }

        public manage_vendor getvendorById(string id)
        {
            manage_vendor ven = new manage_vendor();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_VendorMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getVendorbyId");
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();

                ven.id = sdr["Id"].ToString();
                ven.VendoreName = sdr["VendoreName"].ToString();
                ven.ContactPerson = sdr["ContactPerson"].ToString();
                ven.ContactNO = sdr["ContactNO"].ToString();
                ven.EmailId = sdr["EmailId"].ToString();
                ven.StateName = sdr["StateName"].ToString();
                ven.StateCode = sdr["StateCode"].ToString();
                ven.CityName = sdr["CityName"].ToString();
                ven.CityCode = sdr["CityCode"].ToString();
                ven.Pincode = sdr["Pincode"].ToString();
                ven.GSTNo = sdr["GSTNo"].ToString();
                ven.PanNo = sdr["PanNo"].ToString();
                ven.Address = sdr["Address"].ToString();
            }
            con.Close();
            return ven;
        }

        public bool delete_vendor(string id)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("sp_VendorMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "deleteVendorbyId");
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region manage sale book
        public bool insert_salebook(macreel_setup.Models.admin.manage_salebook salebook)
        {
            SqlCommand cmd = new SqlCommand("sp_SaleBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", salebook.id);
            cmd.Parameters.AddWithValue("@OrderNo", salebook.OrderNo);
            cmd.Parameters.AddWithValue("@QuotationReference", salebook.QuotationReference);
            cmd.Parameters.AddWithValue("@LeadReference", salebook.LeadReference);
            cmd.Parameters.AddWithValue("@Employee", salebook.Employee);
            cmd.Parameters.AddWithValue("@Branch", salebook.Branch);
            cmd.Parameters.AddWithValue("@SelectBillTO", salebook.SelectBillTO);
            cmd.Parameters.AddWithValue("@Date", salebook.Date);
            cmd.Parameters.AddWithValue("@SelectShipTO", salebook.SelectShipTO);
            cmd.Parameters.AddWithValue("@Add_PORNo", salebook.Add_PORNo);
            cmd.Parameters.AddWithValue("@LANID", salebook.LANID);
            cmd.Parameters.AddWithValue("@PromoCode", salebook.PromoCode);
            cmd.Parameters.AddWithValue("@DomainID", salebook.DomainID);
            cmd.Parameters.AddWithValue("@RenewalStatus", salebook.RenewalStatus);
            cmd.Parameters.AddWithValue("@RenewalPeriod", salebook.RenewalPeriod);
            cmd.Parameters.AddWithValue("@RenewalEndDate", salebook.RenewalEndDate);
            cmd.Parameters.AddWithValue("@RenewalCount", salebook.RenewalCount);
            cmd.Parameters.AddWithValue("@BillingStatus", salebook.BillingStatus);
            cmd.Parameters.AddWithValue("@BillingPeriod", salebook.BillingPeriod);
            cmd.Parameters.AddWithValue("@BillingEndDate", salebook.BillingEndDate);
            cmd.Parameters.AddWithValue("@BillingCount", salebook.BillingCount);
            cmd.Parameters.AddWithValue("@InState_OutState", salebook.InState_OutState);
            cmd.Parameters.AddWithValue("@Tax", salebook.Tax);
            cmd.Parameters.AddWithValue("@TAXAmount", salebook.TAXAmount);
            cmd.Parameters.AddWithValue("@PriceBeforeTAX", salebook.PriceBeforeTAX);
            cmd.Parameters.AddWithValue("@PriceAfterTAX", salebook.PriceAfterTAX);
            cmd.Parameters.AddWithValue("@SaleGeneratedDate", salebook.SaleGeneratedDate);

            if (salebook.id != null && salebook.id != "")
            {
                cmd.Parameters.AddWithValue("@Action", "updateSaleBookbyId");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Action", "insert_SaleBook");

            }

            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<manage_salebook> getsalebooklist()
        {
            List<manage_salebook> salebooks = new List<manage_salebook>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_SaleBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getAllSaleBook");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_salebook book = new manage_salebook();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    book = new manage_salebook();
                    book.id = sdr["Id"].ToString();
                    book.OrderNo = sdr["OrderNo"].ToString();
                    book.QuotationReference = sdr["QuotationReference"].ToString();
                    book.LeadReference = sdr["LeadReference"].ToString();
                    book.Employee = sdr["Employee"].ToString();
                    book.Branch = sdr["Branch"].ToString();
                    book.SelectBillTO = sdr["SelectBillTO"].ToString();
                    book.Date = sdr["Date"].ToString();
                    book.SelectShipTO = sdr["SelectShipTO"].ToString();
                    book.Add_PORNo = sdr["Add_PORNo"].ToString();
                    book.LANID = sdr["LANID"].ToString();
                    book.PromoCode = sdr["PromoCode"].ToString();
                    book.DomainID = sdr["DomainID"].ToString();
                    book.RenewalStatus = sdr["RenewalStatus"].ToString();
                    book.RenewalPeriod = sdr["RenewalPeriod"].ToString();
                    book.RenewalEndDate = sdr["RenewalEndDate"].ToString();
                    book.RenewalCount = sdr["RenewalCount"].ToString();
                    book.BillingStatus = sdr["BillingStatus"].ToString();
                    book.BillingPeriod = sdr["BillingPeriod"].ToString();
                    book.BillingEndDate = sdr["BillingEndDate"].ToString();
                    book.BillingCount = sdr["BillingCount"].ToString();
                    book.InState_OutState = sdr["InState_OutState"].ToString();
                    book.Tax = sdr["Tax"].ToString();
                    book.TAXAmount = sdr["TAXAmount"].ToString();
                    book.PriceBeforeTAX = sdr["PriceBeforeTAX"].ToString();
                    book.PriceAfterTAX = sdr["PriceAfterTAX"].ToString();
                    book.SaleGeneratedDate = sdr["SaleGeneratedDate"].ToString();
                    book.SaleGeneratedDate = sdr["SaleGeneratedDate"].ToString();
                    salebooks.Add(book);

                }
            }
            sdr.Close();
            con.Close();
            return salebooks;

        }

        public manage_salebook getsalebookbyId(string id)
        {
            manage_salebook book = new manage_salebook();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_SaleBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getSaleBookbyId");
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                book.id = sdr["Id"].ToString();
                book.OrderNo = sdr["OrderNo"].ToString();
                book.QuotationReference = sdr["QuotationReference"].ToString();
                book.LeadReference = sdr["LeadReference"].ToString();
                book.Employee = sdr["Employee"].ToString();
                book.Branch = sdr["Branch"].ToString();
                book.SelectBillTO = sdr["SelectBillTO"].ToString();
                book.Date = sdr["Date"].ToString();
                book.SelectShipTO = sdr["SelectShipTO"].ToString();
                book.Add_PORNo = sdr["Add_PORNo"].ToString();
                book.LANID = sdr["LANID"].ToString();
                book.PromoCode = sdr["PromoCode"].ToString();
                book.DomainID = sdr["DomainID"].ToString();
                book.RenewalStatus = sdr["RenewalStatus"].ToString();
                book.RenewalPeriod = sdr["RenewalPeriod"].ToString();
                book.RenewalEndDate = sdr["RenewalEndDate"].ToString();
                book.RenewalCount = sdr["RenewalCount"].ToString();
                book.BillingStatus = sdr["BillingStatus"].ToString();
                book.BillingPeriod = sdr["BillingPeriod"].ToString();
                book.BillingEndDate = sdr["BillingEndDate"].ToString();
                book.BillingCount = sdr["BillingCount"].ToString();
                book.InState_OutState = sdr["InState_OutState"].ToString();
                book.Tax = sdr["Tax"].ToString();
                book.TAXAmount = sdr["TAXAmount"].ToString();
                book.PriceBeforeTAX = sdr["PriceBeforeTAX"].ToString();
                book.PriceAfterTAX = sdr["PriceAfterTAX"].ToString();
                book.SaleGeneratedDate = sdr["SaleGeneratedDate"].ToString();
                book.SaleGeneratedDate = sdr["SaleGeneratedDate"].ToString();
            }
            con.Close();
            return book;
        }

        public bool delete_salebook(string id)
        {
            if (con.State == ConnectionState.Closed)

                con.Open();
            SqlCommand cmd = new SqlCommand("sp_SaleBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "deleteSaleBookbyId");
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        #region manage PI
        public bool insert_PI(macreel_setup.Models.admin.manage_pi pi)
        {
            SqlCommand cmd = new SqlCommand("sp_PI", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PINo", pi.PINo);
            cmd.Parameters.AddWithValue("@OrderNo", pi.OrderNo);
            cmd.Parameters.AddWithValue("@QuotationReference", pi.QuotationReference);
            cmd.Parameters.AddWithValue("@LeadReference", pi.LeadReference);
            cmd.Parameters.AddWithValue("@Employee", pi.Employee);
            cmd.Parameters.AddWithValue("@Branch", pi.Branch);
            cmd.Parameters.AddWithValue("@SelectBillTO", pi.SelectBillTO);
            cmd.Parameters.AddWithValue("@Date", pi.Date);
            cmd.Parameters.AddWithValue("@SelectShipTO", pi.SelectShipTO);
            cmd.Parameters.AddWithValue("@Add_PORNo", pi.Add_PORNo);
            cmd.Parameters.AddWithValue("@LANID", pi.LANID);
            cmd.Parameters.AddWithValue("@PromoCode", pi.PromoCode);
            cmd.Parameters.AddWithValue("@DomainID", pi.DomainID);
            cmd.Parameters.AddWithValue("@RenewalStatus", pi.RenewalStatus);
            cmd.Parameters.AddWithValue("@RenewalPeriod", pi.RenewalPeriod);
            cmd.Parameters.AddWithValue("@RenewalEndDate", pi.RenewalEndDate);
            cmd.Parameters.AddWithValue("@RenewalCount", pi.RenewalCount);
            cmd.Parameters.AddWithValue("@BillingStatus", pi.BillingStatus);
            cmd.Parameters.AddWithValue("@BillingPeriod", pi.BillingPeriod);
            cmd.Parameters.AddWithValue("@BillingEndDate", pi.BillingEndDate);
            cmd.Parameters.AddWithValue("@BillingCount", pi.BillingCount);
            cmd.Parameters.AddWithValue("@InState_OutState", pi.InState_OutState);
            cmd.Parameters.AddWithValue("@Tax", pi.Tax);
            cmd.Parameters.AddWithValue("@TAXAmount", pi.TAXAmount);
            cmd.Parameters.AddWithValue("@PriceBeforeTAX", pi.PriceBeforeTAX);
            cmd.Parameters.AddWithValue("@PriceAfterTAX", pi.PriceAfterTAX);
            cmd.Parameters.AddWithValue("@SaleGeneratedDate", pi.SaleGeneratedDate);
            cmd.Parameters.AddWithValue("@Id", pi.id);

            if (pi.id != null && pi.id != "")
            {
                cmd.Parameters.AddWithValue("@Action", "updatePIbyId");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Action", "insert_PI");

            }

            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<manage_pi> getPIlist()
        {
            List<manage_pi> pilist = new List<manage_pi>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_PI", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getAllPI");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_pi pi = new manage_pi();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    pi = new manage_pi();
                    pi.id = sdr["Id"].ToString();
                    pi.PINo = sdr["PINo"].ToString();
                    pi.OrderNo = sdr["OrderNo"].ToString();
                    pi.QuotationReference = sdr["QuotationReference"].ToString();
                    pi.LeadReference = sdr["LeadReference"].ToString();
                    pi.Employee = sdr["Employee"].ToString();
                    pi.Branch = sdr["Branch"].ToString();
                    pi.SelectBillTO = sdr["SelectBillTO"].ToString();
                    pi.Date = sdr["Date"].ToString();
                    pi.SelectShipTO = sdr["SelectShipTO"].ToString();
                    pi.Add_PORNo = sdr["Add_PORNo"].ToString();
                    pi.LANID = sdr["LANID"].ToString();
                    pi.PromoCode = sdr["PromoCode"].ToString();
                    pi.DomainID = sdr["DomainID"].ToString();
                    pi.RenewalStatus = sdr["RenewalStatus"].ToString();
                    pi.RenewalPeriod = sdr["RenewalPeriod"].ToString();
                    pi.RenewalEndDate = sdr["RenewalEndDate"].ToString();
                    pi.RenewalCount = sdr["RenewalCount"].ToString();
                    pi.BillingStatus = sdr["BillingStatus"].ToString();
                    pi.BillingPeriod = sdr["BillingPeriod"].ToString();
                    pi.BillingEndDate = sdr["BillingEndDate"].ToString();
                    pi.BillingCount = sdr["BillingCount"].ToString();
                    pi.InState_OutState = sdr["InState_OutState"].ToString();
                    pi.Tax = sdr["Tax"].ToString();
                    pi.TAXAmount = sdr["TAXAmount"].ToString();
                    pi.PriceBeforeTAX = sdr["PriceBeforeTAX"].ToString();
                    pi.PriceAfterTAX = sdr["PriceAfterTAX"].ToString();
                    pi.SaleGeneratedDate = sdr["SaleGeneratedDate"].ToString();
                    pi.SaleGeneratedDate = sdr["SaleGeneratedDate"].ToString();
                    pilist.Add(pi);

                }
            }
            sdr.Close();
            con.Close();
            return pilist;

        }

        public manage_pi getPIbyId(string id)
        {
            manage_pi pi = new manage_pi();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_PI", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getPIbyId");
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                pi.id = sdr["Id"].ToString();
                pi.PINo = sdr["PINo"].ToString();
                pi.OrderNo = sdr["OrderNo"].ToString();
                pi.QuotationReference = sdr["QuotationReference"].ToString();
                pi.LeadReference = sdr["LeadReference"].ToString();
                pi.Employee = sdr["Employee"].ToString();
                pi.Branch = sdr["Branch"].ToString();
                pi.SelectBillTO = sdr["SelectBillTO"].ToString();
                pi.Date = sdr["Date"].ToString();
                pi.SelectShipTO = sdr["SelectShipTO"].ToString();
                pi.Add_PORNo = sdr["Add_PORNo"].ToString();
                pi.LANID = sdr["LANID"].ToString();
                pi.PromoCode = sdr["PromoCode"].ToString();
                pi.DomainID = sdr["DomainID"].ToString();
                pi.RenewalStatus = sdr["RenewalStatus"].ToString();
                pi.RenewalPeriod = sdr["RenewalPeriod"].ToString();
                pi.RenewalEndDate = sdr["RenewalEndDate"].ToString();
                pi.RenewalCount = sdr["RenewalCount"].ToString();
                pi.BillingStatus = sdr["BillingStatus"].ToString();
                pi.BillingPeriod = sdr["BillingPeriod"].ToString();
                pi.BillingEndDate = sdr["BillingEndDate"].ToString();
                pi.BillingCount = sdr["BillingCount"].ToString();
                pi.InState_OutState = sdr["InState_OutState"].ToString();
                pi.Tax = sdr["Tax"].ToString();
                pi.TAXAmount = sdr["TAXAmount"].ToString();
                pi.PriceBeforeTAX = sdr["PriceBeforeTAX"].ToString();
                pi.PriceAfterTAX = sdr["PriceAfterTAX"].ToString();
                pi.SaleGeneratedDate = sdr["SaleGeneratedDate"].ToString();
                pi.SaleGeneratedDate = sdr["SaleGeneratedDate"].ToString();
            }
            con.Close();
            return pi;
        }

        public bool delete_PI(string id)
        {
            if (con.State == ConnectionState.Closed)

                con.Open();
            SqlCommand cmd = new SqlCommand("sp_PI", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "deletePIbyId");
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion




        #region manage PO
        public bool insert_PO(macreel_setup.Models.admin.manage_po po)
        {
            SqlCommand cmd = new SqlCommand("sp_PO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PO_Number", po.PO_Number);
            cmd.Parameters.AddWithValue("@Vendor_Id", po.Vendor_Id);
            cmd.Parameters.AddWithValue("@Client_ID", po.Client_ID);
            cmd.Parameters.AddWithValue("@PO_Date", po.PO_Date);
            cmd.Parameters.AddWithValue("@Manager", po.Manager);
            cmd.Parameters.AddWithValue("@Vendor_Email", po.Vendor_Email);
            cmd.Parameters.AddWithValue("@LAN", po.LAN);
            cmd.Parameters.AddWithValue("@PromoCode", po.PromoCode);
            cmd.Parameters.AddWithValue("@SDF_Order", po.SDF_Order);
            cmd.Parameters.AddWithValue("@MS_Account_Manager", po.MS_Account_Manager);
            cmd.Parameters.AddWithValue("@Payment_InDays", po.Payment_InDays);
            cmd.Parameters.AddWithValue("@Delivery_In_Days", po.Delivery_In_Days);
            cmd.Parameters.AddWithValue("@Delivery_Mode", po.Delivery_Mode);
            cmd.Parameters.AddWithValue("@MPN_ID", po.MPN_ID);
            cmd.Parameters.AddWithValue("@AEP_Authorization_No", po.AEP_Authorization_No);
            cmd.Parameters.AddWithValue("@DomainID", po.DomainID);
            cmd.Parameters.AddWithValue("@CDC_Discount", po.CDC_Discount);
            cmd.Parameters.AddWithValue("@CDC_Discount_Amount", po.CDC_Discount_Amount);
            cmd.Parameters.AddWithValue("@After_Discount_Amount", po.After_Discount_Amount);
            cmd.Parameters.AddWithValue("@IGST_Tax", po.IGST_Tax);
            cmd.Parameters.AddWithValue("@Tax_Amount", po.Tax_Amount);
            cmd.Parameters.AddWithValue("@After_Tax_Amount", po.After_Tax_Amount);
            cmd.Parameters.AddWithValue("@CN", po.CN);
            cmd.Parameters.AddWithValue("@CN_Amount", po.CN_Amount);
            cmd.Parameters.AddWithValue("@Grand_Total_Amount", po.Grand_Total_Amount);
            cmd.Parameters.AddWithValue("@Purchase_Amount", po.Purchase_Amount);
            cmd.Parameters.AddWithValue("@Total_Sales_Amount", po.Total_Sales_Amount);
            cmd.Parameters.AddWithValue("@PL_Amount", po.PL_Amount);
            cmd.Parameters.AddWithValue("@Id", po.id);

            if (po.id != null && po.id != "")
            {
                cmd.Parameters.AddWithValue("@Action", "updatePObyId");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Action", "insert_PO");

            }

            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<manage_po> getPOlist()
        {
            List<manage_po> polist = new List<manage_po>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_PO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getAllPO");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_po po = new manage_po();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    po = new manage_po();
                    po.id = sdr["Id"].ToString();
                    po.PO_Number = sdr["PO_Number"].ToString();
                    po.Vendor_Id = sdr["Vendor_Id"].ToString();
                    po.Client_ID = sdr["Client_ID"].ToString();
                    po.PO_Date = sdr["PO_Date"].ToString();
                    po.Manager = sdr["Manager"].ToString();
                    po.Vendor_Email = sdr["Vendor_Email"].ToString();
                    po.LAN = sdr["LAN"].ToString();
                    po.PromoCode = sdr["PromoCode"].ToString();
                    po.SDF_Order = sdr["SDF_Order"].ToString();
                    po.MS_Account_Manager = sdr["MS_Account_Manager"].ToString();
                    po.Payment_InDays = sdr["Payment_InDays"].ToString();
                    po.Delivery_In_Days = sdr["Delivery_In_Days"].ToString();
                    po.Delivery_Mode = sdr["Delivery_Mode"].ToString();
                    po.MPN_ID = sdr["MPN_ID"].ToString();
                    po.AEP_Authorization_No = sdr["AEP_Authorization_No"].ToString();
                    po.DomainID = sdr["DomainID"].ToString();
                    po.CDC_Discount = sdr["CDC_Discount"].ToString();
                    po.CDC_Discount_Amount = sdr["CDC_Discount_Amount"].ToString();
                    po.After_Discount_Amount = sdr["After_Discount_Amount"].ToString();
                    po.IGST_Tax = sdr["IGST_Tax"].ToString();
                    po.Tax_Amount = sdr["Tax_Amount"].ToString();
                    po.After_Tax_Amount = sdr["After_Tax_Amount"].ToString();
                    po.CN = sdr["CN"].ToString();
                    po.CN_Amount = sdr["CN_Amount"].ToString();
                    po.Grand_Total_Amount = sdr["Grand_Total_Amount"].ToString();
                    po.Purchase_Amount = sdr["Purchase_Amount"].ToString();
                    po.Total_Sales_Amount = sdr["Total_Sales_Amount"].ToString();
                    po.PL_Amount = sdr["PL_Amount"].ToString();
                    polist.Add(po);

                }
            }
            sdr.Close();
            con.Close();
            return polist;


        }

        public manage_po getPObyId(string id)
        {
            manage_po po = new manage_po();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_PO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getPObyId");
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                po.id = sdr["Id"].ToString();
                po.PO_Number = sdr["PO_Number"].ToString();
                po.Vendor_Id = sdr["Vendor_Id"].ToString();
                po.Client_ID = sdr["Client_ID"].ToString();
                po.PO_Date = sdr["PO_Date"].ToString();
                po.Manager = sdr["Manager"].ToString();
                po.Vendor_Email = sdr["Vendor_Email"].ToString();
                po.LAN = sdr["LAN"].ToString();
                po.PromoCode = sdr["PromoCode"].ToString();
                po.SDF_Order = sdr["SDF_Order"].ToString();
                po.MS_Account_Manager = sdr["MS_Account_Manager"].ToString();
                po.Payment_InDays = sdr["Payment_InDays"].ToString();
                po.Delivery_In_Days = sdr["Delivery_In_Days"].ToString();
                po.Delivery_Mode = sdr["Delivery_Mode"].ToString();
                po.MPN_ID = sdr["MPN_ID"].ToString();
                po.AEP_Authorization_No = sdr["AEP_Authorization_No"].ToString();
                po.DomainID = sdr["DomainID"].ToString();
                po.CDC_Discount = sdr["CDC_Discount"].ToString();
                po.CDC_Discount_Amount = sdr["CDC_Discount_Amount"].ToString();
                po.After_Discount_Amount = sdr["After_Discount_Amount"].ToString();
                po.IGST_Tax = sdr["IGST_Tax"].ToString();
                po.Tax_Amount = sdr["Tax_Amount"].ToString();
                po.After_Tax_Amount = sdr["After_Tax_Amount"].ToString();
                po.CN = sdr["CN"].ToString();
                po.CN_Amount = sdr["CN_Amount"].ToString();
                po.Grand_Total_Amount = sdr["Grand_Total_Amount"].ToString();
                po.Purchase_Amount = sdr["Purchase_Amount"].ToString();
                po.Total_Sales_Amount = sdr["Total_Sales_Amount"].ToString();
                po.PL_Amount = sdr["PL_Amount"].ToString();
            }
            con.Close();
            return po;
        }

        public bool delete_PO(string id)
        {
            if (con.State == ConnectionState.Closed)

                con.Open();
            SqlCommand cmd = new SqlCommand("sp_PO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "deletePObyId");
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region manage Quotation
        public bool insert_Quotation(macreel_setup.Models.admin.manage_quotation quotation)
        {
            //done
            SqlCommand cmd = new SqlCommand("sp_Quotation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Quotation_No", quotation.Quotation_No);
            cmd.Parameters.AddWithValue("@Lead_Reference", quotation.Lead_Reference);
            cmd.Parameters.AddWithValue("@Client_Name", quotation.Client_Name);
            cmd.Parameters.AddWithValue("@Contact_Person_No", quotation.Contact_Person_No);
            cmd.Parameters.AddWithValue("@Email", quotation.Email);
            cmd.Parameters.AddWithValue("@Company_Number", quotation.Company_Number);
            cmd.Parameters.AddWithValue("@Address", quotation.Address);
            cmd.Parameters.AddWithValue("@Employee", quotation.Employee);
            cmd.Parameters.AddWithValue("@Branch", quotation.Branch);
            cmd.Parameters.AddWithValue("@Select_Bill_TO", quotation.Select_Bill_TO);
            cmd.Parameters.AddWithValue("@Date", quotation.Date);
            cmd.Parameters.AddWithValue("@Select_Ship_TO", quotation.Select_Ship_TO);
            cmd.Parameters.AddWithValue("@Add_PORNo", quotation.Add_PORNo);
            cmd.Parameters.AddWithValue("@LAN_ID", quotation.LAN_ID);
            cmd.Parameters.AddWithValue("@PromoCode", quotation.PromoCode);
            cmd.Parameters.AddWithValue("@DomainID", quotation.DomainID);
            cmd.Parameters.AddWithValue("@InState_OutState", quotation.InState_OutState);
            cmd.Parameters.AddWithValue("@Tax", quotation.Tax);
            cmd.Parameters.AddWithValue("@TAX_Amount", quotation.TAX_Amount);
            cmd.Parameters.AddWithValue("@Price_Before_TAX", quotation.Price_Before_TAX);
            cmd.Parameters.AddWithValue("@Price_After_TAX", quotation.Price_After_TAX);
            cmd.Parameters.AddWithValue("@Generated_Date", quotation.Generated_Date);
            cmd.Parameters.AddWithValue("@GeneratedBy", quotation.GeneratedBy);
            cmd.Parameters.AddWithValue("@Id", quotation.id);

            if (quotation.id != null && quotation.id != "")
            {
                cmd.Parameters.AddWithValue("@Action", "updateQuotationById");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Action", "insert_quotation");

            }

            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        
        public List<manage_quotation> getQuotationlistGeneratedBy(string loginId)
        {
            List<manage_quotation> quotlist = new List<manage_quotation>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Quotation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GeneratedBy", loginId);
            cmd.Parameters.AddWithValue("@Action", "selectAllQuotationGeneratedBy");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_quotation quot = new manage_quotation();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    quot = new manage_quotation();
                    quot.id = sdr["Id"].ToString();
                    quot.Quotation_No = sdr["Quotation_No"].ToString();
                    quot.Lead_Reference = sdr["Lead_Reference"].ToString();
                    quot.Client_Name = sdr["Client_Name"].ToString();
                    quot.Contact_Person_No = sdr["Contact_Person_No"].ToString();
                    quot.Email = sdr["Email"].ToString();
                    quot.Company_Number = sdr["Company_Number"].ToString();
                    quot.Address = sdr["Address"].ToString();
                    quot.GeneratedBy = sdr["GeneratedBy"].ToString();
                    //quot.Employee = sdr["Employee"].ToString();
                    //quot.Branch = sdr["Branch"].ToString();
                    //quot.Select_Bill_TO = sdr["Select_Bill_TO"].ToString();
                    //quot.Date = sdr["Date"].ToString();
                    //quot.Select_Ship_TO = sdr["Select_Ship_TO"].ToString();
                    //quot.Add_PORNo = sdr["Add_PORNo"].ToString();
                    //quot.LAN_ID = sdr["LAN_ID"].ToString();
                    //quot.PromoCode = sdr["PromoCode"].ToString();
                    //quot.DomainID = sdr["DomainID"].ToString();
                    //quot.InState_OutState = sdr["InState_OutState"].ToString();
                    //quot.Tax = sdr["Tax"].ToString();
                    //quot.TAX_Amount = sdr["TAX_Amount"].ToString();
                    //quot.Price_Before_TAX = sdr["Price_Before_TAX"].ToString();
                    //quot.Price_After_TAX = sdr["Price_After_TAX"].ToString();
                    //quot.Generated_Date = sdr["Generated_Date"].ToString();

                    quotlist.Add(quot);

                }
            }
            sdr.Close();
            con.Close();
            return quotlist;

        }


        public List<manage_quotation> getQuotationlistwithversion( string LeadId)
        {
            List<manage_quotation> quotlist = new List<manage_quotation>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Quotation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Lead_Reference", LeadId);
            cmd.Parameters.AddWithValue("@Action", "SelectAllQuotationByLeadRefference");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_quotation quot = new manage_quotation();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    quot = new manage_quotation();
                    quot.id = sdr["Id"].ToString();
                    quot.Quotation_No = sdr["Quotation_No"].ToString();
                    quot.Lead_Reference = sdr["Lead_Reference"].ToString();
                    quot.Client_Name = sdr["Client_Name"].ToString();
                    quot.Contact_Person_No = sdr["Contact_Person_No"].ToString();
                    quot.Email = sdr["Email"].ToString();
                    quot.Company_Number = sdr["Company_Number"].ToString();
                    quot.Address = sdr["Address"].ToString();
                    quot.Employee = sdr["Employee"].ToString();
                    quot.Branch = sdr["Branch"].ToString();
                    quot.Select_Bill_TO = sdr["Select_Bill_TO"].ToString();
                    quot.Date = sdr["Date"].ToString();
                    quot.Select_Ship_TO = sdr["Select_Ship_TO"].ToString();
                    quot.Add_PORNo = sdr["Add_PORNo"].ToString();
                    quot.LAN_ID = sdr["LAN_ID"].ToString();
                    quot.PromoCode = sdr["PromoCode"].ToString();
                    quot.DomainID = sdr["DomainID"].ToString();
                    quot.InState_OutState = sdr["InState_OutState"].ToString();
                    quot.Tax = sdr["Tax"].ToString();
                    quot.TAX_Amount = sdr["TAX_Amount"].ToString();
                    quot.Price_Before_TAX = sdr["Price_Before_TAX"].ToString();
                    quot.Price_After_TAX = sdr["Price_After_TAX"].ToString();
                    quot.Generated_Date = sdr["Generated_Date"].ToString();

                    quotlist.Add(quot);

                }
            }
            sdr.Close();
            con.Close();
            return quotlist;

        }


        public manage_quotation getQuotationbyId(string id)
        {
            manage_quotation quot = new manage_quotation();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Quotation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "selectQuotationById");
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                quot.id = sdr["Id"].ToString();
                quot.Quotation_No = sdr["Quotation_No"].ToString();
                quot.Lead_Reference = sdr["Lead_Reference"].ToString();
                quot.Client_Name = sdr["Client_Name"].ToString();
                quot.Contact_Person_No = sdr["Contact_Person_No"].ToString();
                quot.Email = sdr["Email"].ToString();
                quot.Company_Number = sdr["Company_Number"].ToString();
                quot.Address = sdr["Address"].ToString();
                quot.Employee = sdr["Employee"].ToString();
                quot.Branch = sdr["Branch"].ToString();
                quot.Select_Bill_TO = sdr["Select_Bill_TO"].ToString();
                quot.Date = sdr["Date"].ToString();
                quot.Select_Ship_TO = sdr["Select_Ship_TO"].ToString();
                quot.Add_PORNo = sdr["Add_PORNo"].ToString();
                quot.LAN_ID = sdr["LAN_ID"].ToString();
                quot.PromoCode = sdr["PromoCode"].ToString();
                quot.DomainID = sdr["DomainID"].ToString();
                quot.InState_OutState = sdr["InState_OutState"].ToString();
                quot.Tax = sdr["Tax"].ToString();
                quot.TAX_Amount = sdr["TAX_Amount"].ToString();
                quot.Price_Before_TAX = sdr["Price_Before_TAX"].ToString();
                quot.Price_After_TAX = sdr["Price_After_TAX"].ToString();
                quot.Generated_Date = sdr["Generated_Date"].ToString();
            }
            con.Close();
            return quot;
        }

        public bool delete_Quotation(string id)
        {
            if (con.State == ConnectionState.Closed)

                con.Open();
            SqlCommand cmd = new SqlCommand("sp_Quotation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "deleteQuotation");
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        #region manage leadsheet

        public List<manage_leadsheet> getleadsheetlist(string usertype,string loginId)
        {
            List<manage_leadsheet> leadsheet = new List<manage_leadsheet>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_LeadSheet", con);
            cmd.CommandType = CommandType.StoredProcedure;

            if (usertype == "admin")
            {
                cmd.Parameters.AddWithValue("@Action", "getallLeadsheet");

            }
            else
            {
                cmd.Parameters.AddWithValue("@uploadedby", loginId);

                cmd.Parameters.AddWithValue("@Action", "getleadsheetuploadedby");

            }
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_leadsheet lead = new manage_leadsheet();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    lead = new manage_leadsheet();
                    lead.id = sdr["id"].ToString();
                    lead.client_name = sdr["client_name"].ToString();
                    lead.contact_no = sdr["contact_no"].ToString();
                    lead.eMAIL_ID = sdr["eMAIL_ID"].ToString();
                    lead.address = sdr["address"].ToString();
                    lead.uploadedby = sdr["uploadedby"].ToString();
                    lead.uploadedbytype = sdr["uploadedbytype"].ToString();
                    lead.generateStatus = sdr["generateStatus"].ToString();
                    leadsheet.Add(lead);
                }

            }
            con.Close();
            return leadsheet;
        }



        //getallLeadForAssign



        public List<manage_leadsheet> getallLeadForAssign()
        {
            List<manage_leadsheet> leadsheet = new List<manage_leadsheet>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_LeadSheet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getallLeadForAssign");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_leadsheet lead = new manage_leadsheet();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    lead = new manage_leadsheet();
                    lead.id = sdr["id"].ToString();
                    lead.client_name = sdr["client_name"].ToString();
                    lead.contact_no = sdr["contact_no"].ToString();
                    lead.eMAIL_ID = sdr["eMAIL_ID"].ToString();
                    lead.address = sdr["address"].ToString();
                    lead.uploadedby = sdr["uploadedby"].ToString();
                    lead.generateStatus = sdr["generateStatus"].ToString();
                    leadsheet.Add(lead);
                }

            }
            con.Close();
            return leadsheet;
        }






        public List<manage_leadsheet> getleadsheetById(string id)
        {
            List<manage_leadsheet> leadsheet = new List<manage_leadsheet>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_LeadSheet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@Action", "getLeadbyId");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_leadsheet lead = new manage_leadsheet();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    lead = new manage_leadsheet();
                    lead.id =sdr["id"].ToString();
                    lead.client_name = sdr["client_name"].ToString();
                    lead.contact_no = sdr["contact_no"].ToString();
                    lead.eMAIL_ID = sdr["eMAIL_ID"].ToString();
                    lead.address = sdr["address"].ToString();
                    lead.uploadedby = sdr["uploadedby"].ToString();
                    leadsheet.Add(lead);
                }

            }
            con.Close();
            return leadsheet;
        }

        public bool generatenewLeadBySalesman(macreel_setup.Models.admin.manage_leadsheet lead)
        {
            SqlCommand cmd = new SqlCommand("sp_LeadSheet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", lead.id);
            cmd.Parameters.AddWithValue("@client_name", lead.client_name);
            cmd.Parameters.AddWithValue("@contact_no", lead.contact_no);
            cmd.Parameters.AddWithValue("@eMAIL_ID", lead.eMAIL_ID);
            cmd.Parameters.AddWithValue("@address", lead.address);
            cmd.Parameters.AddWithValue("@LeadGeneratedBy", lead.uploadedby);
            cmd.Parameters.AddWithValue("@LeadGeneratedByType", "Sales");
            cmd.Parameters.AddWithValue("@generateStatus", 1);
            cmd.Parameters.AddWithValue("@Action", "generatenewleadBySalesman");

            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public List<manage_leadsheet> getgeneratedleadById(string id)
        {
            List<manage_leadsheet> leadsheet = new List<manage_leadsheet>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_LeadSheet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@Action", "getgeneratedLeadById");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_leadsheet lead = new manage_leadsheet();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    lead = new manage_leadsheet();
                    lead.id = sdr["id"].ToString();
                    leadsheet.Add(lead);
                }

            }
            con.Close();
            return leadsheet;
        }




        public bool delete_leadBySalesman (string id)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("sp_LeadSheet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "deleteLeadbyId");
            cmd.Parameters.AddWithValue("@id", id);
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //dropdown list for agentlist

        public List<SelectListItem> getAgentList()
        {


            List<SelectListItem> getlist = new List<SelectListItem>();
            SelectListItem obj = new SelectListItem();

            SqlCommand cmd = new SqlCommand("sp_LeadSheet", con);

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "getagentlist");
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        obj = new SelectListItem();
                        obj.Value = Convert.ToInt32(sdr["id"]).ToString(); ;
                        obj.Text = sdr["employee_first_name"].ToString();

                        getlist.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
            return getlist;


        }
        //assign or reassign lead to agent

        public bool assignLeadToAgent(assignLead assignObj)
        {
           

            SqlCommand cmd = new SqlCommand("sp_LeadSheet", con);

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "assignLead");
              //  cmd.Parameters.AddWithValue("@id", assignObj.id);
                cmd.Parameters.AddWithValue("@agentId", assignObj.agentId);
              //  cmd.Parameters.AddWithValue("@assignStatus", 1);
                cmd.Parameters.AddWithValue("@AssignLead_Id", assignObj.AssignLead_Id);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
            return true;
        }


        public List<lead_mangement> GetAllAssignedLeadList(string loginId)
        {


            List<lead_mangement> assinLeadList = new List<lead_mangement>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_LeadSheet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getallAssignedLead");
            cmd.Parameters.AddWithValue("@LeadGeneratedBy", loginId);
            SqlDataReader sdr = cmd.ExecuteReader();
            lead_mangement obj = new lead_mangement();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {

                    obj = new lead_mangement();
                    obj.id = sdr["id"].ToString();
                    obj.LeadID = sdr["LeadID"].ToString();
                    obj.LeadSegment = sdr["LeadSegment"].ToString();
                    obj.Branch = sdr["Branch"].ToString();
                    obj.Client = sdr["Client"].ToString();
                    obj.ContactPerson = sdr["ContactPerson"].ToString();
                    obj.ContactDesignation = sdr["ContactDesignation"].ToString();
                    obj.ContactEmail = sdr["ContactEmail"].ToString();
                    obj.ContactMobileNumber = sdr["ContactMobileNumber"].ToString();
                    obj.Address = sdr["Address"].ToString();
                    obj.Telephone = sdr["Telephone"].ToString();
                    obj.City = sdr["City"].ToString();
                    obj.PIN = sdr["PIN"].ToString();
                    obj.State = sdr["State"].ToString();
                    obj.Country = sdr["Country"].ToString();
                    obj.ClientSegment = sdr["ClientSegment"].ToString();
                    obj.ClientTurnover = sdr["ClientTurnover"].ToString();
                    obj.ClientPCsOrNoOfEmployee = sdr["ClientPCsOrNoOfEmployee"].ToString();
                    obj.ExpectedAnnualBusiness = sdr["ExpectedAnnualBusiness"].ToString();
                    obj.ProductRequired = sdr["ProductRequired"].ToString();
                    obj.ProductDescription = sdr["ProductDescription"].ToString();
                    obj.ProductQuantity = sdr["ProductQuantity"].ToString();
                    obj.ServiceRequired = sdr["ServiceRequired"].ToString();
                    obj.ServicesDescription = sdr["ServicesDescription"].ToString();
                    obj.EstimatedLeadValue = sdr["EstimatedLeadValue"].ToString();
                    obj.LeadGeneratedBy = sdr["LeadGeneratedBy"].ToString();
                    obj.LeadGeneratedByType = sdr["LeadGeneratedByType"].ToString();
                    obj.LeadGenerationDate = sdr["LeadGenerationDate"].ToString();
                    obj.LeadAssignedTo = sdr["LeadAssignedTo"].ToString();
                    obj.LeadStatus = sdr["LeadStatus"].ToString();
                    obj.employee_first_name = sdr["employee_first_name"].ToString();
                    assinLeadList.Add(obj);
                }


            }
            con.Close();
            return assinLeadList;
        }



        //get assigned lead by LeadId 

        public lead_mangement getassingedLeadByLeadId(string id)
        {
            lead_mangement obj = new lead_mangement();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_LeadSheet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getassindeleadByLeadId");
             cmd.Parameters.AddWithValue("@LeadId",id);
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                sdr.Read();
                    obj = new lead_mangement();
                    obj.id = sdr["id"].ToString();
                    obj.LeadID = sdr["LeadID"].ToString();
                    obj.LeadSegment = sdr["LeadSegment"].ToString();
                    obj.Branch = sdr["Branch"].ToString();
                    obj.Client = sdr["Client"].ToString();
                    obj.ContactPerson = sdr["ContactPerson"].ToString();
                    obj.ContactDesignation = sdr["ContactDesignation"].ToString();
                    obj.ContactEmail = sdr["ContactEmail"].ToString();
                    obj.ContactMobileNumber = sdr["ContactMobileNumber"].ToString();
                    obj.Address = sdr["Address"].ToString();
                    obj.Telephone = sdr["Telephone"].ToString();
                    obj.City = sdr["City"].ToString();
                    obj.PIN = sdr["PIN"].ToString();
                    obj.State = sdr["State"].ToString();
                    obj.Country = sdr["Country"].ToString();
                    obj.ClientSegment = sdr["ClientSegment"].ToString();
                    obj.ClientTurnover = sdr["ClientTurnover"].ToString();
                    obj.ClientPCsOrNoOfEmployee = sdr["ClientPCsOrNoOfEmployee"].ToString();
                    obj.ExpectedAnnualBusiness = sdr["ExpectedAnnualBusiness"].ToString();
                    obj.ProductRequired = sdr["ProductRequired"].ToString();
                    obj.ProductDescription = sdr["ProductDescription"].ToString();
                    obj.ProductQuantity = sdr["ProductQuantity"].ToString();
                    obj.ServiceRequired = sdr["ServiceRequired"].ToString();
                    obj.ServicesDescription = sdr["ServicesDescription"].ToString();
                    obj.EstimatedLeadValue = sdr["EstimatedLeadValue"].ToString();
                    obj.LeadGeneratedBy = sdr["LeadGeneratedBy"].ToString();
                    obj.LeadGeneratedByType = sdr["LeadGeneratedByType"].ToString();
                    obj.LeadGenerationDate = sdr["LeadGenerationDate"].ToString();
                  //  obj.LeadAssignedTo = sdr["LeadAssignedTo"].ToString();
                    obj.LeadStatus = sdr["LeadStatus"].ToString();
                    obj.LeadAssignedTo = sdr["assign_to_name"].ToString();
            }
            sdr.Close();
            con.Close();
            return obj;
        }


        public lead_mangement getLeadDetailbyleadId(string id)
        {
            lead_mangement obj = new lead_mangement();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_LeadSheet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getLeadDetailbyleadId");
            cmd.Parameters.AddWithValue("@LeadId", id);
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                sdr.Read();
                obj = new lead_mangement();
                obj.id = sdr["id"].ToString();
                obj.LeadID = sdr["LeadID"].ToString();
                obj.LeadSegment = sdr["LeadSegment"].ToString();
                obj.Branch = sdr["Branch"].ToString();
                obj.Client = sdr["Client"].ToString();
                obj.ContactPerson = sdr["ContactPerson"].ToString();
                obj.ContactDesignation = sdr["ContactDesignation"].ToString();
                obj.ContactEmail = sdr["ContactEmail"].ToString();
                obj.ContactMobileNumber = sdr["ContactMobileNumber"].ToString();
                obj.Address = sdr["Address"].ToString();
                obj.Telephone = sdr["Telephone"].ToString();
                obj.City = sdr["City"].ToString();
                obj.PIN = sdr["PIN"].ToString();
                obj.State = sdr["State"].ToString();
                obj.Country = sdr["Country"].ToString();
                obj.ClientSegment = sdr["ClientSegment"].ToString();
                obj.ClientTurnover = sdr["ClientTurnover"].ToString();
                obj.ClientPCsOrNoOfEmployee = sdr["ClientPCsOrNoOfEmployee"].ToString();
                obj.ExpectedAnnualBusiness = sdr["ExpectedAnnualBusiness"].ToString();
                obj.ProductRequired = sdr["ProductRequired"].ToString();
                obj.ProductDescription = sdr["ProductDescription"].ToString();
                obj.ProductQuantity = sdr["ProductQuantity"].ToString();
                obj.ServiceRequired = sdr["ServiceRequired"].ToString();
                obj.ServicesDescription = sdr["ServicesDescription"].ToString();
                obj.EstimatedLeadValue = sdr["EstimatedLeadValue"].ToString();
                obj.LeadGeneratedBy = sdr["LeadGeneratedByName"].ToString();
                obj.LeadGeneratedByType = sdr["LeadGeneratedByType"].ToString();
                obj.LeadGenerationDate = sdr["LeadGenerationDate"].ToString();
               // obj.LeadAssignedTo = sdr["LeadAssignedTo"].ToString();
                obj.LeadStatus = sdr["LeadStatus"].ToString();
               // obj.employee_first_name = sdr["employee_first_name"].ToString();
            }
            sdr.Close();
            con.Close();
            return obj;
        }



        #endregion





        #region manage assign lead By Agent


        // get reporting  manager 
        public manage_report_manager getreportedManager(int id)
        {
            manage_report_manager repmanager = new manage_report_manager();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_leadresponse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "getreportingmanager");
            cmd.Parameters.AddWithValue("@AgentId", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();

                repmanager.employee_id = sdr["employee_id"].ToString();
                repmanager.employee_name = sdr["employee_name"].ToString();
                repmanager.report_manager = sdr["report_manager"].ToString();
                repmanager.report_manager_Id = sdr["report_manager_Id"].ToString();
              

            }
            sdr.Close();
            con.Close();
            return repmanager;
        }


        //get assignlead  for agent pannel by agent Id
        public List<lead_mangement> getAllLeadAssignToAgent(int id)
        {


            List<lead_mangement> assinLeadList = new List<lead_mangement>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_leadresponse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "GetAssignLeadToagent");
            cmd.Parameters.AddWithValue("@AgentId", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            lead_mangement obj = new lead_mangement();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {

                    obj = new lead_mangement();
                    obj.id = sdr["id"].ToString();
                    obj.LeadID = sdr["LeadID"].ToString();
                    obj.LeadSegment = sdr["LeadSegment"].ToString();
                    obj.Branch = sdr["Branch"].ToString();
                    obj.Client = sdr["Client"].ToString();
                    obj.ContactPerson = sdr["ContactPerson"].ToString();
                    obj.ContactDesignation = sdr["ContactDesignation"].ToString();
                    obj.ContactEmail = sdr["ContactEmail"].ToString();
                    obj.ContactMobileNumber = sdr["ContactMobileNumber"].ToString();
                    obj.Address = sdr["Address"].ToString();
                    obj.Telephone = sdr["Telephone"].ToString();
                    obj.City = sdr["City"].ToString();
                    obj.PIN = sdr["PIN"].ToString();
                    obj.State = sdr["State"].ToString();
                    obj.Country = sdr["Country"].ToString();
                    obj.ClientSegment = sdr["ClientSegment"].ToString();
                    obj.ClientTurnover = sdr["ClientTurnover"].ToString();
                    obj.ClientPCsOrNoOfEmployee = sdr["ClientPCsOrNoOfEmployee"].ToString();
                    obj.ExpectedAnnualBusiness = sdr["ExpectedAnnualBusiness"].ToString();
                    obj.ProductRequired = sdr["ProductRequired"].ToString();
                    obj.ProductDescription = sdr["ProductDescription"].ToString();
                    obj.ProductQuantity = sdr["ProductQuantity"].ToString();
                    obj.ServiceRequired = sdr["ServiceRequired"].ToString();
                    obj.ServicesDescription = sdr["ServicesDescription"].ToString();
                    obj.EstimatedLeadValue = sdr["EstimatedLeadValue"].ToString();
                    obj.LeadGeneratedBy = sdr["LeadGeneratedBy"].ToString();
                    obj.LeadGeneratedByType = sdr["LeadGeneratedByType"].ToString();
                    obj.LeadGenerationDate = sdr["LeadGenerationDate"].ToString();
                    obj.LeadAssignedTo = sdr["LeadAssignedTo"].ToString();
                    obj.LeadStatus = sdr["LeadStatus"].ToString();
                    assinLeadList.Add(obj);
                }


            }
            con.Close();
            return assinLeadList;
        }






        public bool insertfolloupLeadResponse(manage_folloupLeadResponse respObj)
        {


            SqlCommand cmd = new SqlCommand("sp_leadresponse", con);

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
              
                cmd.Parameters.AddWithValue("@id", respObj.id);
                cmd.Parameters.AddWithValue("@AgentId", respObj.AgentId);
                cmd.Parameters.AddWithValue("@LeadId", respObj.LeadId);
                 cmd.Parameters.AddWithValue("@status",respObj.status );             
                 cmd.Parameters.AddWithValue("@response",respObj.response );             
                 cmd.Parameters.AddWithValue("@currentDate", respObj.current_date );             
                 cmd.Parameters.AddWithValue("@next_follow_up_date", respObj.nextfollow_up_date);
                
                cmd.Parameters.AddWithValue("@Action", "add_response");
                


                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
            return true;
        }




        public List<manage_folloupLeadResponse> getfollowUpLeadResponse(string LeadId)
        {
            List<manage_folloupLeadResponse>leadresponse  = new List<manage_folloupLeadResponse>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_leadresponse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LeadId", LeadId);
            cmd.Parameters.AddWithValue("@Action", "getfollouwpLeadResponse");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_folloupLeadResponse lead = new manage_folloupLeadResponse();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    lead = new manage_folloupLeadResponse();
                    lead.id = sdr["id"].ToString();
                    lead.AgentId = sdr["AgentId"].ToString();
                    lead.LeadId = sdr["LeadId"].ToString();
                    lead.status = sdr["status"].ToString();
                    lead.response = sdr["response"].ToString();
                    lead.current_date = sdr["currentDate"].ToString();
                    lead.nextfollow_up_date = sdr["next_follow_up_date"].ToString();
                    leadresponse.Add(lead);
                }

            }
            con.Close();
            return leadresponse;
        }




        public List<manage_folloupLeadResponse> getnextfollowUpLeadResponseNotifiaction(string AgentId)
        {
            List<manage_folloupLeadResponse> leadresponse = new List<manage_folloupLeadResponse>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_leadresponse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AgentId", AgentId);
            cmd.Parameters.AddWithValue("@Action", "getfollouwpLeadResponsebynext_follow_up");
            SqlDataReader sdr = cmd.ExecuteReader();
            manage_folloupLeadResponse lead = new manage_folloupLeadResponse();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    lead = new manage_folloupLeadResponse();
                    lead.id = sdr["id"].ToString();
                    lead.AgentId = sdr["AgentId"].ToString();
                    lead.LeadId = sdr["LeadId"].ToString();
                    lead.status = sdr["status"].ToString();
                    lead.response = sdr["response"].ToString();
                    lead.current_date = sdr["currentDate"].ToString();
                    lead.nextfollow_up_date = sdr["next_follow_up_date"].ToString();
                    leadresponse.Add(lead);
                }

            }
            con.Close();
            return leadresponse;
        }

        //transgerassing lead

        public bool transgerAssignLeadTo_rpm(assignLead obj)
        {

            SqlCommand cmd = new SqlCommand("sp_LeadSheet", con);

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "transgerassignLead");
                cmd.Parameters.AddWithValue("@rpmId", obj.reAssignTo);
                cmd.Parameters.AddWithValue("@TransferId", obj.assignBy_Id);
                cmd.Parameters.AddWithValue("@AssignLead_Id", obj.AssignLead_Id);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
            return true;
        }




        #endregion

    }
}