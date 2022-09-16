using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace RestaurantsAPIS.Database
{
    public static class DBExtension
    {
        public static List<T> ConvertToList<T>(this DataTable dt) where T : new()
        {
            var temp = new List<T>();
            try
            {
                if (dt != null)
                {
                    var columnsNames = (from DataColumn dataColumn in dt.Columns select dataColumn.ColumnName).ToList();
                    temp = dt.AsEnumerable().ToList().ConvertAll(row => GetObject<T>(row, columnsNames));
                }
                return temp;
            }
            catch { return temp; }
        }

        private static List<T> ConvertTo<T>(IList<DataRow> rows)
        {
            List<T> list = null;
            if (rows != null)
            {
                list = Enumerable.ToList(rows.Select(CreateItem<T>));
            }
            return list;
        }

        /// <summary>
        /// Convert DataRow into T Object
        /// </summary>   
        private static T CreateItem<T>(DataRow row)
        {
            var obj = default(T);
            if (row == null) return obj;
            //Create the instance of type T
            obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in row.Table.Columns)
            {
                var columnName = column.ColumnName;
                //Get property with same columnName
                var prop = obj.GetType().GetProperty(columnName, (BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase));
                if (prop == null) continue;
                try
                {
                    //Get value for the column
                    object value = (row[columnName] is DBNull) ? null : row[columnName];
                    //Set property value
                    prop.SetValue(obj, value, null);
                }
                catch
                {
                    //throw;
                }
            }
            return obj;
        }
        public static List<T> ToList<T>(DataTable table)
        {
            if (table == null)
                return null;
            var rows = table.Rows.Cast<DataRow>().ToList();
            return ConvertTo<T>(rows);
        }
        public static T ToEntity<T>(this DataTable datatable) where T : new()
        {
            return ToList<T>(datatable).FirstOrDefault();
        }

        private static T GetObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            var obj = new T();
            try
            {
                var properties = typeof(T).GetProperties();
                foreach (var objProperty in properties)
                {
                    var columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (string.IsNullOrEmpty(columnname)) continue;
                    var value = row[columnname].ToString();
                    if (string.IsNullOrEmpty(value)) continue;
                    if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                    {
                        value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                        // ReSharper disable once AssignNullToNotNullAttribute
                        objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                    }
                    else
                    {
                        value = row[columnname].ToString().Replace("%", "");
                        // ReSharper disable once AssignNullToNotNullAttribute
                        objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                    }
                }
                return obj;
            }
            catch { return obj; }
        }
    }

}
