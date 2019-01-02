using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePluSight.ViewModels
{
    public class TestMixedViewModel
    {
        public IEnumerable<int> Excepts { get; set; }
        public IEnumerable<int> Unions { get; set; }
        public IEnumerable<int> Intersects { get; set; }
        public IEnumerable<int> Concats { get; set; }

        public IEnumerable<int> Filter { get; set; }

    }
}
