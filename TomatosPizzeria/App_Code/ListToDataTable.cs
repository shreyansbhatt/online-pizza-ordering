using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



public static class ListToDatatable
{

    //public static DataTable ToDataTable<T>(this IEnumerable<T> collection, string tableName)
    //{

    //    DataTable tbl = ToDataTable(collection);

    //    tbl.TableName = tableName;

    //    return tbl;

    //}



    public static DataTable ToDataTable<T>(this IEnumerable<T> collection)
    {

        DataTable dt = new DataTable();

        Type t = typeof(T);

        PropertyInfo[] pia = t.GetProperties();

        //Create the columns in the DataTable

        foreach (PropertyInfo pi in pia)
        {

            dt.Columns.Add(pi.Name, pi.PropertyType);

        }

        //Populate the table

        foreach (T item in collection)
        {

            DataRow dr = dt.NewRow();

            dr.BeginEdit();

            foreach (PropertyInfo pi in pia)
            {

                dr[pi.Name] = pi.GetValue(item, null);

            }

            dr.EndEdit();

            dt.Rows.Add(dr);

        }

        return dt;

    }

    public static DataTable ListToDataTable<T>(this IEnumerable<T> list)
    {
        DataTable table = new DataTable();

        if (list != null)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(
                    prop.Name,
                    (prop.PropertyType.IsGenericType &&
                     prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        ? Nullable.GetUnderlyingType(prop.PropertyType)
                        : prop.PropertyType
                    );
            foreach (T item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
        }
        return table;
    }

    public static List<T> ToCollection<T>(this DataTable dt)
    {
        List<T> lst = new System.Collections.Generic.List<T>();
        Type tClass = typeof(T);
        PropertyInfo[] pClass = tClass.GetProperties();
        List<DataColumn> dc = dt.Columns.Cast<DataColumn>().ToList();
        T cn;
        foreach (DataRow item in dt.Rows)
        {
            cn = (T)Activator.CreateInstance(tClass);
            foreach (PropertyInfo pc in pClass)
            {
                // Can comment try catch block. 
                try
                {
                    DataColumn d = dc.Find(c => c.ColumnName == pc.Name);
                    if (d != null)
                        pc.SetValue(cn, item[pc.Name], null);
                }
                catch
                {
                }
            }
            lst.Add(cn);
        }
        return lst;
    }

}

