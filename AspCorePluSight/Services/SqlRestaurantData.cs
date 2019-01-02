using System;
using System.Collections.Generic;
using System.Linq;
using AspCorePluSight.Data;
using AspCorePluSight.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCorePluSight.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFodDbContext _context;

        public SqlRestaurantData(OdeToFodDbContext context)
        {
            _context = context;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            _context.Restaurants.Add(newRestaurant);
            _context.SaveChanges();
            return newRestaurant;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetData()
        {
         return   _context.Restaurants.OrderBy(x => x.Id);
        }

        public Restaurant Update(Restaurant restaurant)
        {
            _context.Attach(restaurant).State = EntityState.Modified;
            _context.SaveChanges();
            return restaurant;
        }
    }
}
