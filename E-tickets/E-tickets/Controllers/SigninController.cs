using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace E_tickets.Controllers
{
    public class SigninController : Controller
    {
        // GET: Signin
        public ActionResult Index()
        {
            return View();
        }

        

        [HttpPost]
        public JsonResult LoginUser(string email, string password)
        {
            
                DataTable DT = new DataTable();
           
                String CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string strCmd = "select * from passenger where email = '" + email + "' and password = '" + password + "'";
                SqlDataAdapter DA = new SqlDataAdapter(strCmd,con);
                DA.Fill(DT);
                con.Close();



                if (DT.Rows.Count > 0)
                {
                    Session["pid"] = DT.Rows[0]["pid"];
                    Session["name"] = DT.Rows[0]["name"];
                    Session["email"] = DT.Rows[0]["email"];
                    Session["ptype"] = DT.Rows[0]["ptype"];
                    Session["phone_no"] = DT.Rows[0]["phone_no"];
                return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }   

        }
        public ActionResult Logout()
        {
            Session["name"] = null;
            Session["pid"] = null;
            
             return RedirectToAction("Index", "Home");
            
        }

        public ActionResult Profile()
        {
            return null;
        }

    }
}