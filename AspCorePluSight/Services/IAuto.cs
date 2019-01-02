using AspCorePluSight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePluSight.Services
{
 public   interface IAuto
    {
        IEnumerable<Auto> GetData();
        Auto Get(int id);
        Auto Add(Auto newAuto);
        Auto Update(Auto auto);
    }
}
