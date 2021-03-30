using _012_1特性的使用.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//不反射特性就无用
namespace _012_1特性的使用
{
    /// <summary>
    /// 1 特性attribute,和注释有什么区别
    /// 2 声明和使用attribute attributeUsage
    /// 3 运行时中获取attribute 额外信息 额外操作
    /// 4 Remark封装、attribute验证
    /// 
    /// 
    /// 特性：中括号声明就是一个类
    /// 自定义特性必须直接/间接继承Attribute   一般命名以Attribute使用时可以省略
    /// 
    /// 
    /// 错觉：每一个特性可以带来对应的功能
    /// 实际特性添加后，编译会在元素内部产生IL 但是我们无法直接使用
    /// 而且在metadata会有记录
    /// 
    /// 特性，本身是没用的
    /// 程序运行的过程中找到特性,而且也能使用特性类
    /// 任何一个可以生效的特性  都是有地方主动使用的
    /// 
    /// 
    /// 没有破坏类型封装的前提下，可以加点额外的属性和行为
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                {
                    Student stu = new Student();
                    stu.Id = 123;
                    stu.Name = "WBB";
                    stu.QQ = 999;
                    //stu.Study();
                    //string result = stu.Answer("Enven");
                    Manager.Show(stu);
                }
                {

                    UserState userState = UserState.Norml;
                    //if (userState == UserState.Norml)
                    //{
                    //    Console.WriteLine("正常状态");
                    //}
                    //else if (userState == UserState.Frozen)
                    //{
                    //    Console.WriteLine("冻结");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("删除");
                    //}
                    //一般实现
                    Console.WriteLine(RemarkExtension.GetRemark(UserState.Norml));


                    //扩展方法实现
                    Console.WriteLine(userState.GetRemark());
                    Console.WriteLine(UserState.Frozen.GetRemark());
                    Console.WriteLine(UserState.Deleted.GetRemark());
                   


                    //检查
                
                }




            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); 
            }


            Console.ReadKey(); 
        }
    }
}
