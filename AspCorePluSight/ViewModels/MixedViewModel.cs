using AspCorePluSight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePluSight.ViewModels
{
    public class MixedViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IEnumerable<Auto> Autos { get; set; }
    }
}
