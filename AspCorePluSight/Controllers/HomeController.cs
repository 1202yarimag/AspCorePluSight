using AspCorePluSight.Models;
using AspCorePluSight.Services;
using AspCorePluSight.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePluSight.Controllers
{
    public class HomeController:Controller
    {
        private IMemoryCache _memorycache;
        private ILogger<HomeController> _logger;
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData,IGreeter greeter, ILogger<HomeController> logger,IMemoryCache memoryCache)
        {
            _memorycache = memoryCache;
            _logger = logger;
            _restaurantData = restaurantData;
            _greeter = greeter;
        }
      
        [AllowAnonymous]
        public IActionResult Index()
        {
            //var model = new Restaurant { Id = 1, Name = "Scotty's Place" };
            //return Content("Hello from mörika");
            //return new ObjectResult(model);      
            //{ "id":1,"name":"Scotty's Place"}n  
            //var model = _restaurantData.GetData();
            _logger.LogInformation("Home/Index Executing...");
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetData();
            
            model.CurrentMessage = _greeter.GetMessage();
            return View(model);
        }
        public IActionResult Detail(int id)
        {

           
          
            _logger.LogInformation("Home/Detail Executing...");

            var model = _restaurantData.Get(id);
            //if (model==null)
            //{
            //return RedirectToAction("Index", "Home");
            //return RedirectToAction(nameof(Index));
            //return NotFound();
            //}
            return View(model);
        }

        [HttpGet]
        [Authorize ]
        public IActionResult Create ()
        {
            //if (User.Identity.IsAuthenticated)
            _logger.LogInformation("Home/Create Executing...");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Create(RestaurantEditModel model)
        {
            if (ModelState.IsValid)
            {


                var newRestaurant = new Restaurant();
                newRestaurant.Name = model.Name;
                newRestaurant.Cuisine = model.Cuisine;
                newRestaurant = _restaurantData.Add(newRestaurant);

                //return View("Detail", newRestaurant);


                return RedirectToAction(nameof(Detail), new { id = newRestaurant.Id });
            }
            else
            {
                return View();
            }

        }

    }
}
