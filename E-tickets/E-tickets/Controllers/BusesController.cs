using E_tickets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_tickets.Controllers
{
    public class BusesController : Controller
    {
        // GET: Buses
        public ActionResult Index()
        {
            BusdbEntities busdb = new BusdbEntities();
            List<bus> B = busdb.buses.ToList();
            Buses busnew = new Buses();
            List<Buses> BusListNew = B.Select(x => new Buses
            {
                Busid = x.bid,
                BusName = x.bname,
                BusType = x.btype,
                MaxSeat = x.max_seats,

            }).ToList();
            return View(BusListNew);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Buses xx)
        {
            BusdbEntities db = new BusdbEntities();
            bus r = new bus();

            r.bid = xx.Busid;
            r.bname = xx.BusName;
            r.btype = xx.BusType;
            r.max_seats = xx.MaxSeat;

            db.buses.Add(r);
            db.SaveChanges();

            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            BusdbEntities db = new BusdbEntities();
            Buses find = new Buses();

            var xx = db.buses.Where(x => x.bid == id).FirstOrDefault();

            find.Busid = xx.bid;
            find.BusName = xx.bname;
            find.BusType = xx.btype;
            find.MaxSeat = xx.max_seats;


            return View(find);
        }

        [HttpPost]
        public ActionResult Edit(Buses xx)
        {
            BusdbEntities db = new BusdbEntities();

            var find = db.buses.Where(x => x.bid == xx.Busid).FirstOrDefault();

            find.bid = xx.Busid;
            find.bname = xx.BusName;
            find.btype = xx.BusType;
            find.max_seats = xx.MaxSeat;

            db.Entry(find).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("index");

        }

        public ActionResult Details(int id)
        {
            BusdbEntities db = new BusdbEntities();
            Buses find = new Buses();
            var xx = db.buses.Where(x => x.bid == id).FirstOrDefault();

            find.Busid = xx.bid;
            find.BusName = xx.bname;
            find.BusType = xx.btype;
            find.MaxSeat = xx.max_seats;
            

            return View(find);
        }

        public ActionResult Delete(int id)
        {
            BusdbEntities db = new BusdbEntities();
            Buses find = new Buses();
            var xx = db.buses.Where(x => x.bid == id).FirstOrDefault();

            db.buses.Remove(xx);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}