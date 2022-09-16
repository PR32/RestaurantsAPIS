using RestaurantsAPIS.Database;
using RestaurantsAPIS.IService;
using RestaurantsAPIS.Model;
using System.Collections.Generic;
using System.Data;

namespace RestaurantsAPIS.Service
{
    public class EmployeeService : IEmployeeService
    {
        private List<Employee> _employeelist;
        private GeneralMethods _generalMethod = new GeneralMethods();
        public EmployeeService()
        {
            _employeelist = new List<Employee>();
        }
        public DataTable GetEmployee()
        {
            QueryBuilder objQueryBuilder = new QueryBuilder
            {
                TableName = "Employee",
                StoredProcedureName = @"GetEmployee",
                SetQueryType = QueryBuilder.QueryType.SELECT,
            };
            return _generalMethod.ExecuteDataTableUsingSp(objQueryBuilder);
        }

        public List<Employee> getemployeelist()
        {
            QueryBuilder objQueryBuilder = new QueryBuilder
            {
                TableName = "Employee",
                StoredProcedureName = @"GetEmployee",
                SetQueryType = QueryBuilder.QueryType.SELECT,
            };
            return _generalMethod.GetListUsingSp<Employee>(objQueryBuilder);
        }
        public Employee AddEmployee(Employee productItem)
        {
            QueryBuilder objQueryBuilder = new QueryBuilder
            {
                TableName = "Employee",
                StoredProcedureName = @"AddEmployee",
                SetQueryType = QueryBuilder.QueryType.INSERT,
            };
            objQueryBuilder.AddFieldValue("@Name", productItem.EmployeeName , DataTypes.Text, false);
            objQueryBuilder.AddFieldValue("@DateOfJoining", productItem.DateOfJoining, DataTypes.Text, false);
            objQueryBuilder.AddFieldValue("@PhotoFileName", productItem.PhotoFileName, DataTypes.Text, false);
            objQueryBuilder.AddFieldValue("@Department", productItem.Department, DataTypes.Text, false);
            _generalMethod.ExcecuteScalarUsingSp(objQueryBuilder);
            _employeelist.Add(productItem);
            return productItem;
        }

        public Employee UpdateEmployee(Employee productItem)
        {
            QueryBuilder objQueryBuilder = new QueryBuilder
            {
                TableName = "Employee",
                StoredProcedureName = @"UpdateEmployee",
                SetQueryType = QueryBuilder.QueryType.UPDATE,
            };
            objQueryBuilder.AddFieldValue("@EmployeeId", productItem.EmployeeId, DataTypes.Text, false);
            objQueryBuilder.AddFieldValue("@Name", productItem.EmployeeName, DataTypes.Text, false);
            objQueryBuilder.AddFieldValue("@DateOfJoining", productItem.DateOfJoining, DataTypes.Text, false);
            objQueryBuilder.AddFieldValue("@PhotoFileName", productItem.PhotoFileName, DataTypes.Text, false);
            objQueryBuilder.AddFieldValue("@Department", productItem.Department, DataTypes.Text, false);
            string str = _generalMethod.ExcecuteScalarUsingSp(objQueryBuilder);
            return productItem;
        }

        public string DeleteEmployee(string id)
        {
            QueryBuilder objQueryBuilder = new QueryBuilder
            {
                TableName = "Employee",
                StoredProcedureName = @"DeleteEmployee",
                SetQueryType = QueryBuilder.QueryType.DELETE,
            };
            objQueryBuilder.AddFieldValue("@id", id, DataTypes.Text, false);
            _generalMethod.ExcecuteScalarUsingSp(objQueryBuilder);
            return id;
        }
    }
}
