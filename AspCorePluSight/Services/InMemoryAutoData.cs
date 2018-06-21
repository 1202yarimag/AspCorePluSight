using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCorePluSight.Models;

namespace AspCorePluSight.Services
{
    public class InMemoryAutoData : IAuto
    {
        private List<Auto> _autos;

        public InMemoryAutoData()
        {
            _autos = new List<Auto> { new Auto { Id=1, brand=Brand.BMW, Name="5.20", Power=300 },
                new Auto { Id = 2, brand = Brand.Honda, Name = "Civic", Power = 150 } ,
            new Auto { Id=3, brand=Brand.Opel, Name="Astra", Power=180 },
            new Auto { Id=4, brand=Brand.Toyota, Name="Corolla", Power=200 }};
        }

        public Auto Add(Auto newAuto)
        {
            newAuto.Id = _autos.Max(x => x.Id )+1;
            _autos.Add(newAuto);
           
           
            return newAuto;
        }

        public Auto Get(int id)
        {
            return _autos.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Auto> GetData()
        {

            return _autos.OrderBy(x => x.brand);
        }
    }
}
