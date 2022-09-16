using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantsAPIS.IService;
using RestaurantsAPIS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace RestaurantsAPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private ILogger _logger;
        private IEmployeeService _service;
        private readonly IWebHostEnvironment _env;
        public EmployeeController(ILogger<DepartmentController> logger, IEmployeeService service, IWebHostEnvironment env)
        {
            _logger = logger;
            _service = service;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_service.GetEmployee());
        }


        [HttpPost]
        public JsonResult Post(Employee emp)
        {
            _service.AddEmployee(emp);
            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Employee emp)
        {
            _service.UpdateEmployee(emp);
            return new JsonResult("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _service.DeleteEmployee(id.ToString());
            return new JsonResult("Deleted Successfully");
        }


        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }


        [Route("GetAllDepartmentNames")]
        public JsonResult GetAllDepartmentNames()
        {
            DataTable table = new DataTable();
            return new JsonResult(table);
        }

        [HttpGet]
        [Route("Getemployee")]
        public List<Employee> Getemployee()
        {
            return _service.getemployeelist();
        }
    }
}
