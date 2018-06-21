using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePluSight.Models
{
    public class AutoEditModel
    {
        [Required]
        public Brand Brand { get; set; }
        [Required, MaxLength(80)]

        public string Name { get; set; }
        [Required]

        public int Power { get; set; }
    }
}
