using System;
using System.Reflection;
using Test.DB.Interface;
using System.Configuration;
namespace _011_1反射的使用
{
    //工厂用于创建对象
    //封装创建对象的方法

    /// <summary>
    /// 创建对象的工厂
    /// </summary>
    public class Factory
    {
        //通过配置文件拿数据   --之后可以改配置就可以加载不同dll
        private static string IDBHelperConfig = ConfigurationManager.AppSettings["IDBHelper"];
        private static string DllName = IDBHelperConfig.Split(',')[1];
        private static string TypeName= IDBHelperConfig.Split(',')[0];

        //public static IDBHelper CreateHelper()
        //{
        //    Assembly assembly = Assembly.Load("Test.DB.MySql");                                                 
        //    Type type = assembly.GetType("Test.DB.MySql.MySqlHelper");
        //    object oHelp = Activator.CreateInstance(type);          
        //    IDBHelper idBHelper = oHelp as IDBHelper;
        //    return idBHelper;
        //}



        //上指定目录加载并使用dll
        //由于使用的就是Load的方法只能加载和程序在同一目录的dll
        public static IDBHelper CreateHelper()
        {
            Assembly assembly = Assembly.Load(DllName);//加载dll
            Type type = assembly.GetType(TypeName);//获取类型信息
            object oHelp = Activator.CreateInstance(type);//创建对象
            IDBHelper idBHelper = oHelp as IDBHelper;//类型转换
            return idBHelper;
        }




    }
}
