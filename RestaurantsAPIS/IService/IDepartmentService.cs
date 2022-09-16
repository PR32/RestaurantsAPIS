using RestaurantsAPIS.Model;
using System.Collections.Generic;
using System.Data;

namespace RestaurantsAPIS.IService
{
    public interface IDepartmentService
    {
        public List<Department> GetDepartment();

        public DataTable GetDepartmentDT();

        public Department AddDepartment(Department productItem);

        public Department UpdateDepartment(Department productItem);

        public string DeleteDepartment(string id);
    }
}
