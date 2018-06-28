using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePluSight.Services
{
    public class InMemoryTestData:ITest
    {
        private IEnumerable<int> _union;
        private IEnumerable<int> _intersect;
        private IEnumerable<int> _except;


        private int[] Rakamlar1 = { 1, 2, 4, 5, 8, 10 };
        private int[] Rakamlar2 = { 1, 3, 4, 6, 5, 25 };

        public IEnumerable<int> Union()
        {
            _union = Rakamlar1.Union(Rakamlar2);
            return _union;
        }

        public IEnumerable<int> Intersect()
        {
            _intersect = Rakamlar1.Intersect(Rakamlar2);
            return _intersect;
        }

        public IEnumerable<int> Except()
        {
            _except = Rakamlar1.Except(Rakamlar2);
            return _except;
        }
    }
}
