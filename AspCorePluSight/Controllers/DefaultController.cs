using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCorePluSight.Models;
using AspCorePluSight.Services;
using AspCorePluSight.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


namespace AspCorePluSight.Controllers
{
    public class DefaultController : Controller
    {
        private ITest _test;
        private IMemoryCache _cache;
        private ILogger<HomeController> _logger;
        private IRestaurantData _restaurantData;
        private IAuto _auto;
        private IEnumerable<int> _benzersiz;
        private IDistributedCache _distributedCache;

        public DefaultController(IAuto auto, IRestaurantData restaurantData, ILogger<HomeController> logger, IDistributedCache distributedCache, IMemoryCache memoryCache,ITest test)
        {
            _distributedCache = distributedCache;
            _test = test;
            _cache = memoryCache;
            _logger = logger;
            _restaurantData = restaurantData;
            _auto = auto;
        }
        public IActionResult Index()
        {
            var model = new MixedViewModel();
            model.Autos = _auto.GetData();
            model.Restaurants = _restaurantData.GetData();
            return View(model);
        }
        public IActionResult Detail(int id)
        {
            var model = _auto.Get(id);
         
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
        //    IList<Student> studentList = new List<Student> {
        //        new Student {  StudentID = 1, StudentName = "John", Age = 13 } ,
        //new Student { StudentID = 2, StudentName = "Moin", Age = 21 } ,
        //new Student { StudentID = 3, StudentName = "Bill", Age = 18 } ,
        //new Student { StudentID = 4, StudentName = "Ram", Age = 20 } ,
        //new Student { StudentID = 5, StudentName = "Ron", Age = 15 }
        //    };

        //    var teeenagers = from s in studentList
        //                     where s.Age > 12 && s.Age < 20
        //                     select s;
            
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
                auto = _auto.Add(auto);
                return View("Detail", auto);

                //return RedirectToAction(nameof(Detail), new { id = auto.Id });

            }
            else
            {

                return View();

            }
        }
        public IActionResult Test()
        {
            var model =new TestMixedViewModel();
            model.Unions = _test.Union();
            model.Intersects = _test.Intersect();
            model.Excepts = _test.Except();
            model.Concats = _test.Concat();
            model.Filter = _test.Filter();

            
            return View(model);
        }
        public IActionResult Cache()
        {
            DateTime cacheEntry;

            // Look for cache key.
            if (!_cache.TryGetValue("CacheKeys.Entry", out cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = DateTime.Now;

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    //.SetPriority(CacheItemPriority.NeverRemove)
                    //.SetAbsoluteExpiration(TimeSpan.FromSeconds(3))
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10));

                // Save data in cache.
                _cache.Set("CacheKeys.Entry", cacheEntry, cacheEntryOptions);

            }
            return View("Cache", cacheEntry);
        }

        public async  Task<IActionResult> Redis()
        {
            //  var cacheKey ="IDG";
            //  _distributedCache.Remove(cacheKey);
            //  _distributedCache.Remove("ping");

            //  var data = _distributedCache.GetString(cacheKey);

            //if (!string.IsNullOrEmpty(data))
            //{
            //    ViewBag.redis = _distributedCache.GetString("ping");

            //      //ViewBag.redis= data.ToString(); //returned from Cache
            //  }
            //  else
            //{


            //     ViewBag.redis= _distributedCache.GetString("ping");
            //  }

            var cacheKey = "Time";
            var existingTime = _distributedCache.GetString(cacheKey);
            if (string.IsNullOrEmpty(existingTime))
            {
                existingTime = DateTime.UtcNow.ToString();
                var option = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(5));
                option.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5);
                string name = await _distributedCache.GetStringAsync("Name");
                await _distributedCache.SetStringAsync(cacheKey, $"{name}: {existingTime}", option);

            }
            ViewBag.Time = await _distributedCache.GetStringAsync(cacheKey);

            return View();
        }
        //public IActionResult CacheGetOrCreate()
        //{
        //    var cacheEntry = _cache.GetOrCreate(CacheKeys.Entry, entry =>
        //    {
        //        entry.SlidingExpiration = TimeSpan.FromSeconds(3);
        //        return DateTime.Now;
        //    });

        //    return View("Cache", cacheEntry);
        //}

        //public async Task<IActionResult> CacheGetOrCreateAsync()
        //{
        //    var cacheEntry = await
        //        _cache.GetOrCreateAsync(CacheKeys.Entry, entry =>
        //        {
        //            entry.SlidingExpiration = TimeSpan.FromSeconds(3);
        //            return Task.FromResult(DateTime.Now);
        //        });

        //    return View("Cache", cacheEntry);
        //}
        //public IActionResult CacheGet()
        //{
        //    var cacheEntry = _cache.Get<DateTime?>(CacheKeys.Entry);
        //    return View("Cache", cacheEntry);
        //}


        public IActionResult Dictionary()
        {
            Dictionary <int,string> a = new Dictionary<int,string>();
            a.Add(0, "Hakan");
            return View(a);
        }

    }
}