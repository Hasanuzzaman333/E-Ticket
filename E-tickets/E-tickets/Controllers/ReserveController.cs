using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_tickets.Models;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity;

using CrystalDecisions.CrystalReports.Engine;

using System.IO;

namespace E_tickets.Controllers
{
    public class ReserveController : Controller
    {

        // GET: Reserve
        public ActionResult Index()
        {
            BusdbEntities busdb = new BusdbEntities();
            List<reserve> R = busdb.reserves.ToList();
            ReserveM ReserveNew = new ReserveM();
            List<ReserveM> ReserveListNew = R.Select(x => new ReserveM
            {
                email = x.email,
                gender = x.gender,
                name = x.name,
                phone_no = x.phone_no,
                routeId = x.rid,
                scheduleId = x.sid,
                seat_no = x.seat_no,
                ticket_no = x.ticket_no,


            }).ToList();
            return View(ReserveListNew);
        }

        public ActionResult Create()
        {
            return RedirectToAction("index","Home");
        }
  

        public ActionResult Edit(int id)
        {
            BusdbEntities busdb = new BusdbEntities();
            List<reserve> R = busdb.reserves.ToList();
            ReserveM ReserveNew = new ReserveM();
            List<ReserveM> ReserveListNew = R.Select(x => new ReserveM
            {
                email = x.email,
                gender = x.gender,
                name = x.name,
                phone_no = x.phone_no,
                routeId = x.rid,
                scheduleId = x.sid,
                seat_no = x.seat_no,
                ticket_no = x.ticket_no,


            }).ToList();

            ReserveM reserveSingle = ReserveListNew.Single(y => y.ticket_no == id);

            return View(reserveSingle);
            
        }

        [HttpPost]
        public ActionResult Edit(ReserveM xx)
        {
            BusdbEntities db = new BusdbEntities();

            var find = db.reserves.Where(x => x.ticket_no == xx.ticket_no).FirstOrDefault();

            find.email = xx.email;
            find.gender = xx.gender;
            find.name = xx.name;
            find.phone_no = xx.phone_no;
            find.rid = xx.routeId;
            find.sid = xx.scheduleId;
            find.seat_no = xx.seat_no;
            find.ticket_no = xx.ticket_no;

            db.Entry(find).State = EntityState.Modified;
            db.SaveChanges();
            
            return RedirectToAction("index");

        }

        public ActionResult Details(int id)
        {
            BusdbEntities db = new BusdbEntities();
            ReserveM find = new ReserveM();
            var xx = db.reserves.Where(x => x.ticket_no == id).FirstOrDefault();

            find.email = xx.email;
            find.gender = xx.gender;
            find.name = xx.name;
            find.phone_no = xx.phone_no;
            find.routeId = xx.rid;
            find.scheduleId = xx.sid;
            find.seat_no = xx.seat_no;
            find.ticket_no = xx.ticket_no;

            return View(find);
        }

        public ActionResult Delete(int id)
        {
            BusdbEntities db = new BusdbEntities();
            ReserveM find = new ReserveM();
            var xx = db.reserves.Where(x => x.ticket_no == id).FirstOrDefault();
            
            db.reserves.Remove(xx);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PrintTickets(int id)
        {
            //BusdbEntities busdb = new BusdbEntities();
            //List<reserve> R = busdb.reserves.ToList();
            //ReserveM ReserveNew = new ReserveM();
            //List<ReserveM> ReserveListNew = R.Select(x => new ReserveM
            //{
            //    email = x.email,
            //    gender = x.gender,
            //    name = x.name,
            //    phone_no = x.phone_no,
            //    routeId = x.rid,
            //    scheduleId = x.sid,
            //    seat_no = x.seat_no,
            //    ticket_no = x.ticket_no,


            //}).ToList();

            //ReserveM reserveSingle = ReserveListNew.Single(y => y.ticket_no == id);

            BusdbEntities db = new BusdbEntities();
            ReserveM find = new ReserveM();
            var xx = db.reserves.Where(x => x.ticket_no == id).FirstOrDefault();

            find.email = xx.email;
            find.gender = xx.gender;
            find.name = xx.name;
            find.phone_no = xx.phone_no;
            find.routeId = xx.rid;
            find.scheduleId = xx.sid;
            find.seat_no = xx.seat_no;
            find.ticket_no = xx.ticket_no;


            List<ReserveM> nn = new List<ReserveM>();

            nn.Add(find);

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/report"), "PrintTicket.rpt"));
            rd.SetDataSource(nn);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "ticket.pdf");
            }
            catch
            {
                throw;
            }

        }

        }
}