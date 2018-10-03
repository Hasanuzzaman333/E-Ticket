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
    public class SearchResultController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindBusNormal(string from, string to, string jdate)
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
            
            return View();




        }
    }
}