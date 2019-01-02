using System;

using System.Text;
using System.Threading.Tasks;
using AspCorePluSight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace AspCorePluSight.Controllers
{
    public class RedisController : Controller
    {
        private IDistributedCache _distributedCache;

        public RedisController(IDistributedCache distributedCache)
        {
    
            _distributedCache = distributedCache;
        }
        public   IActionResult Index()
        {
            //if (!string.IsNullOrWhiteSpace(_distributedCache.KeyExists("Person")))
           
            //_distributedCache.Remove("Person");

            
            //_distributedCache.Remove("Person2");
            Person person = new Person();
            person.Name = "Arya";
            person.Age = 2;
            person.Surname = "Chokela";
            person.Gender = Gender.Female;
            var option = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(1));
            option.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(5);
            var data = JsonConvert.SerializeObject(person);
            var dataByte = Encoding.UTF8.GetBytes(data);
            Console.WriteLine(data);
            Console.WriteLine(dataByte);
            _distributedCache.SetString("Person", "deneme");
            _distributedCache.SetString("Person2", "denme2");
            ViewBag.z = _distributedCache.GetString("Person2");


            var personString = _distributedCache.GetString("Person");
            //var person = JsonConvert.DeserializeObject<Person>(personString);

            return View(person);
           
        }
    }
}