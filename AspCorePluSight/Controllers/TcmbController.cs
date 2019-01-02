using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspCorePluSight.Models;
using AspCorePluSight.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspCorePluSight.Controllers
{
    public class TcmbController : Controller
    {
       private IApiClient<HomeApiResponseModel> _apiClient;

        public TcmbController(IApiClient<HomeApiResponseModel> apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ActionResult>  Index()
        {
            HomeApiResponseModel model = new HomeApiResponseModel();
            model = await _apiClient.GetAsync(@"http://www.tcmb.gov.tr/kurlar/today.xml");
            return View(model);
        }
    }
}