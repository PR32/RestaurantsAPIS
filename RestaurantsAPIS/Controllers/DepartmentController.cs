using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestaurantsAPIS.IService;
using RestaurantsAPIS.Model;
using System.Data;

namespace RestaurantsAPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private ILogger _logger;
        private IDepartmentService _service;


        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService service)
        {
            _logger = logger;
            _service = service;

        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_service.GetDepartmentDT());
        }


        [HttpPost]
        public JsonResult Post(Department dep)
        {
            _service.AddDepartment(dep);
            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Department dep)
        {
            _service.UpdateDepartment(dep);
            return new JsonResult("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _service.DeleteDepartment(id.ToString());
            return new JsonResult("Deleted Successfully");
        }
    }
}
