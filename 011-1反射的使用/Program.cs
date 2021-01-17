using System;
using System.Collections.Generic;
using System.Reflection;
using Test.DB.Interface;
using Test.DB.SqlServer;
using Test.Model;
//优点：反射使程序 可以配置 可以扩展   反射是动态的  依赖的字符串 
//缺点：
//1.复杂、
//2.避开编译器检查(如查方法名不存在但是不报错，运行后报错)
//3.性能不好 100w次性能相当于500倍的直接 100次也就0.73ms 优化基本不能在这优化
//性能优化,(加载类库和类型在外部建立好形成存缓)空间换时间,差别7倍 10000次才0.87
//MVC第一次访问很慢 后面很快 由于先存缓
//EF第一次访问很慢 后面很快 由于先存缓




//反射可以避开所以访问修饰符
/// <summary>
/// 1 dll-IL-matadata-反射
/// 2 反射加载dll，读取moule、类、方法、特性
/// 3 反射创建对象，反射+简单工厂+配置文件 选修：破坏单例 创建泛型
/// 4 反射调用实例方法、静态方法、重载方法 选修：调用私有方法 调用泛型方法
/// 5 反射字段和属性，分别获取值和设置值
/// 反射：.net提供Reflection
/// </summary>
/// 

namespace _011_1反射的使用
{
    class Program
    {
        static void Main(string[] args)
        {
            //一般使用外部的类应该先添加引用(依赖)在using引用然后使用
            ICollection<int> irr = new List<int>();

            //IOC反射使用
            {

                //1.加载dll   ---当前目录加载
                Assembly assembly = Assembly.Load("Test.DB.MySql");
                //1.2其他方式加载dll
                //Assembly assembly1 = Assembly.LoadFile("Test.DB.MySql.dll");
                //Assembly assembly2 = Assembly.LoadFrom("Test.DB.MySql.dll");


                //2.获取类型信息
                Type type = assembly.GetType("Test.DB.MySql.MySqlHelper");


                //3.调用无参构造函数 创建对象  
                object oHelp = Activator.CreateInstance(type);


                //4.转换类型
                IDBHelper idBHelper = oHelp as IDBHelper;


                //5.使用方法
                idBHelper.Query();
            }
            Console.WriteLine("\n");
            Console.WriteLine("****Reflection+Factory+Config*************通过配置加载的类库*****************");
            //通过工厂创建对象
            {
                //IOC模式
                IDBHelper dBHelper = Factory.CreateHelper();
                dBHelper.Query();//可配置可扩展 反射是动态的 依赖的是字符串
            }
            Console.WriteLine("\n");
            //破坏单例 
            {
                //一般创建单例对象
                Console.WriteLine("\n************************一般的单例************************");
                {
                    Singleton singleton = Singleton.GetInstance();
                    Singleton singleton2 = Singleton.GetInstance();
                    Singleton singleton3 = Singleton.GetInstance();
                    Console.WriteLine($"singletonHash={singleton.GetHashCode()} singleton2Hash={singleton2.GetHashCode()} singleton3Hash={singleton3.GetHashCode()}");
                    Console.WriteLine("发现一般单例都是同一个对象");
                }
                Console.WriteLine("***********************通过反射创建的单例*****************");
                //使用反射创建单例对象
                {
                    Assembly assembly = Assembly.Load("Test.DB.SqlServer");
                    Type type = assembly.GetType("Test.DB.SqlServer.Singleton");
                    object o = Activator.CreateInstance(type, true);//使用默认构造函数创建对象    这里调用私有构造函数以实现创建多个单例对象
                    object o2 = Activator.CreateInstance(type, true);
                    object o3 = Activator.CreateInstance(type, true);
                    Console.WriteLine($"oHash={o.GetHashCode()} o2Hash={o2.GetHashCode()} o3Hash={o3.GetHashCode()}");
                    Console.WriteLine("根据对对象求Hash发现创建了三个单例对象");
                }

            }
            Console.WriteLine("\n");
            //对有参数的构造方法构造对象
            {

                Assembly assembly = Assembly.Load("Test.DB.SqlServer");
                Type type = assembly.GetType("Test.DB.SqlServer.ReflectionTest");
                object o = Activator.CreateInstance(type);//直接穿type就是调用无参构造函数
                object o1 = Activator.CreateInstance(type, new object[] { 123 });
                object o2 = Activator.CreateInstance(type, new object[] { "123" });

            }
            Console.WriteLine("\n");
            //MVC调用反射创建的对象方法        /MVC中在用/MVC URL地址一类名称+方法名称
            {

                Assembly assembly = Assembly.Load("Test.DB.SqlServer");
                Type type = assembly.GetType("Test.DB.SqlServer.ReflectionTest");
                object o = Activator.CreateInstance(type);
                //调用无参方法方法
                {
                    Console.WriteLine("调用无参方法方法");
                    MethodInfo method = type.GetMethod("Show1");//根据方法名获取方法
                    method.Invoke(o, null);//传入实例对象和参数
                }
                //调用有参方法方法
                {
                    Console.WriteLine("调用有参方法");
                    MethodInfo method = type.GetMethod("Show2");
                    method.Invoke(o, new object[] { 123 });
                }
                //调用重载方法
                {
                    Console.WriteLine("调用重载方法");
                    MethodInfo method = type.GetMethod("Show3", new Type[] { });
                    method.Invoke(o, new object[] { });
                    MethodInfo method2 = type.GetMethod("Show3", new Type[] { typeof(int) });
                    method2.Invoke(o, new object[] { 123 });
                    MethodInfo method3 = type.GetMethod("Show3", new Type[] { typeof(int), typeof(string) });
                    method3.Invoke(o, new object[] { 123, "555" });
                    MethodInfo method4 = type.GetMethod("Show3", new Type[] { typeof(string), typeof(int) });
                    method4.Invoke(o, new object[] { "555", 123 });
                }
                //调用静态方法
                {
                    Console.WriteLine("调用静态方法");
                    MethodInfo method = type.GetMethod("Show5");
                    method.Invoke(o, new object[] { "沙雕" });
                    method.Invoke(null, new object[] { "果然" });
                }
                //调用私有方法
                {
                    Console.WriteLine("调用私有方法");
                    MethodInfo method = type.GetMethod("Show4", BindingFlags.Instance | BindingFlags.NonPublic);
                    method.Invoke(o, new object[] { "沙雕" });
                }
            }
            Console.WriteLine("\n");
            //泛型类的构造
            {
                Assembly assembly = Assembly.Load("Test.DB.SqlServer");
                Type type = assembly.GetType("Test.DB.SqlServer.GenericClass`3");  //泛型类型需要通过类名+`N获取类型    N是泛型类型的个数
                //object o = Activator.CreateInstance(type);//直接穿type就是调用无参构造函数因为是泛型类得传递类型所以这块创建不了对象
                Type newType = type.MakeGenericType(new Type[] { typeof(int), typeof(string), typeof(DateTime) });
                object o = Activator.CreateInstance(newType);
            }
            Console.WriteLine("\n");
            //泛型类中的泛型方法使用
            {
                Assembly assembly = Assembly.Load("Test.DB.SqlServer");

                Type type = assembly.GetType("Test.DB.SqlServer.GenericDouble`1");//获取泛型类
                Type newType = type.MakeGenericType(new Type[] { typeof(int) });//绑定泛型类型
                object o = Activator.CreateInstance(newType);//创建泛型类对象
                MethodInfo method = newType.GetMethod("Show");//获取泛型方法
                MethodInfo newMethod = method.MakeGenericMethod(new Type[] { typeof(int), typeof(string) });//绑定泛型方法类型
                newMethod.Invoke(o, new object[] { 123, 123, "333" });//使用泛型方法
            }
            Console.WriteLine("\n");
            //ORM反射获取属性和字段
            {
                try
                {


                    //一般笨法实现
                    {


                        People people = new People();
                        people.Id = 123;
                        people.Name = "ALONG";
                        people.Description = "高级队友";
                        Console.WriteLine($"ID:{people.Id},Name:{people.Name},Description:{people.Description}");

                        ///通过反射可以实现   属性不写死
                        Type type = typeof(People);//获取类型
                        object oPeople = Activator.CreateInstance(type);//创建对象
                                                                        //遍历属性并赋值
                        foreach (var prop in type.GetProperties())
                        {
                            //Type propType=prop.PropertyType;获取属性类型
                            Console.WriteLine(type.Name);//获取类型名
                            Console.WriteLine(prop.Name);//获取属性名
                            Console.WriteLine(prop.GetValue(oPeople));//获取属性值
                            if (prop.Name.Equals("Id"))
                            {
                                prop.SetValue(oPeople, 123);//设置id属性值
                            }
                            else if (prop.Name.Equals("Name"))
                            {
                                prop.SetValue(oPeople, "ALONG");//设置name属性值
                            }
                            Console.WriteLine($"{type.Name}.{prop.Name}={prop.GetValue(oPeople)}");
                        }
                        //遍历字段并赋值
                        foreach (var field in type.GetFields())
                        {
                            Console.WriteLine(type.Name);//获取类型名
                            Console.WriteLine(field.Name);//获取字段名
                            Console.WriteLine(field.GetValue(oPeople));//获取字段值
                            if (field.Name.Equals("Description"))
                            {
                                field.SetValue(oPeople, "高级队友");//设置Description字段值
                            }

                            Console.WriteLine($"{type.Name}.{field.Name}={field.GetValue(oPeople)}");
                        }
                    }

                    ///DTO应用 
                    {
                        People people = new People();
                        people.Id = 123;
                        people.Name = "ALONG";
                        people.Description = "高级队友";

                        //PeopleDTO peopleDTO = (PeopleDTO)people;
                        //硬绑定
                        {
                            PeopleDTO peopleDTO = new PeopleDTO()
                            {
                                Id = people.Id,
                                Name = people.Name,
                                Description = people.Description
                            };
                        }
                        //反射实现 好处在对泛型类型的字段或者属性处理方便
                        {
                            Type typePeople = typeof(People);
                            Type typePeopleDTO = typeof(PeopleDTO);
                            object peopleDTO = Activator.CreateInstance(typePeopleDTO);
                            //对DTO属性遍历并在People中找值赋值
                            foreach (var prop in typePeopleDTO.GetProperties())
                            {
                                //if (prop.Name.Equals("Id"))
                                //{
                                //    //object value = typePeople.GetProperty("Id").GetValue(people);
                                //    object value = typePeople.GetProperty(prop.Name).GetValue(people);
                                //    prop.SetValue(peopleDTO, value);
                                //}
                                //else if(prop.Name.Equals("Name"))
                                //{
                                //    //object value = typePeople.GetProperty("Name").GetValue(people);
                                //    object value = typePeople.GetProperty(prop.Name).GetValue(people);
                                //    prop.SetValue(peopleDTO, value);
                                //}
                                //DTO里有的上people里找值并赋值给DTO对象
                                object value = typePeople.GetProperty(prop.Name).GetValue(people);
                                prop.SetValue(peopleDTO, value);
                            }
                            //对DTO字段遍历并在People中找值赋值
                            foreach (var filed in typePeopleDTO.GetFields())
                            {
                                //在people中找与DTO相同名称的字段值
                                object value = typePeople.GetField(filed.Name).GetValue(people);
                                //将值赋值给DTO对象的对应字段
                                filed.SetValue(peopleDTO, value);
                            }


                        }

                    }


                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }







            }
            Console.WriteLine("\n");


            //属性名称对应不上可以通过特性来实现绑定赋值
            //反射好处 
            //动态:可以不把程序写死  可配置 可扩展 
            Console.ReadKey();
        }






    }

















}
