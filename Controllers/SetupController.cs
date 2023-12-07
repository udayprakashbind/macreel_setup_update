using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using macreel_setup.Models;

namespace macreel_setup.Controllers
{
    public class SetupController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        #region checklogin

        [HttpPost]
        public JsonResult admin_Login(string username, string password, string url)
        {

            macreel_setup.App_Code.basic_function basic_function = new macreel_setup.App_Code.basic_function();


            Models.common_response Response = basic_function.login(username, password);
            if (Response.success == true)
            {
                if (url != null && url.ToString() != "")
                {
                    Response.message = (HttpUtility.HtmlDecode(url));
                }
                else
                {
                    Response.message = "/admin/Dasboard";
                }
                Session["adminname"] = Response.parameter.ToString();

            }
            return Json(Response);
        }

        #endregion

        #region  admin info
        //[ChildActionOnly]
        //public ActionResult topbar()
        //{
        //    macreel_setup.App_Code.Admin.basic_function basic_function = new macreel_setup.App_Code.Admin.basic_function();
        //    macreel_setup.Models.admininfo admininfo = new macreel_setup.Models.admininfo();
        //    string agencyid = "";
        //    if (Session["adminname"] != null && Session["adminname"].ToString() != "")
        //    {
        //        agencyid = Session["adminname"].ToString();
        //    }

        //    admininfo = basic_function.admininfo(agencyid);
        //    return PartialView(admininfo);

        //}
        #endregion

        #region logout

        public ActionResult logout()
        {
            if (Session["adminname"] != null)
            {
                Session["adminname"] = null;
                Session["data_con"] = null;
            }

            return RedirectToAction("login");
        }
        #endregion

        #region Dashboard
        public ActionResult Dasboard()
        {
            macreel_setup.App_Code.basic_function basic_function = new macreel_setup.App_Code.basic_function();
            if (basic_function.adminssioncheck("") == false)
            {
                string url = Request.Url.PathAndQuery;
                return Redirect("/admin/login?url=" + HttpUtility.UrlEncode(url) + "");
            }
            return View();
        }

        #endregion

        #region Company Setup
        public ActionResult company_setup( string id)
        {
            macreel_setup.App_Code.basic_function basic_function = new macreel_setup.App_Code.basic_function();
            if (basic_function.adminssioncheck("") == false)
            {
                string url = Request.Url.PathAndQuery;
                return Redirect("/admin/login?url=" + HttpUtility.UrlEncode(url) + "");
            }

            macreel_setup.Models.Setup.company_setup company_setup = new macreel_setup.Models.Setup.company_setup();

            if (id != null && id.ToString() != "")
            {
                string strr = "select * from company_setup where id='" + id + "'";
                DataTable dt = SqlHelper.ExecuteDataset(CommandType.Text, strr).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    company_setup.id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    company_setup.comp_name = dt.Rows[0]["comp_name"].ToString();
                    company_setup.address = dt.Rows[0]["address"].ToString();
                    company_setup.logo = dt.Rows[0]["logo"].ToString();
                    company_setup.admin_userid = dt.Rows[0]["admin_userid"].ToString();
                    company_setup.subs_startdate = dt.Rows[0]["subs_startdate"].ToString();
                    company_setup.subs_enddate = dt.Rows[0]["subs_enddate"].ToString();
                    company_setup.admin_name = dt.Rows[0]["admin_name"].ToString();
                    company_setup.contact_no = dt.Rows[0]["contact_no"].ToString();
                    company_setup.email = dt.Rows[0]["email"].ToString();
                    company_setup.gst_no = dt.Rows[0]["gst_no"].ToString();
                    company_setup.user_allowed = dt.Rows[0]["user_allowed"].ToString();
                    company_setup.software_price = dt.Rows[0]["software_price"].ToString();
                    company_setup.gst_price = dt.Rows[0]["gst_price"].ToString();
                    company_setup.total = dt.Rows[0]["total"].ToString();
                    company_setup.amc_price = dt.Rows[0]["amc_price"].ToString();
                    company_setup.amc_startdate = dt.Rows[0]["amc_startdate"].ToString();
                    company_setup.amc_enddate = dt.Rows[0]["amc_enddate"].ToString();
                    company_setup.support = dt.Rows[0]["support"].ToString();
                    company_setup.domain = dt.Rows[0]["domain"].ToString();
                    company_setup.domain_name = dt.Rows[0]["domain_name"].ToString();
                    company_setup.domain_price = dt.Rows[0]["domain_price"].ToString();
                    company_setup.domain_renewal_date = dt.Rows[0]["domain_renewal_date"].ToString();
                    company_setup.server = dt.Rows[0]["server"].ToString();
                    company_setup.server_name = dt.Rows[0]["server_name"].ToString();
                    company_setup.server_price = dt.Rows[0]["server_price"].ToString();
                    company_setup.server_renewal_date = dt.Rows[0]["server_renewal_date"].ToString();

                }
            }

            return View(company_setup);

        }

        [HttpPost]
        public ActionResult insert_company_setup(macreel_setup.Models.Setup.company_setup company_setup)
        {

            var ab = Request.Form["isactive"];
            var isactive = false;
            if (ab == "true")
            {
                isactive = true;
            }

            var path = System.IO.Path.Combine(Server.MapPath("~/tempimage/"));


            HttpPostedFileBase file1 = Request.Files["fileupload"];

            string img1 = "";

            string uploadpayslipss;

            if (company_setup.logo != null && company_setup.logo != "")
            {
                img1 = company_setup.logo;
            }

            if (file1 != null && file1.FileName.ToString() != "")
            {
                uploadpayslipss = DateTime.Now.ToString("ssMMHHmmyyyydd") + System.Guid.NewGuid() + "." + file1.FileName.Split('.')[1];
                file1.SaveAs(path + uploadpayslipss);
                img1 = uploadpayslipss;

            }

            SqlParameter[] para = new SqlParameter[27];

            para[0] = new SqlParameter("@comp_name", SqlDbType.NVarChar);
            para[0].Value = company_setup.comp_name;

            para[1] = new SqlParameter("@address", SqlDbType.NVarChar);
            para[1].Value = company_setup.address;

            para[2] = new SqlParameter("@admin_userid", SqlDbType.NVarChar);
            para[2].Value = company_setup.admin_userid;

            para[3] = new SqlParameter("@logo", SqlDbType.NVarChar);
            para[3].Value = company_setup.logo;

            para[4] = new SqlParameter("@subs_startdate", SqlDbType.NVarChar);
            para[4].Value = company_setup.subs_startdate;

            para[5] = new SqlParameter("@subs_enddate", SqlDbType.NVarChar);
            para[5].Value = company_setup.subs_enddate;

            para[6] = new SqlParameter("@admin_name", SqlDbType.NVarChar);
            para[6].Value = company_setup.admin_name;

            para[7] = new SqlParameter("@contact_no", SqlDbType.NVarChar);
            para[7].Value = company_setup.contact_no;

            para[8] = new SqlParameter("@email", SqlDbType.NVarChar);
            para[8].Value = company_setup.email;

            para[9] = new SqlParameter("@gst_no", SqlDbType.NVarChar);
            para[9].Value = company_setup.gst_no;

            para[10] = new SqlParameter("@user_allowed", SqlDbType.NVarChar);
            para[10].Value = company_setup.user_allowed;

            para[11] = new SqlParameter("@software_price", SqlDbType.NVarChar);
            para[11].Value = company_setup.software_price;

            para[12] = new SqlParameter("@gst_price", SqlDbType.NVarChar);
            para[12].Value = company_setup.gst_price;

            para[13] = new SqlParameter("@total", SqlDbType.NVarChar);
            para[13].Value = company_setup.total;

            para[14] = new SqlParameter("@amc_price", SqlDbType.NVarChar);
            para[14].Value = company_setup.amc_price;

            para[15] = new SqlParameter("@amc_startdate", SqlDbType.NVarChar);
            para[15].Value = company_setup.amc_startdate;

            para[16] = new SqlParameter("@amc_enddate", SqlDbType.NVarChar);
            para[16].Value = company_setup.amc_enddate;

            para[17] = new SqlParameter("@support", SqlDbType.NVarChar);
            para[17].Value = company_setup.support;

            para[18] = new SqlParameter("@domain", SqlDbType.NVarChar);
            para[18].Value = company_setup.domain;

            para[19] = new SqlParameter("@domain_name", SqlDbType.NVarChar);
            para[19].Value = company_setup.domain_name;

            para[20] = new SqlParameter("@domain_price", SqlDbType.NVarChar);
            para[20].Value = company_setup.domain_price;

            para[21] = new SqlParameter("@domain_renewal_date", SqlDbType.NVarChar);
            para[21].Value = company_setup.domain_renewal_date;

            para[22] = new SqlParameter("@server", SqlDbType.NVarChar);
            para[22].Value = company_setup.server;

            para[23] = new SqlParameter("@server_name", SqlDbType.NVarChar);
            para[23].Value = company_setup.server_name;

            para[24] = new SqlParameter("@server_price", SqlDbType.NVarChar);
            para[24].Value = company_setup.server_price;

            para[25] = new SqlParameter("@server_renewal_date", SqlDbType.NVarChar);
            para[25].Value = company_setup.server_renewal_date;

            para[26] = new SqlParameter("@id", SqlDbType.NVarChar);
            para[26].Value = company_setup.id;

            if(company_setup.id != null)
            {
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "sp_update_company_setup", para);
                TempData["Message"] = "Your Company Setup Updated Successfully";
                TempData["para"] = true;

            }

            else
            {
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "sp_insert_company_setup", para);
                TempData["Message"] = "Your Company Setup Created Successfully ";
                TempData["para"] = true;
            }
            //}
            //catch
            //{
            //    TempData["para"] = false;
            //    TempData["Message"] = "Error, Call Your Administritive !";
            //}

            return RedirectToAction("company_setup");
        }

        public ActionResult view_companysetup()
        {
            List<macreel_setup.Models.Setup.company_setup> company_setup = new List<macreel_setup.Models.Setup.company_setup>();

            string sql = "select * from company_setup order by id";

            DataTable dtr = SqlHelper.ExecuteDataset(CommandType.Text, sql).Tables[0];
            if (dtr.Rows.Count > 0)
            {
                foreach (DataRow dr in dtr.Rows)
                {
                    company_setup.Add(new macreel_setup.Models.Setup.company_setup()
                    {
                        comp_name = dr["comp_name"].ToString(),
                        address = dr["address"].ToString(),
                        logo = dr["logo"].ToString(),
                        admin_userid = dr["admin_userid"].ToString(),
                        subs_startdate = dr["subs_startdate"].ToString(),
                        subs_enddate = dr["subs_enddate"].ToString(),
                        admin_name = dr["admin_name"].ToString(),
                        contact_no = dr["contact_no"].ToString(),
                        email = dr["email"].ToString(),
                        gst_no = dr["gst_no"].ToString(),
                        user_allowed = dr["user_allowed"].ToString(),
                        software_price = dr["software_price"].ToString(),
                        gst_price = dr["gst_price"].ToString(),
                        total = dr["total"].ToString(),
                        amc_price = dr["amc_price"].ToString(),
                        amc_startdate = dr["amc_startdate"].ToString(),
                        amc_enddate = dr["amc_enddate"].ToString(),
                        support = dr["support"].ToString(),
                        domain = dr["domain"].ToString(),
                        domain_name = dr["domain_name"].ToString(),
                        domain_price = dr["domain_price"].ToString(),
                        domain_renewal_date = dr["domain_renewal_date"].ToString(),
                        server = dr["server"].ToString(),
                        server_name = dr["server_name"].ToString(),
                        server_price = dr["server_price"].ToString(),
                        server_renewal_date = dr["server_renewal_date"].ToString(),

                    });
                }
            }

            return View(company_setup);
        }

        public ActionResult delet_companysetup(string id)
        {
            string str = "delete from company_setup where id='" + id + "'";

            SqlHelper.ExecuteNonQuery(CommandType.Text, str);

            return RedirectToAction("view_product");
        }


        #endregion

    }
}