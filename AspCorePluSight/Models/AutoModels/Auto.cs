using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePluSight.Models
{
    public class Auto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public string ImageUrl { get; set; }
        public Brand brand { get; set; }
    }
}
