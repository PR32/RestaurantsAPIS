using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static RestaurantsAPIS.Database.QueryBuilder;

namespace RestaurantsAPIS.Database
{
    public partial class GeneralMethods
    {

        string connectionstring = Startup.ConnectionString;
        #region SQL Operation using SP

        public List<T> GetListUsingSp<T>(QueryBuilder objQueryBuilder, bool IsCloudConnection = false) where T : new()
        {
            try
            {
                using (var conn = new SqlConnection(connectionstring))
                {
                    using (var cmd = new SqlCommand(objQueryBuilder.StoredProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 300;
                        foreach (var item in objQueryBuilder.FieldValueCollection)
                        {
                            cmd.Parameters.AddWithValue(item.ColumnName, item.ColumnValue);
                        }
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            using (var dt = new DataTable())
                            {
                                OpenConnection(conn);
                                da.Fill(dt);
                                return DBExtension.ToList<T>(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception oException)
            {
                throw;
            }
            finally
            {
            }

        }

        public List<T> GetListUsingSp<T>(QueryBuilder objQueryBuilder, string sqlConnection) where T : new()
        {
            try
            {
                using (var conn = new SqlConnection(sqlConnection))
                {
                    using (var cmd = new SqlCommand(objQueryBuilder.StoredProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 300;
                        foreach (var item in objQueryBuilder.FieldValueCollection)
                        {
                            cmd.Parameters.AddWithValue(item.ColumnName, item.ColumnValue);
                        }
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            using (var dt = new DataTable())
                            {
                                OpenConnection(conn);
                                da.Fill(dt);
                                return DBExtension.ToList<T>(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception oException)
            {
                throw;
            }
            finally
            {
            }

        }

        public string ExcecuteScalarUsingSp(QueryBuilder objQueryBuilder)
        {
            try
            {
                using (var conn = new SqlConnection(connectionstring))
                {
                    using (var cmd = new SqlCommand(objQueryBuilder.StoredProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 300;
                        foreach (var item in objQueryBuilder.FieldValueCollection)
                        {
                            cmd.Parameters.AddWithValue(item.ColumnName, item.ColumnValue);
                        }
                        OpenConnection(conn);
                        return Convert.ToString(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception oException)
            {
                throw;
            }
            finally
            {
            }

        }

        public string ExcecuteScalarUsingSp(QueryBuilder objQueryBuilder, string sqlConnection)
        {
            try
            {
                using (var conn = new SqlConnection(sqlConnection))
                {
                    using (var cmd = new SqlCommand(objQueryBuilder.StoredProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var item in objQueryBuilder.FieldValueCollection)
                        {
                            cmd.Parameters.AddWithValue(item.ColumnName, item.ColumnValue);
                        }
                        OpenConnection(conn);
                        return Convert.ToString(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception oException)
            {
                throw;
            }
            finally
            {
            }

        }

        public bool ExcecuteBoolUsingSp(QueryBuilder objQueryBuilder)
        {
            try
            {

                using (var conn = new SqlConnection(connectionstring))
                {
                    using (var cmd = new SqlCommand(objQueryBuilder.StoredProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var item in objQueryBuilder.FieldValueCollection)
                        {
                            cmd.Parameters.AddWithValue(item.ColumnName, item.ColumnValue);
                        }
                        OpenConnection(conn);
                        string strVal = Convert.ToString(cmd.ExecuteScalar());
                        if (strVal == string.Empty)
                            return false;
                        else
                        {
                            int intCnt = Convert.ToInt32(strVal);
                            return intCnt != 0;
                        }
                    }
                }
            }
            catch (Exception oException)
            {
                throw;
            }
            finally
            {
            }

        }

        public T ExecuteObjectUsingSp<T>(QueryBuilder objQueryBuilder) where T : new()
        {
            try
            {
                using (var conn = new SqlConnection(connectionstring))
                {
                    using (var cmd = new SqlCommand(objQueryBuilder.StoredProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var item in objQueryBuilder.FieldValueCollection)
                        {
                            cmd.Parameters.AddWithValue(item.ColumnName, item.ColumnValue);
                        }
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            using (var dt = new DataTable())
                            {
                                OpenConnection(conn);
                                da.Fill(dt);
                                var result = dt.ToEntity<T>();
                                if (result == null)
                                {
                                }
                                return result;
                            }
                        }
                    }
                }
            }
            catch (Exception oException)
            {
                throw;
            }
            finally
            {
            }
        }

        public DataTable ExecuteDataTableUsingSp(QueryBuilder objQueryBuilder)
        {
            try
            {
                using (var conn = new SqlConnection(connectionstring))
                {
                    using (var cmd = new SqlCommand(objQueryBuilder.StoredProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var item in objQueryBuilder.FieldValueCollection)
                        {
                            cmd.Parameters.AddWithValue(item.ColumnName, item.ColumnValue);
                        }
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            using (var dt = new DataTable())
                            {
                                OpenConnection(conn);
                                da.Fill(dt);
                                return dt;
                            }
                        }
                    }
                }
            }
            catch (Exception oException)
            {
                throw;
            }
            finally
            {
            }
        }

        public DataSet ExecuteDataSetUsingSp(QueryBuilder objQueryBuilder)
        {
            try
            {
                DataSet ds = new DataSet();
                using (var conn = new SqlConnection(connectionstring))
                {
                    using (var cmd = new SqlCommand(objQueryBuilder.StoredProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 300;
                        foreach (var item in objQueryBuilder.FieldValueCollection)
                        {
                            cmd.Parameters.AddWithValue(item.ColumnName, item.ColumnValue);
                        }
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            OpenConnection(conn);
                            da.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
            catch (Exception oException)
            {
                throw;
            }
            finally
            {

            }
        }

        public int ExecuteNonQueryUsingSp(QueryBuilder objQueryBuilder, List<FieldValue> lstWhereClause = null)
        {
            try
            {
                using (var conn = new SqlConnection(connectionstring))
                {
                    using (var cmd = new SqlCommand(objQueryBuilder.StoredProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var item in objQueryBuilder.FieldValueCollection)
                        {
                            cmd.Parameters.AddWithValue(item.ColumnName, item.ColumnValue);
                        }
                        if (lstWhereClause != null)
                        {
                            foreach (var item in lstWhereClause)
                            {
                                cmd.Parameters.AddWithValue(item.ColumnName, item.ColumnValue);
                            }
                        }
                        OpenConnection(conn);
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception oException)
            {
                return 0;
            }
            finally
            {
            }
        }

        public object ExecuteQurSpReturnObject(QueryBuilder objQueryBuilder, List<FieldValue> lstWhereClause)
        {
            try
            {
                object objValue = null;
                using (var conn = new SqlConnection(connectionstring))
                {
                    using (var cmd = new SqlCommand(objQueryBuilder.StoredProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var item in objQueryBuilder.FieldValueCollection)
                        {
                            cmd.Parameters.AddWithValue(item.ColumnName, item.ColumnValue);
                        }
                        if (lstWhereClause != null)
                        {
                            foreach (var item in lstWhereClause)
                            {
                                cmd.Parameters.AddWithValue(item.ColumnName, item.ColumnValue);
                            }
                        }
                        OpenConnection(conn);
                        objValue = cmd.ExecuteScalar();
                    }
                }

                return objValue;
            }
            catch (Exception oException)
            {
                throw;
            }
            finally
            {

            }
        }

        public void ExecuteQurSpByConnection(QueryBuilder objQueryBuilder, List<FieldValue> lstWhereClause, SqlConnection Connenction)
        {
            try
            {
                using (var conn = Connenction)
                {
                    using (var cmd = new SqlCommand(objQueryBuilder.StoredProcedureName, Connenction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (var item in objQueryBuilder.FieldValueCollection)
                        {
                            cmd.Parameters.AddWithValue(item.ColumnName, item.ColumnValue);
                        }
                        if (lstWhereClause != null)
                        {
                            foreach (var item in lstWhereClause)
                            {
                                cmd.Parameters.AddWithValue(item.ColumnName, item.ColumnValue);
                            }
                        }
                        OpenConnection(Connenction);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception oException)
            {
                throw;
            }
            finally
            {
            }
        }

        private void OpenConnection(SqlConnection cn)
        {
            try
            {
                cn.Open();
            }
            catch (Exception ex)
            {
                string strInnerEx = string.Empty;
                string method = MethodBase.GetCurrentMethod().Name;
                if (ex.InnerException != null)
                {
                    strInnerEx = ex.InnerException.ToString();
                }

            }
        }
        #endregion

      


    }
}
