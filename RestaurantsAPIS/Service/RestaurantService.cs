using RestaurantsAPIS.Database;
using RestaurantsAPIS.IService;
using RestaurantsAPIS.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantsAPIS.Service
{
    public class RestaurantService : IRestaurantService
    {
        private List<Restaurant> _RestaurantItems;
        private GeneralMethods _generalMethod = new GeneralMethods();
        public RestaurantService()
        {
            _RestaurantItems = new List<Restaurant>();
        }
        
        public List<Restaurant> GetRestaurants()
        {
            QueryBuilder objQueryBuilder = new QueryBuilder
            {
                TableName = "Restaurant",
                StoredProcedureName = @"GetRestaurants",
                SetQueryType = QueryBuilder.QueryType.SELECT,
            };
            //objQueryBuilder.AddFieldValue("@FromDate", FromDate, DataTypes.Date, false);
            //objQueryBuilder.AddFieldValue("@ToDate", ToDate, DataTypes.Date, false);
            return _generalMethod.GetListUsingSp<Restaurant>(objQueryBuilder);
        }
        public Restaurant AddRestaurant(Restaurant RestaurantItem)
        {

            _RestaurantItems.Add(RestaurantItem);
            return RestaurantItem;
        }

        public Restaurant UpdateRestaurant(string id, Restaurant RestaurantItem)
        {
            return RestaurantItem;
        }

        public string DeleteRestaurant(string id)
        {
            return id;
        }

        //public DataTable SalesByTenderTypeTranCount(DateTime FromDate, DateTime ToDate, string Stations)
        //{

        //        QueryBuilder objQueryBuilder = new QueryBuilder
        //        {
        //            TableName = "Cloud_Invoice_Totals",
        //            StoredProcedureName = @"Reports_Payment_SalesByTenderTypeTranCount",
        //            SetQueryType = QueryBuilder.QueryType.SELECT,
        //        };
        //        objQueryBuilder.AddFieldValue("FromDate", FromDate, DataTypes.Date, false);
        //        objQueryBuilder.AddFieldValue("ToDate", ToDate, DataTypes.Date, false);
        //        objQueryBuilder.AddFieldValue("Stations", Stations, DataTypes.Text, false);
        //        return _generalMethod.ExecuteDataTableUsingSp(objQueryBuilder);


        //}


        //public List<Cloud_Reports> GetTopSellingDepartment(DateTime FromDate, DateTime ToDate)
        //{

        //        QueryBuilder objQueryBuilder = new QueryBuilder
        //        {
        //            TableName = "Cloud_Invoice_Totals",
        //            StoredProcedureName = @"crud_Reports_GetTopSellingDepartments",
        //            SetQueryType = QueryBuilder.QueryType.SELECT,
        //        };
        //        objQueryBuilder.AddFieldValue("@FromDate", FromDate, DataTypes.Date, false);
        //        objQueryBuilder.AddFieldValue("@ToDate", ToDate, DataTypes.Date, false);
        //        return _generalMethod.GetListUsingSp<Cloud_Reports>(objQueryBuilder);

        //}


        //public string GetHourlyTopSellerCount(DateTime FromDate, DateTime ToDate, string searchtxt)
        //{
        //        QueryBuilder objQueryBuilder = new QueryBuilder
        //        {
        //            StoredProcedureName = @"Reports_GetHourlyTopSellerCount",
        //            SetQueryType = QueryBuilder.QueryType.SELECT,
        //        };
        //        objQueryBuilder.AddFieldValue("@FromDate", FromDate, DataTypes.Date, false);
        //        objQueryBuilder.AddFieldValue("@ToDate", ToDate, DataTypes.Date, false);
        //        objQueryBuilder.AddFieldValue("@searchText", searchtxt, DataTypes.Text, false);
        //        return _generalMethod.ExcecuteScalarUsingSp(objQueryBuilder);

        //}

        //public Cloud_Customer GetCustomerByID(string id) 
        //{
        //        QueryBuilder objQueryBuilder = new QueryBuilder
        //        {
        //            TableName = "Cloud_Customer",
        //            StoredProcedureName = @"crud_Cloud_Customer_GetByCustomerNo",
        //            SetQueryType = QueryBuilder.QueryType.SELECT,
        //        };
        //        objQueryBuilder.AddFieldValue("@nvarCustNum", id, DataTypes.Text, false);
        //        return _generalMethod.ExecuteObjectUsingSp<Cloud_Customer>(objQueryBuilder);
        //}

    }
}
