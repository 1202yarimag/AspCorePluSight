using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePluSight.Models
{
    public class RestaurantEditModel
    {
        [Required, MaxLength(80)]

        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
