using RestaurantsAPIS.Model;
using System.Collections.Generic;
using System.Data;

namespace RestaurantsAPIS.IService
{
    public interface IRestaurantService
    {
            public List<Restaurant> GetRestaurants();

            public Restaurant AddRestaurant(Restaurant productItem);

            public Restaurant UpdateRestaurant(string id, Restaurant productItem);

            public string DeleteRestaurant(string id);
       
    }
}
