using AutoMapper;
using BAL.Model;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Services
{
    public class RestaurantService
    {
        RestaurantRepo repo;
        IMapper mapper;

        public RestaurantService(RestaurantRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }


        public List<RestaurantModel> GetAllRestaurants()
        {
            var restaurants = repo.GetAllRestaurants();
            return mapper.Map<List<RestaurantModel>>(restaurants);
        }

        public RestaurantModel GetRestaurantById(int id)
        {
            var restaurant = repo.GetRestaurantById(id);
            return mapper.Map<RestaurantModel>(restaurant);
        }

        public bool AddRestaurant(RestaurantModel restaurantModel)
        {
            var restaurant = mapper.Map<DAL.EF.Tables.Restaurant>(restaurantModel);
            return repo.AddRestaurant(restaurant);
        }

        public bool UpdateRestaurant(RestaurantModel restaurantModel)
        {
            var restaurant = mapper.Map<DAL.EF.Tables.Restaurant>(restaurantModel);
            return repo.UpdateRestaurant(restaurant);
        }

        public bool DeleteRestaurant(int id)
        {
            return repo.DeleteRestaurant(id);
        }
    }
}
