using System;
using System.Reflection;
using Test.DB.Interface;
using System.Configuration;
namespace _011_1反射的使用
{
    //工厂用于创建对象
    //工厂有创建dll中类对象的方法




    /// <summary>
    /// 创建对象的工厂
    /// </summary>
    public class Factory
    {
        //通过配置文件获取要加载的类库和类库中具体的类  --之后可以改配置就可以加载不同dll
        private static string IDBHelperConfig = ConfigurationManager.AppSettings["IDBHelper"];//根据AppSettings的key找value
        private static string DllName = IDBHelperConfig.Split(',')[0];//将value分割找到dll名和要创建对象的类
        private static string TypeName= IDBHelperConfig.Split(',')[1];


        //由于使用的就是Load的方法只能加载和程序在同一目录的dll
        public static IDBHelper CreateHelper()
        {
            Assembly assembly = Assembly.Load(DllName);//加载dll
            Type type = assembly.GetType(TypeName);//获取类型信息
            object oHelp = Activator.CreateInstance(type);//创建对象
            IDBHelper idBHelper = oHelp as IDBHelper;//类型转换
            return idBHelper;
        }


        //不可扩展的加载dll
        //public static IDBHelper CreateHelper()
        //{
        //    Assembly assembly = Assembly.Load("Test.DB.MySql");                                                 
        //    Type type = assembly.GetType("Test.DB.MySql.MySqlHelper");
        //    object oHelp = Activator.CreateInstance(type);          
        //    IDBHelper idBHelper = oHelp as IDBHelper;
        //    return idBHelper;
        //}








    }
}
