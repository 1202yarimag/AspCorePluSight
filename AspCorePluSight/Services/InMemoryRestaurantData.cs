using AspCorePluSight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePluSight.Services
{
    //public class InMemoryRestaurantData:IRestaurantData
    //{
    //    public InMemoryRestaurantData()
    //    {
    //        _restaurants = new List<Restaurant>
    //        {

    //            new Restaurant{ Id=1, Name="Pitsa la de "},
    //            new Restaurant{ Id=2, Name="De la Pitsa"},
    //            new Restaurant{ Id=3, Name="Sos de Mozarella la pitsa"},
    //            new Restaurant{ Id=4, Name="Villy's handicrafts"}

    //        };




    //    }



    //    public IEnumerable<Restaurant> GetData()
    //    {
    //        return _restaurants.OrderBy(x => x.Id);
    //    }

    //    public Restaurant Get(int id)
    //    {
    //       return _restaurants.FirstOrDefault(x => x.Id == id) ;
    //    }

    //    public Restaurant Add(Restaurant restaurant)
    //    {
    //        restaurant.Id = _restaurants.Max(r => r.Id) + 1;
    //        _restaurants.Add(restaurant);
    //        return restaurant;
    //    }

    //    public Restaurant Update(Restaurant restaurant)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    List<Restaurant> _restaurants;

    //}
}
