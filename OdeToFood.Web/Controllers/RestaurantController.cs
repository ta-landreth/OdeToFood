using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantController : Controller
    {
        readonly IRestaurantData db;
        public RestaurantController(IRestaurantData data)
        {
            db = data;
        }
        // GET: Restaurant
        public ActionResult Index(string name)
        {
            var model = db.GetAll();

            // pulling config data from Web.config
            var test = ConfigurationManager.AppSettings["connectionString"];

            // Comes in from query string:
            var n = name ?? "no name given";

            // View only accepts a model instance
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.Get(id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // These could be ambiguous at first --- MVC framework doesn't know what to talk to when it posts back the form.
        // Need to be more explicit
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //Model binding -- when MVC framework figures out what kind of model is included in the request 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant r)
        {
            db.Add(r);

            return View();
        }
    }
}