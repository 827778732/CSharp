using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static System.Math;

namespace _005_1命名空间与using
{
    //using的用法：
    //1. using指令：引入命名空间
    //这是最常见的用法，例如：
    //using System;
    //using Namespace1.SubNameSpace;

    //2. using static 指令：指定无需指定类型名称即可访问其静态成员的类型
    //using static System.Math;var = PI; // 直接使用System.Math.PI

    //3. 起别名
    //using Project = PC.MyCompany.Project;

    //4. using语句：将实例与代码绑定
    //using (Font font3 = new Font("Arial", 10.0f),
    //            font4 = new Font("Arial", 10.0f))
    //{
    //    // Use font3 and font4.
    //}
    //代码段结束时，自动调用font3和font4的Dispose方法，释放实例。
    class Program
    {
        static void Main(string[] args)
        {
            List<byte> cList = new List<byte>();
            //3.执行完{}释放using()内的对象     //这是因为File实现了IDisposable接口
            using (System.IO.FileStream file = new System.IO.FileStream("Test1.txt", System.IO.FileMode.Open))
            {
                Console.WriteLine(file.Length);
                byte[] data = new byte[file.Length];
                file.Read(data, 0, (int)file.Length);
                cList.AddRange(data.ToList());
            }

            

            //完全限定名的使用  并且引用的是嵌套的命名空间
            MyNamespace1.MyNamespace2.MyClass2 myClass2 = new MyNamespace1.MyNamespace2.MyClass2();
            


            //总结:引用命名空间加using,具体成员可别名,using语句完释放
            //using static 引入常量
            Console.ReadKey();
        }





    }
}

/// <summary>
/// 命名空间嵌套
/// </summary>
namespace MyNamespace1
{
    class MyClass1
    {

    }
    namespace MyNamespace2
    {
        class MyClass2
        {

        }
    }
}
