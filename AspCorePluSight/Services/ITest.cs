using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePluSight.Services
{
    public interface ITest
    {

        IEnumerable<int> Except();
        IEnumerable<int> Intersect();
        IEnumerable<int> Union();
      


    }
}
