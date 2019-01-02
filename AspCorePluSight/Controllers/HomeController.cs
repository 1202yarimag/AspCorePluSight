using AspCorePluSight.Models;
using AspCorePluSight.Services;
using AspCorePluSight.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

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
            //MemoryCacheEntryOptions cacheExpirationOptions = new MemoryCacheEntryOptions();
            //cacheExpirationOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(30);
            //cacheExpirationOptions.Priority = CacheItemPriority.Normal;
            ViewBag.getOrCreate = _memorycache.GetOrCreate<string>("getOr",cacheEntry => {
                return DateTime.Now.ToString()+" --------Cache--------";
            });

            
            DateTime CacheEntry;

            if (!_memorycache.TryGetValue("newCache", out CacheEntry))
            {
                CacheEntry = DateTime.Now;
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.High).SetSlidingExpiration(TimeSpan.FromSeconds(10));
                _memorycache.Set("newCache", CacheEntry, cacheEntryOptions);
            }

            ViewBag.Cache = CacheEntry.ToString();
           // _memorycache.Remove("newCache");
            //ViewBag.Removed = CacheEntry.ToString();
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

            return View();

        }

    }
}
