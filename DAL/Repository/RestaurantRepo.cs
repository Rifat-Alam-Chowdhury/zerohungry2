using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class RestaurantRepo
    {
        FoodmanagmentsystemContext db;

        public RestaurantRepo(FoodmanagmentsystemContext db)
        {
            this.db = db;
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return db.Restaurants.ToList();
        }


        public Restaurant GetRestaurantById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public bool AddRestaurant(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            return db.SaveChanges() > 0;
        }

        public bool UpdateRestaurant(Restaurant restaurant)
        {
            var existingRestaurant = db.Restaurants.Find(restaurant.RestaurantId);
            if (existingRestaurant != null)
            {
                existingRestaurant.Name = restaurant.Name;
                existingRestaurant.Phone = restaurant.Phone;
                existingRestaurant.Email = restaurant.Email;
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteRestaurant(int id)
        {
            var restaurant = db.Restaurants.Find(id);
            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
