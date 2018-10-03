using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;

namespace E_tickets.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SignupUser(string email, string password, string name, string phone)
        {

            

            DataTable DT = new DataTable();
           
            String CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CS;
            con.Open();

            string strCmd = "Insert into passenger(name,email,password,phone_no,ptype) values ('" + name + "','" + email + "','" + password + "','" + phone + "','" + 1 + "')";
            SqlCommand cmd = new SqlCommand(strCmd, con);
            int row = cmd.ExecuteNonQuery();

            string sc = "Select Scope_Identity() as pid";
            SqlDataAdapter DA = new SqlDataAdapter(sc, con);
            DA.Fill(DT);

            con.Close();

                if(row > 0) {
                    
                    
                    Session["pid"] = DT.Rows[0]["pid"];
                    Session["name"] = @name;
                    return Json(new { success = true });
                }

                else {return Json(new { success = false }); }
                     
           
            

        }

        
    }
}