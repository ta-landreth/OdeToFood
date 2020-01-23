using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFood.Web.Api
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData db;

        // vs MVC Controller; the method/action is in the URL
        // in API, which method depends on the HTTP Method of the incoming request

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        public IEnumerable<Restaurant> Get()
        {
            return db.GetAll();
        }

        public Restaurant Get(int id)
        {
            return db.Get(id);
        }
    }
}
