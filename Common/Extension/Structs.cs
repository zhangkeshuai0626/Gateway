using System;
using System.Web.Security;

/// <summary>
/// 常用的扩展方法
/// </summary>
public static class Structs
{
    /// <summary>
    /// 是否为空的Guid
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    public static bool IsEmpty(this Guid guid)
    {
        return guid == Guid.Empty;
    }
    public static bool IsNullOrEmpty(this Guid? stu)
    {
        return stu == null || stu == Guid.Empty;
    }
    /// <summary>
    /// 判断字符串是不是Int32
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsInt(this string str)
    {
        int test;
        return int.TryParse(str, out test);
    }
    /// <summary>
    /// 判断字符串是不是Guid
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsGuid(this string str)
    {
        Guid test;
        return Guid.TryParse(str, out test);
    }
    /// <summary>
    /// 将int类型转为GUID格式
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static Guid ToGuid(this int n)
    {
        return n.ToString("00000000-0000-0000-0000-000000000000").ToGuid();
    }
    /// <summary>
    /// 判断是否为空
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }
    /// <summary>
    /// 转换为Guid
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static Guid ToGuid(this string str)
    {
        Guid test;
        if (Guid.TryParse(str, out test))
        {
            return test;
        }
        else
        {
            return Guid.Empty;
        }
    }
    /// <summary>
    /// 获取md5值
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string MD5Code(this string str)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
    }

}

