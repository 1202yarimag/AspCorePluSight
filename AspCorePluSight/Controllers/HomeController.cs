using AspCorePluSight.Models;
using AspCorePluSight.Services;
using AspCorePluSight.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspCorePluSight.Controllers
{
    public class HomeController:Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData,IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            //var model = new Restaurant { Id = 1, Name = "Scotty's Place" };
            //return Content("Hello from mörika");
            //return new ObjectResult(model);      
            //{ "id":1,"name":"Scotty's Place"}
            //var model = _restaurantData.GetData();
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetData();
            model.CurrentMessage = _greeter.GetMessage();
            return View(model);
        }
        public IActionResult Detail(int id)
        {
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
