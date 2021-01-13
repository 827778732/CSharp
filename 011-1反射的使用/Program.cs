using System;
using System.Collections.Generic;
using System.Reflection;
using Test.DB.Interface;
using Test.DB.SqlServer;
/// <summary>
/// 1 dll-IL-matadata-反射
/// 2 反射加载dll，读取moule、类、方法、特性
/// 3 反射创建对象，反射+简单工厂+配置文件 选修：破坏单例 创建泛型
/// 4 反射调用实例方法、静态方法、重载方法 选修：调用私有方法 调用泛型方法
/// 5 反射字段和属性，分别获取值和设置值
/// 6 反射的好处和局限
/// 
/// 反射：.net提供Reflection
/// </summary>
/// 

namespace _011_1反射的使用
{
    class Program
    {
        static void Main(string[] args)
        {
            //一般使用外部的类应该先添加引用在using引用然后使用
            ICollection<int> irr = new List<int>();

            //1.加载dll
            {
                Assembly assembly = Assembly.Load("Test.DB.MySql");//当前目录加载
                                                                   //Assembly assembly1 = Assembly.LoadFile("Test.DB.MySql.dll");//完整路径加载
                                                                   //Assembly assembly2 = Assembly.LoadFrom("Test.DB.MySql.dll");

                //2.创建对象
                Type type = assembly.GetType("Test.DB.MySql.MySqlHelper");//2.获取类型信息
                object oHelp = Activator.CreateInstance(type);//3.调用无参构造函数 创建对象               
                                                              //oHelp.Query();对象有这个方法但是编译器不让用
                                                              //IDBHelper idBHelper = oHelp as IDBHelper;//转换类型
                                                              //idBHelper.Query();//使用方法
            }
            Console.WriteLine("****Reflection+Factory+Config*************通过配置加载的类库*****************");
            //通过工厂创建对象
            {
                //IOC
                IDBHelper dBHelper = Factory.CreateHelper();
                dBHelper.Query();//可配置可扩展 反射是动态的 依赖的是字符串
            }


            {
                Assembly assembly = Assembly.Load("Test.DB.SqlServer");
                Type type = assembly.GetType("Test.DB.SqlServer.Singleton");
                object o = Activator.CreateInstance(type, true);
                object o1 = Activator.CreateInstance(type, true);
                object o2 = Activator.CreateInstance(type, true);
                Console.WriteLine($"oHash={o.GetHashCode()} o1Hash={o1.GetHashCode()} o2Hash={o2.GetHashCode()}");
                Console.WriteLine("根据对对象求Hash发现创建了三个单例对象");
            }
            {

                Assembly assembly = Assembly.Load("Test.DB.SqlServer");
                Type type = assembly.GetType("Test.DB.SqlServer.ReflectionTest");
                object o = Activator.CreateInstance(type);//直接穿type就是调用无参构造函数
                object o1 = Activator.CreateInstance(type, new object[] { 123 });
                object o2 = Activator.CreateInstance(type, new object[] { "123" });
                
            }

            {
                Assembly assembly = Assembly.Load("Test.DB.SqlServer");
                Type type = assembly.GetType("Test.DB.SqlServer.GenericClass`3");
                //object o = Activator.CreateInstance(type);//直接穿type就是调用无参构造函数因为是泛型类得传递类型所以这块创建不了对象
                Type newType = type.MakeGenericType(new Type[] { typeof(int), typeof(string),typeof(DateTime) });
                object o = Activator.CreateInstance(newType);
                GenericClass<int,string,DateTime> g =  o as GenericClass<int, string, DateTime>;



               
            }




            Console.ReadKey();
        }






    }

















}
