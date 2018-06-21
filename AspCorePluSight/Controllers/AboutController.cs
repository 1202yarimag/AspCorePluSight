using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;

namespace AspCorePluSight.Controllers
{

    //[Route("company/[controller]/[action]")]    
    public class AboutController:Controller
    {
        private IDistributedCache _distributedCache;

        public AboutController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
       
            public async Task<IActionResult> Phone()
            {
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
        public string Adress () {
            return "Manhattan";
        }
    }
}
