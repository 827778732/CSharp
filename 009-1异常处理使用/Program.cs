using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            try//捕获异常
            {
                C();
            }
            catch (Exception e)//处理捕获的异常
            {
                Console.WriteLine(e.Message);//异常信息
                Console.WriteLine("异常处理完成");
            }
            finally//只要程序未退出就执行
            {
                Console.WriteLine("finally已被执行");
            }

        }


    }
}
