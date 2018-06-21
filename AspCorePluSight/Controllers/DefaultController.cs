using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCorePluSight.Models;
using AspCorePluSight.Services;
using AspCorePluSight.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


namespace AspCorePluSight.Controllers
{
    public class DefaultController : Controller
    {
        private ILogger<HomeController> _logger;
        private IRestaurantData _restaurantData;
        private IAuto _auto;

        public DefaultController(IAuto auto,IRestaurantData restaurantData,ILogger<HomeController> logger)
        {
          
            _logger = logger;
            _restaurantData = restaurantData;
            _auto = auto;
        }
        public  IActionResult Index()
        {
            
            var model = new MixedViewModel();
            model.Autos = _auto.GetData();
            model.Restaurants = _restaurantData.GetData();
            return View(model);
        }
        public IActionResult Detail (int id)
        {
            var model = _auto.Get(id);

            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AutoEditModel autoEditModel)
        {
            if (ModelState.IsValid)
            {
                var auto = new Auto();
                auto.Name = autoEditModel.Name;
                auto.Power = autoEditModel.Power;
                auto.brand = autoEditModel.Brand;
                auto=_auto.Add(auto);
                return View("Detail", auto);

                //return RedirectToAction(nameof(Detail), new { id = auto.Id });

            }
            else
            {
                return View();

            }
        }
    }
}