using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            //Creating a new list if restaurants to get started
            restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "Pizannos Spot", Cuisine = CuisineType.Indian},
                new Restaurant {Id = 2, Name = "Fromage On The Lake", Cuisine = CuisineType.French},
                new Restaurant {Id = 3, Name = "Hem's Pizza", Cuisine = CuisineType.Italian},
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            //returns the list of the restaurant ordered
            return restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }
    }
}