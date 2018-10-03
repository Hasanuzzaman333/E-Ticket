using E_tickets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_tickets.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index()
        {
            BusdbEntities busdb = new BusdbEntities();
            List<rbschedule> lrbs = busdb.rbschedules.ToList();

            RbScheduleM rbs = new RbScheduleM();            

            List<RbScheduleM> SListNew = lrbs.Select(x => new RbScheduleM
            {
                sid = x.sid,
                rid = x.rid,
                fare =  x.fare,
                departure_date = x.departure_date,
                departure_time = x.departure_time,
                bid = x.bid

            }).ToList();

            return View(SListNew);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RbScheduleM xx)
        {
            BusdbEntities db = new BusdbEntities();
            rbschedule r = new rbschedule();

            r.sid = xx.sid;
            r.rid = xx.rid;
            r.bid = xx.bid;
            r.fare = xx.fare;
            r.departure_date = xx.departure_date;
            r.departure_time = xx.departure_time;

            db.rbschedules.Add(r);
            db.SaveChanges();

            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
           
            BusdbEntities db = new BusdbEntities();
            RbScheduleM find = new RbScheduleM();
            var xx = db.rbschedules.Where(x => x.sid == id).FirstOrDefault();

            find.sid = xx.sid;
            find.rid = xx.rid;
            find.bid = xx.bid;
            find.fare = xx.fare;
            find.departure_date = xx.departure_date;
            find.departure_time = xx.departure_time;

            return View(find);
        }

        [HttpPost]
        public ActionResult Edit(RbScheduleM xx)
        {
            BusdbEntities db = new BusdbEntities();

            var find = db.rbschedules.Where(x => x.sid == xx.sid).FirstOrDefault();

            find.sid = xx.sid;
            find.rid = xx.rid;
            find.bid = xx.bid;
            find.fare = xx.fare;
            find.departure_date = xx.departure_date;
            find.departure_time = xx.departure_time;

            db.Entry(find).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("index");

        }

        public ActionResult Details(int id)
        {
            BusdbEntities db = new BusdbEntities();
            RbScheduleM find = new RbScheduleM();
            var xx = db.rbschedules.Where(x => x.sid == id).FirstOrDefault();

            find.sid = xx.sid;
            find.rid = xx.rid;
            find.bid = xx.bid;
            find.fare = xx.fare;
            find.departure_date = xx.departure_date;
            find.departure_time = xx.departure_time;



            return View(find);
        }

        public ActionResult Delete(int id)
        {
            BusdbEntities db = new BusdbEntities();
            RbScheduleM find = new RbScheduleM();
            var xx = db.rbschedules.Where(x => x.sid == id).FirstOrDefault();

            db.rbschedules.Remove(xx);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
