using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;


namespace RestaurantsAPIS.Database
{
    public class QueryBuilder
    {
        #region private members

        public enum QueryType
        {
            INSERT = 1,
            UPDATE = 2,
            DELETE = 3,
            SELECT = 4
        }

        public Enum SetQueryType;

        private string _tableName = string.Empty;
        private string _storedProcedureName = string.Empty;
        /*
                private string _selectStm = string.Empty;
        */
        private List<FieldValue> _fieldValueCollection = new List<FieldValue>();

        #endregion

        #region properties

        public List<FieldValue> FieldValueCollection
        {
            get { return _fieldValueCollection; }
            //set { _fieldValueCollection = value; }
        }

        public string TableName
        {
            private get { return _tableName; }
            set { _tableName = value; }
        }

        public string StoredProcedureName
        {
            get { return _storedProcedureName; }
            set { _storedProcedureName = value; }
        }

        /*
                private string SelectStm
                {
                    get { return _selectStm; }
                }
        */

        #endregion

        #region Methods

        /// <summary>
        ///     This function adds a new column in the FieldValueCollection
        /// </summary>
        /// <param name="columnName">Name of the column</param>
        /// <param name="columnValue">Value of that column</param>
        /// <param name="columnType">Data type of the column</param>
        /// <param name="isIdentity"></param>
        public void AddFieldValue(string columnName, object columnValue, DataTypes columnType, bool isIdentity)
        {
            var field = new FieldValue(columnName, columnValue, columnType, isIdentity);
            FieldValueCollection.Add(field);
        }

        public string InsertQuery()
        {
            var srInsert = new StringBuilder();
            var columns = " (";
            var values = " Values (";

            if (TableName == string.Empty)
            {
                throw new Exception("TableName does not specified.");
            }

            if (FieldValueCollection == null)
            {
                throw new Exception("No columns specified.");
            }

            srInsert.Append("Insert into ");
            srInsert.Append(TableName);

            foreach (var objField in FieldValueCollection)
            {
                if (objField.ColumnValue != null)
                {
                    columns += objField.ColumnName + ",";

                    switch (objField.ColumnType)
                    {
                        case DataTypes.Numeric:
                            values += objField.ColumnValue == DBNull.Value
                                ? "NULL"
                                : Convert.ToString(objField.ColumnValue);
                            values += ",";
                            break;
                        case DataTypes.Date:
                            values += " '" + Convert.ToString(objField.ColumnValue) + "',";
                            break;
                        case DataTypes.Text:
                            values += " N'" +
                                      Convert.ToString(Convert.ToString(objField.ColumnValue).Replace("'", "''")) +
                                      "',";
                            break;
                        case DataTypes.Boolean:
                            values += (objField.ColumnValue == DBNull.Value
                                ? "NULL"
                                : Convert.ToString(objField.ColumnValue) == "False" ? "0" : "1") + ",";
                            break;
                    }
                }
            }

            columns = columns.Remove(columns.Length - 1); // remove last comma
            columns += ")";

            values = values.Remove(values.Length - 1); // remove last comma
            values += ")";


            srInsert.Append(columns);
            srInsert.Append(values);
            return srInsert.ToString();
        }

        /*
                public string SelectQuery(List<FieldValue> whereClauseFieldValues)
                {
                    var srSelect = new StringBuilder();

                    srSelect.Append(SelectStm);
                    srSelect.Append(" where ");

                    var strValue = string.Empty;
                    foreach (var wherefield in whereClauseFieldValues)
                    {
                        //srUpdate.Append(wherefield.ColumnName + "=");
                        strValue += wherefield.ColumnName + "=";

                        switch (wherefield.ColumnType)
                        {
                            case DataTypes.Numeric:
                                strValue += Convert.ToString(wherefield.ColumnValue);
                                break;
                            case DataTypes.Date:
                                strValue += "'" + Convert.ToString(wherefield.ColumnValue) + "'";
                                break;
                            case DataTypes.Text:
                                strValue += "'" + Convert.ToString(wherefield.ColumnValue).Replace("'", "''") + "'";
                                break;
                        }
                        strValue += " and ";
                    }

                    strValue = strValue.Remove(strValue.Length - 5); // remove last " and "
                    srSelect.Append(strValue);
                    return srSelect.ToString();
                }
        */

        /*
                /// <summary>
                ///     This will escape the special character.
                /// </summary>
                /// <param name="strQuery"></param>
                /// <returns></returns>
                private string HandleSpecialCharacters(string strQuery)
                {
                    // Single quote.
                    strQuery = strQuery.Replace("'", "''");
                    return strQuery;
                }
        */


        public string UpdateRecord(FieldValue whereClauseFieldValue)
        {
            var srUpdate = new StringBuilder();
            var columns = " ";

            if (TableName == string.Empty)
            {
                throw new Exception("TableName does not specified.");
            }

            if (FieldValueCollection.Count <= 0)
            {
                throw new Exception("No columns specified.");
            }

            srUpdate.Append("Update ");
            srUpdate.Append(TableName);
            srUpdate.Append(" set ");

            foreach (var objField in FieldValueCollection)
            {
                columns += objField.ColumnName + "=";

                switch (objField.ColumnType)
                {
                    case DataTypes.Numeric:

                        columns += objField.ColumnValue == DBNull.Value
                            ? "NULL"
                            : Convert.ToString(objField.ColumnValue) == string.Empty
                                ? "0"
                                : Convert.ToString(objField.ColumnValue);
                        columns += ",";
                        break;
                    case DataTypes.Date:
                        columns += "'" + Convert.ToString(objField.ColumnValue) + "',";
                        break;
                    case DataTypes.Text:
                        columns += "N'" + Convert.ToString(objField.ColumnValue).Replace("'", "''") + "',";
                        break;
                    case DataTypes.Boolean:
                        columns += (objField.ColumnValue == DBNull.Value
                            ? "NULL"
                            : Convert.ToString(objField.ColumnValue) == "False" ? "0" : "1") + ",";
                        break;
                }
            }

            columns = columns.Remove(columns.Length - 1); // remove last comma
            srUpdate.Append(columns);
            srUpdate.Append(" where ");
            srUpdate.Append(whereClauseFieldValue.ColumnName + "=");

            var strValue = string.Empty;
            switch (whereClauseFieldValue.ColumnType)
            {
                case DataTypes.Numeric:
                    strValue = Convert.ToString(whereClauseFieldValue.ColumnValue);
                    break;
                case DataTypes.Date:
                    strValue = "'" + Convert.ToString(whereClauseFieldValue.ColumnValue) + "'";
                    break;
                case DataTypes.Text:
                    strValue = "'" + Convert.ToString(whereClauseFieldValue.ColumnValue).Replace("'", "''") + "'";
                    break;
            }
            srUpdate.Append(strValue);
            return Convert.ToString(srUpdate);
        }

        public string UpdateRecord(List<FieldValue> whereClauseFieldValues)
        {
            var srUpdate = new StringBuilder();
            var columns = " ";

            if (TableName == string.Empty)
            {
                throw new Exception("TableName does not specified.");
            }

            if (FieldValueCollection.Count <= 0)
            {
                throw new Exception("No columns specified.");
            }

            srUpdate.Append("Update ");
            srUpdate.Append(TableName);
            srUpdate.Append(" set ");

            foreach (var objField in FieldValueCollection)
            {
                if (objField.ColumnValue != null)
                {
                    columns += objField.ColumnName + "=";

                    switch (objField.ColumnType)
                    {
                        case DataTypes.Numeric:
                            columns += objField.ColumnValue == DBNull.Value
                                ? "NULL"
                                : Convert.ToString(objField.ColumnValue);
                            columns += ",";
                            break;
                        case DataTypes.Date:
                            columns += (Convert.ToDateTime(objField.ColumnValue).ToString("MM/dd/yyyy") ==
                                        "01/01/1753"
                                ? "NULL"
                                : " '" + Convert.ToString(objField.ColumnValue) + "' ") + ",";
                            break;
                        case DataTypes.Text:
                            columns += " N'" +
                                       Convert.ToString(Convert.ToString(objField.ColumnValue).Replace("'", "''")) +
                                       "',";
                            break;
                        case DataTypes.Boolean:
                            columns += (objField.ColumnValue == DBNull.Value
                                ? "NULL"
                                : Convert.ToString(objField.ColumnValue) == "False" ? "0" : "1") + ",";
                            break;
                    }
                }
            }

            columns = columns.Remove(columns.Length - 1); // remove last comma
            srUpdate.Append(columns);

            if (whereClauseFieldValues.Count > 0)
                srUpdate.Append(" where ");


            var strValue = string.Empty;
            foreach (var wherefield in whereClauseFieldValues)
            {
                //srUpdate.Append(wherefield.ColumnName + "=");
                strValue += wherefield.ColumnName + "=";

                switch (wherefield.ColumnType)
                {
                    case DataTypes.Numeric:
                        strValue += Convert.ToString(wherefield.ColumnValue);
                        break;
                    case DataTypes.Date:
                        strValue += "'" + Convert.ToString(wherefield.ColumnValue) + "'";
                        break;
                    case DataTypes.Text:
                        strValue += "N'" + Convert.ToString(wherefield.ColumnValue).Replace("'", "''") + "'";
                        break;
                }
                strValue += " and ";
            }
            strValue = strValue.Remove(strValue.Length - 5); // remove last " and "
            srUpdate.Append(strValue);
            return srUpdate.ToString();
        }

        public string DeleteRecord(List<FieldValue> whereClauseFieldValues)
        {
            var srDelete = new StringBuilder();

            if (TableName == string.Empty)
            {
                throw new Exception("TableName does not specified.");
            }

            srDelete.Append("Delete from ");
            srDelete.Append(_tableName);
            srDelete.Append(" where ");
            //srDelete.Append(whereClauseFieldValue.ColumnName + "=");

            var strValue = string.Empty;
            foreach (var wherefield in whereClauseFieldValues)
            {
                //srUpdate.Append(wherefield.ColumnName + "=");
                strValue += wherefield.ColumnName + "=";
                switch (wherefield.ColumnType)
                {
                    case DataTypes.Numeric:
                        strValue += Convert.ToString(wherefield.ColumnValue);
                        break;
                    case DataTypes.Date:
                        strValue += "'" + Convert.ToString(wherefield.ColumnValue) + "'";
                        break;
                    case DataTypes.Text:
                        strValue += "N'" + Convert.ToString(wherefield.ColumnValue).Replace("'", "''") + "'";
                        break;
                }
                strValue += " and ";
            }
            strValue = strValue.Remove(strValue.Length - 5); // remove last " and "
            srDelete.Append(strValue);
            return srDelete.ToString();
        }

        public string DeleteRecord(FieldValue whereClauseFieldValue)
        {
            var srDelete = new StringBuilder();

            if (TableName == string.Empty)
            {
                throw new Exception("TableName does not specified.");
            }

            srDelete.Append("Delete from ");
            srDelete.Append(_tableName);
            srDelete.Append(" where ");
            srDelete.Append(whereClauseFieldValue.ColumnName + "=");

            var strValue = string.Empty;
            switch (whereClauseFieldValue.ColumnType)
            {
                case DataTypes.Numeric:
                    strValue += Convert.ToString(whereClauseFieldValue.ColumnValue);
                    break;
                case DataTypes.Date:
                    strValue += "'" + Convert.ToString(whereClauseFieldValue.ColumnValue) + "'";
                    break;
                case DataTypes.Text:
                    strValue += "N'" + Convert.ToString(whereClauseFieldValue.ColumnValue).Replace("'", "''") + "'";
                    break;
            }
            srDelete.Append(strValue);
            return srDelete.ToString();
        }

        #endregion
    }
}
