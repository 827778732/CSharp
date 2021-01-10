using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//异常是在程序执行期间出现的问题。C# 中的异常是对程序运行时出现的特殊情况的一种响应，比如尝试除以零。
//异常提供了一种把程序控制权从某个部分转移到另一个部分的方式。C# 异常处理时建立在四个关键词之上的：try、catch、finally 和 throw。

//try：一个 try 块标识了一个将被激活的特定的异常的代码块。后跟一个或多个 catch 块。
//catch：程序通过异常处理程序捕获异常。catch 关键字表示异常的捕获。
//finally：finally 块用于执行给定的语句，不管异常是否被抛出都会执行。例如，如果您打开一个文件，不管是否出现异常文件都要被关闭。
//throw：当问题出现时，程序抛出一个异常。使用 throw 关键字来完成。
namespace _009_1异常处理使用
{
    class Program
    {
        static void C(int a = 0, int b = 0)
        {
            Console.WriteLine(a / b);
        }

        static void Main(string[] args)
        {
            //try//捕获异常
            //{
            //    C();
            //}
            //catch (Exception e)//处理捕获的异常
            //{
            //    Console.WriteLine(e.Message);//异常信息
            //    Console.WriteLine("异常处理完成");
            //}
            //finally//只要程序未退出就执行
            //{
            //    Console.WriteLine("finally已被执行");
            //}



            //自定义异常的使用
            TestClass test = new TestClass();
            try
            {
                test.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           







            //总结:异常是对程序运行期间的一种对异常响应,出现异常提醒用户,并对异常处理
            //自定义异常扩展的异常的作用
            Console.ReadKey();
        }


        /// <summary>
        /// 自定义异常类 继承于ApplicationException
        /// </summary>
        class TestException :ApplicationException
        {
            public TestException(string message):base(message)
            { 

            }
        }
        /// <summary>
        /// 测试类
        /// </summary>
        class TestClass
        {
            /// <summary>
            /// 判断你输入的数是否是不为0的数
            /// 有可能抛出TestException异常
            /// </summary>
            public void Show()
            {
                Console.WriteLine("请输入你的数字");
                int read = Convert.ToInt32(Console.ReadLine());
                if (read==0)
                {
                    throw new TestException("输入为正0或格式不正确");
                }
                else
                {
                    Console.WriteLine("输入正确,您输入的数字为"+read);
                }
            }
        }







    }
}
