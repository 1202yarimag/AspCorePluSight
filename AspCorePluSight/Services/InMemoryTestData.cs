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
        private IEnumerable<int> _concat;
        private IEnumerable<int> _filter;

        private int[] Rakamlar1 = { 0,1, 2, 4, 5, 8, 10 ,-3};
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

        public IEnumerable<int> Concat()
        {
            _concat = Rakamlar1.Concat(Rakamlar2);
            return _concat;
        }

        public IEnumerable<int> Filter()
        {
            var concat = Rakamlar1.Concat(Rakamlar2);
            _filter = from c in concat
                      where c < 3 && c > 0
                      select c;
            return _filter;
        }
    }
}
