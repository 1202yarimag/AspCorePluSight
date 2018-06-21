using AspCorePluSight.Models;
using System.Collections.Generic;

namespace AspCorePluSight.Services
{
    public interface IRestaurantData
    {

         IEnumerable<Restaurant> GetData();
        Restaurant  Get(int id);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Update(Restaurant restaurant);
    }
}
