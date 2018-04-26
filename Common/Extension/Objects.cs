using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;


public static class Objects
{
    /// <summary>
    /// 判断序列是否为空
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enums"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> enums)
    {
        return enums == null && !enums.Any(u => true);
    }
    /// <summary>
    /// 把序列转换为DataTable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static DataTable ListToDataTable<T>(this IEnumerable<T> list)
    {
        //创建属性的集合
        List<PropertyInfo> pList = new List<PropertyInfo>();
        //获得反射的入口
        Type type = typeof(T);
        DataTable dt = new DataTable();
        //把所有的public属性加入到集合 并添加DataTable的列
        Array.ForEach<PropertyInfo>(type.GetProperties(), p =>
        {
            pList.Add(p);
            if (p.PropertyType == typeof(Nullable<int>))
            {
                dt.Columns.Add(p.Name, typeof(int));
            }
            else
            {
                dt.Columns.Add(p.Name, p.PropertyType);
            }
        });
        foreach (var item in list)
        {
            //创建一个DataRow实例
            DataRow row = dt.NewRow();
            //给row 赋值
            pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
            //加入到DataTable
            dt.Rows.Add(row);
        }
        return dt;
    }
    /// <summary>
    /// 获取汉字拼音
    /// </summary>
    /// <param name="cnChar"></param>
    /// <returns></returns>
    public static string getSpell(this string cnChar)
    {
        byte[] arrCN = Encoding.Default.GetBytes(cnChar);
        if (arrCN.Length > 1)
        {
            int area = (short)arrCN[0];
            int pos = (short)arrCN[1];
            int code = (area << 8) + pos;
            int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
            for (int i = 0; i < 26; i++)
            {
                int max = 55290;
                if (i != 25) max = areacode[i + 1];
                if (areacode[i] <= code && code < max)
                {
                    return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                }
            }
            return "x";
        }
        else return cnChar;
    }
}

