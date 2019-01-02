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
            _autos = new List<Auto> { new Auto { Id=1, brand=Brand.BMW, Name="5.20", Power=300, ImageUrl="https://static.cargurus.com/images/site/2017/07/25/14/57/2017_bmw_m4_coupe-pic-7306789692753581637-200x200.jpeg" },
                new Auto { Id = 2, brand = Brand.Honda, Name = "Civic", Power = 150, ImageUrl="https://media.ed.edmunds-media.com/honda/civic/2018/oem/2018_honda_civic_sedan_touring_f_oem_1_150.jpg" } ,
            new Auto { Id=3, brand=Brand.Opel, Name="Astra", Power=180, ImageUrl="https://image.shutterstock.com/image-photo/budapest-hungary-november-27-2015-260nw-344749325.jpg" },
            new Auto { Id=4, brand=Brand.Toyota, Name="Corolla", Power=200, ImageUrl="https://static.cargurus.com/images/site/2018/02/27/10/59/2018_toyota_corolla-pic-7443924859934418452-640x480.jpeg" }};
 
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

        public Auto Update(Auto auto)
        {
            var a=_autos.FirstOrDefault(x => x.Id == auto.Id);
            a.Name = "Hakan------";
            return auto;
        }
    }
}
