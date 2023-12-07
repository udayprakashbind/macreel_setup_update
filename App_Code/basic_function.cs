using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using macreel_setup.Models.admin;

namespace macreel_setup.App_Code
{
    public class basic_function
    {

        #region login

        public Models.common_response login(string username, string password)
        {
            Models.common_response Response = new Models.common_response();

            #region Validation

            if (username == null || username == "")
            {
                Response.message = "Invalid Username.";
                return Response;
            }

            if (password == null || password == "")
            {
                Response.message = "Invalid password (must include atleast 8 charaters,uppercase and lowercase alphabhet, one number and one special charater).";
                return Response;
            }

            username = username.Replace("'", "''").Trim();
            password = password.Replace("'", "''").Trim();


            #endregion;

            #region Check User
            {

                SqlParameter[] para = new SqlParameter[3];

                para[0] = new SqlParameter("@username", SqlDbType.NVarChar);
                para[0].Value = username;

                para[1] = new SqlParameter("@password", SqlDbType.NVarChar);
                para[1].Value = password;

               DataTable dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_checksuper_admin", para).Tables[0];
              //  DataTable dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_login", para).Tables[0];

                if (dt.Rows.Count < 1)
                {
                    Response.message = "Invalid username or password!.";
                    return Response;
                }



                if (dt.Rows.Count > 0)
                {
               // Response.username= username;
               // Response.usertype= dt.row[0].[""];
                 Response.usertype = dt.Rows[0]["employee_type"].ToString();
                 Response.username = dt.Rows[0]["employee_first_name"].ToString();
                 Response.employeeId = dt.Rows[0]["employee_id"].ToString();
                 Response.useremail = dt.Rows[0]["login_userid"].ToString();

                }


                Response.success = true;
                Response.parameter = username;
            }
            #endregion;

            return Response;
        }
        #endregion

        #region check Session

        public Boolean adminssioncheck(string viewdashboaradds)
        {
            Boolean ischeck = false;
            if (HttpContext.Current.Session["adminname"] != null)
            {
                ischeck = true;
            }

            return ischeck;
        }
        #endregion

        #region admin info

        public macreel_setup.Models.admininfo admininfo(string agencyid)
        {
            Models.admininfo Response = new Models.admininfo();
            string str = "select * from super_admin where username='" + agencyid + "'";
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, str);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                return Response;
            }


            Response.name = dt.Rows[0]["username"].ToString();
            Response.agencyid = dt.Rows[0]["id"].ToString();
            //Response.ip_address = dc.Rows[0]["ip_address"].ToString();
            //Response.logintime = dc.Rows[0]["created_on"].ToString();

            if (Response.logintime != null && Response.logintime != "")
            {
                Response.logintime = Convert.ToDateTime(Response.logintime).ToString("dd MMM yyyy  hh : mm tt");

            }

            return Response;
        }


        #endregion

        #region manage branch

        public Models.common_response manage_branch(macreel_setup.Models.admin.manage_branch manage_branch)
        {
            var action = "insert";
            if (!string.IsNullOrEmpty(manage_branch.id))
            {
                action = "update";
            }

            SqlParameter[] para = new SqlParameter[19];

            para[0] = new SqlParameter("@BranchName", SqlDbType.NVarChar);
            para[0].Value = manage_branch.BranchName;

            para[1] = new SqlParameter("@BranchEmail", SqlDbType.NVarChar);
            para[1].Value = manage_branch.BranchEmail;

            para[2] = new SqlParameter("@ContactPerson", SqlDbType.NVarChar);
            para[2].Value = manage_branch.ContactPerson;

            para[3] = new SqlParameter("@LandLineNo", SqlDbType.NVarChar);
            para[3].Value = manage_branch.LandLineNo;

            para[4] = new SqlParameter("@ContactPersonMobile", SqlDbType.NVarChar);
            para[4].Value = manage_branch.ContactPersonMobile;

            para[5] = new SqlParameter("@ContactPersonEmail", SqlDbType.NVarChar);
            para[5].Value = manage_branch.ContactPersonEmail;

            para[6] = new SqlParameter("@GSTNo", SqlDbType.NVarChar);
            para[6].Value = manage_branch.GSTNo;

            para[7] = new SqlParameter("@PanNo", SqlDbType.NVarChar);
            para[7].Value = manage_branch.PanNo;

            para[8] = new SqlParameter("@BranchRegistrationNo", SqlDbType.NVarChar);
            para[8].Value = manage_branch.BranchRegistrationNo;

            para[9] = new SqlParameter("@StateName", SqlDbType.NVarChar);
            para[9].Value = manage_branch.StateName;

            para[10] = new SqlParameter("@StateCode", SqlDbType.NVarChar);
            para[10].Value = manage_branch.StateCode;

            para[11] = new SqlParameter("@CityName", SqlDbType.NVarChar);
            para[11].Value = manage_branch.CityName;

            para[12] = new SqlParameter("@CityCode", SqlDbType.NVarChar);
            para[12].Value = manage_branch.CityCode;

            para[13] = new SqlParameter("@PinCode", SqlDbType.NVarChar);
            para[13].Value = manage_branch.PinCode;

            para[14] = new SqlParameter("@RegistrationDate", SqlDbType.NVarChar);
            para[14].Value = manage_branch.RegistrationDate;

            para[15] = new SqlParameter("@BranchAddress", SqlDbType.NText);
            para[15].Value = manage_branch.BranchAddress;

            para[16] = new SqlParameter("@id", SqlDbType.NVarChar);
            para[16].Value = manage_branch.id;

            para[17] = new SqlParameter("@action", SqlDbType.NVarChar);
            para[17].Value = action;

            SqlParameter resultParameter = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 100);
            resultParameter.Direction = ParameterDirection.Output;
            para[18] = resultParameter; // Add the resultParameter to the parameter array.

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "sp_manageBranch", para);


            var resultMessage = para[18].Value.ToString();

            // Create a response object or use your existing "Response" object to return the result message.
            Models.common_response Response = new Models.common_response();
            Response.message = resultMessage;

            return Response;
        }




            #endregion

     }
}