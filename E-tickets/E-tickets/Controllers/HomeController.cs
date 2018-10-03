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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(String Message)
        {
            
             return View(Message);
        }

        public ActionResult Contact()
        {
            return View();
        }

       /* [HttpPost]
        public JsonResult FindBus(string from, string to, string jdate)
        {

            DataTable DT = new DataTable();

            String CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CS;
            con.Open();

            string strCmd = "EXEC spSearchResult '" + from + "','" + to + "','" + jdate + "'";
            SqlDataAdapter DA = new SqlDataAdapter(strCmd, con);
            DA.Fill(DT);
            con.Close();

            ViewBag.ResultTable = "test tb";

            if (DT.Rows.Count > 0)
            {
                
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }

        }*/

        [HttpPost]
        public ActionResult FindBus(string from, string to, string jdate)
        {

            DataTable DT = new DataTable();

            String CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CS;
            con.Open();

            string strCmd = "EXEC spSearchResult '" + from + "','" + to + "','" + jdate + "'";
            SqlDataAdapter DA = new SqlDataAdapter(strCmd, con);
            DA.Fill(DT);

            

            con.Close();

            if (DT.Rows.Count > 0)
            {
                ViewBag.ResultTable = DT;
                return View();
            }
            else
            {
                //ViewBag.ResultTable = "no data found";
                return View();
            }

        }

        public ActionResult ShowSeats(String buttonValue)
        {
            if(Session["pid"] != null) { 
                int bv = Int32.Parse(buttonValue);

                DataTable DT = new DataTable();
                String CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();
            

                string strCmd = "select * from reserves where sid ="+ @bv;
                SqlDataAdapter DA = new SqlDataAdapter(strCmd, con);
                DA.Fill(DT);
                con.Close();

                ViewBag.sid = buttonValue;
                Session["sid"] = buttonValue;

                ViewBag.BoockedSeats = DT;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Signin");
            }


        }


        [HttpPost]
        public ActionResult Reserve(string radio, string name, string phone, string gender, string email)
        {
            int sid = Convert.ToInt32(Session["sid"]);
            int pid = Convert.ToInt32(Session["pid"]);

            String CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CS;
            con.Open();

            string strCmd = "Insert into reserves(rid,pid,name,seat_no,phone_no,gender,email,sid) values (" + 2 + "," + pid + ",'" + name + "','" + radio + "','" + phone + "','" + gender + "','" + email + "'," + sid + ")";
            SqlCommand cmd = new SqlCommand(strCmd, con);
            int row = cmd.ExecuteNonQuery();
            con.Close();


            
            if (row > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("FindBus", "Home");
            }
            
        }
    }
}