using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantsAPIS.IService;
using RestaurantsAPIS.Model;
using System.Collections.Generic;
using System.Data;

namespace RestaurantsAPIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private ILogger _logger;
        private IRestaurantService _service;

        public RestaurantController(ILogger<RestaurantController> logger, IRestaurantService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("/api/Restaurant")]
        public ActionResult<List<Restaurant>> GetRestaurant()
        {
            return Ok(_service.GetRestaurants());
        }

        [HttpPost("/api/Restaurant")]
        public ActionResult<List<Restaurant>> GetRestaurant(Restaurant restaurant)
        {

            return Ok(_service.GetRestaurants());
        }
    }
}
