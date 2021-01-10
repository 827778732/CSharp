using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_2类成员及其使用
{
    //类成员有  
    //属性、方法、索引器、代理、事件、嵌套类、常量、字段（静态字段，实例字段）。
    //实例构造函数、析构函数、静态构造函数

    //成员的修饰符有：
    //abstract、sealed、delegate、const、event、extern、override、readonly、static、virtual。

    //静态类成员(必须)为静态的
    //非静态类(可以)有静态成员
    //实例成员属于对象,静态成员属于类


    static class MyStaticClass
    {
        //以下都属于类
        private static int age;
        public static int GetAge => age;
    }

    public class MyClass
    {
        //实例构造函数
        public MyClass()
        {
            for (int i = 0; i < 10; i++)
            {
                data[i] = "这是一个字符串"+i;
            }
        }
        //属于实例对象的字段
        private string[] data = new string[10];
        //属于类的字段
        private static int count = 0;
        //属于实例对象的索引器
        public string this[int index] => data[index];
        public int this[string str]//重载索引器
        {
            get
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (str.Equals(data[i]))
                        return i;
                }
                return -1;
            }
        }

        /// <summary>
        /// 嵌套内部类
        /// </summary>
        public class My
        {
            
        }
    }











    class Program
    {

        static void Main(string[] args)
        {
            MyClass my = new MyClass();
            Console.WriteLine(my[0]);//通过类成员索引器来方法类成员
            Console.WriteLine(my["这是一个字符串6"]);//类似于key-value的索引器,通过值来找索引
            


            //总结:实例成员属对象,静态成员属于类
            Console.ReadKey();
        }
    }











}
