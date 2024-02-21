using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.GeneralFunctions
{
    public static class GeneralFunction
    {
        public static List<T> ConvertDataTableToList<T>(DataTable dataTable) where T : new()
        {
            try
            {
                List<T> dataList = new List<T>();
                foreach (DataRow row in dataTable.Rows)
                {
                    T item = new T();
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        if (row[column] != DBNull.Value)
                        {
                            typeof(T).GetProperty(column.ColumnName).SetValue(item, Convert.ChangeType(row[column], typeof(T).GetProperty(column.ColumnName).PropertyType), null);
                        }
                    }
                    dataList.Add(item);
                }
                return dataList;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
