﻿using AspCorePluSight.Models;
using System.Collections.Generic;


namespace AspCorePluSight.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentMessage { get; set; }

    }
}
