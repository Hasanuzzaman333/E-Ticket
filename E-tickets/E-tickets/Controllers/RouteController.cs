using E_tickets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_tickets.Controllers
{
    public class RouteController : Controller
    {
        // GET: Route
        public ActionResult Index()
        {
            BusdbEntities busdb = new BusdbEntities();
            List<route> routeList = busdb.routes.ToList();

            RouteM rbs = new RouteM();

            List<RouteM> RListNew = routeList.Select(x => new RouteM
            {
                 Routeid = x.rid,
                 FromLocation = x.from_location,
                 ToLocation = x.to_location,
                

            }).ToList();

            return View(RListNew);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RouteM xx)
        {
            BusdbEntities db = new BusdbEntities();
            route r = new route();

            r.rid = xx.Routeid;
            r.from_location = xx.FromLocation;
            r.to_location = xx.ToLocation;

            db.routes.Add(r);
            db.SaveChanges();

            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {

            BusdbEntities db = new BusdbEntities();
            RouteM find = new RouteM();
            var xx = db.routes.Where(x => x.rid == id).FirstOrDefault();

            find.Routeid = xx.rid;
            find.FromLocation = xx.from_location;
            find.ToLocation = xx.to_location;
            
            return View(find);
        }

        [HttpPost]
        public ActionResult Edit(RouteM xx)
        {
            BusdbEntities db = new BusdbEntities();

            var find = db.routes.Where(x => x.rid == xx.Routeid).FirstOrDefault();

            find.rid = xx.Routeid;
            find.from_location = xx.FromLocation;
            find.to_location = xx.ToLocation;
            
            db.Entry(find).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("index");

        }

        public ActionResult Details(int id)
        {
            BusdbEntities db = new BusdbEntities();
            RouteM find = new RouteM();
            var xx = db.routes.Where(x => x.rid == id).FirstOrDefault();

            find.Routeid = xx.rid;
            find.FromLocation = xx.from_location;
            find.ToLocation = xx.to_location;
            

            return View(find);
        }

        //public ActionResult Delete(int id)
        //{
        //    BusdbEntities db = new BusdbEntities();
        //    RouteM find = new RouteM();
        //    var xx = db.routes.Where(x => x.rid == id).FirstOrDefault();

        //    db.routes.Remove(xx);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}