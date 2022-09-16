using RestaurantsAPIS.Database;
using RestaurantsAPIS.IService;
using RestaurantsAPIS.Model;
using System.Collections.Generic;
using System.Data;

namespace RestaurantsAPIS.Service
{
    public class DepartmentService : IDepartmentService
    {
        private List<Department> _departmnetlist;
        private GeneralMethods _generalMethod = new GeneralMethods();
        public DepartmentService()
        {
            _departmnetlist = new List<Department>();
        }

        public List<Department> GetDepartment()
        {
            QueryBuilder objQueryBuilder = new QueryBuilder
            {
                TableName = "Department",
                StoredProcedureName = @"GetDepartment",
                SetQueryType = QueryBuilder.QueryType.SELECT,
            };
            return _generalMethod.GetListUsingSp<Department>(objQueryBuilder);
        }
        public DataTable GetDepartmentDT()
        {
            QueryBuilder objQueryBuilder = new QueryBuilder
            {
                TableName = "Department",
                StoredProcedureName = @"GetDepartment",
                SetQueryType = QueryBuilder.QueryType.SELECT,
            };
            
            return _generalMethod.ExecuteDataTableUsingSp(objQueryBuilder);
        }
        public Department AddDepartment(Department departments)
        {
            QueryBuilder objQueryBuilder = new QueryBuilder
            {
                TableName = "Department",
                StoredProcedureName = @"AddDepartment",
                SetQueryType = QueryBuilder.QueryType.INSERT,
            };
            objQueryBuilder.AddFieldValue("@Name", departments.DepartmentName, DataTypes.Text, false);
            _generalMethod.ExcecuteScalarUsingSp(objQueryBuilder);
            _departmnetlist.Add(departments);
            return departments;
        }

        public Department UpdateDepartment(Department departments)
        {
            QueryBuilder objQueryBuilder = new QueryBuilder
            {
                TableName = "Department",
                StoredProcedureName = @"UpdateDepartment",
                SetQueryType = QueryBuilder.QueryType.UPDATE,
            };
            objQueryBuilder.AddFieldValue("@Id", departments.DepartmentId, DataTypes.Numeric, false);
            objQueryBuilder.AddFieldValue("@Name", departments.DepartmentName, DataTypes.Text, false);
            string str=_generalMethod.ExcecuteScalarUsingSp(objQueryBuilder);
            return departments;
        }   

        public string DeleteDepartment(string id)
        {

            QueryBuilder objQueryBuilder = new QueryBuilder
            {
                TableName = "Department",
                StoredProcedureName = @"DeleteDepartment",
                SetQueryType = QueryBuilder.QueryType.DELETE,
            };
            objQueryBuilder.AddFieldValue("@id", id, DataTypes.Text, false);
            _generalMethod.ExcecuteScalarUsingSp(objQueryBuilder);
            return id;
        }

    }
}
