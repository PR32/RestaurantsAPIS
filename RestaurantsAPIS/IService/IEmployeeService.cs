using RestaurantsAPIS.Model;
using System.Collections.Generic;
using System.Data;

namespace RestaurantsAPIS.IService
{
    public interface IEmployeeService
    {
        public DataTable GetEmployee();

        public List<Employee> getemployeelist();

        public Employee AddEmployee(Employee productItem);

        public Employee UpdateEmployee(Employee productItem);

        public string DeleteEmployee(string id);
    }
}
