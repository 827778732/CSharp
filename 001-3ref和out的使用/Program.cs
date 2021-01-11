using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_3ref和out的使用
{
    //1、使用ref型参数时，ref将值类型强制按引用类型进行传递，out型参数，必须在方法中对其完成初始化。
    //2、out适合用在需要retrun多个返回值的地方，而ref则用在需要被调用的方法修改调用者的引用的时候。
    //3、使用ref和out时，在方法的参数和执行方法时，都要加Ref或Out关键字，以满足匹配。
    //ref:使用前的参数需要初始化, 
    //out:使用前的参数可以不需要初始化，在函数使用out参数时，该参数必须看作是还未赋值的变量。
    //即调用代码可以把已赋值的变量用作out参数，但存储在该变量中的值会在函数执行时丢失。 如果为引用类型，则为null。 
    class Program
    {
        static void Add(ref int a) => a = a + 1;
        static void Add2(int a) => a = a + 1;
        static void Returns(out int a, out int b)
        {
            a = 50; b = 50;
        }

        static void Main(string[] args)
        {
            //1.对于值类型ref的作用效果
            int a = 20, b = 20;
            Add(ref a);//ref把int类型转换为引用类型传递直接修改a的值
            Add2(b);//没有传入引用
            Console.WriteLine($"传入引用a={a},没传入引用b={b}");//a=21,b=20
            //2.对于引用类型ref作用效果
            MyClass my = new MyClass();
            MyClass my2 = new MyClass();
            SetAge(ref my);
            SetAge2(my2);
            Console.WriteLine($"传入引用my.Age={my.Age},没传入引用my2.Age={my2.Age}");
            //我们可以发现参数类型为引用类型时加不加ref效果相同/因为引用变量和引用变量的副本是一样的,它们指向同一个对象
            //如果不用ref传递的是原引用变量的副本,即把原来的引用变量复制一分传递给方法;
            //如果用ref传递的是原引用变量的引用,ref时可以改变原引用变量的指向,使用时要小心,需要时使用.
            //3.ref与string
            string str = "abc", str2 = "abc";
            TestString(ref str);
            TestString2(str2);
            Console.WriteLine($"传引用str={str},没传入引用str2={str2}");
            string str3 = "abc";
            Console.WriteLine(str3.GetHashCode());
            str3 += "777";
            Console.WriteLine(str3.GetHashCode());

            //out的使用
            int OutA, OutB;//作为out的参数定义时可以不赋初值
            Returns(out OutA, out OutB);//传入多个接受返回值的参数
            Console.WriteLine($"OutA={OutA},OutB={OutB}");




            //总结,ref用于向方法传原引用,可以改变原引用(慎用)/out用于处理有多返回值方法的情况
            //string属于密封类实例创建不可变,在上下文使用赋值运算符修改引用,在方法中用ref声明参数修改引用
            Console.ReadKey();
        }


        static void SetAge(ref MyClass my) => my.Age = 50;
        static void SetAge2(MyClass my) => my.Age = 50;
        static void TestString(ref string a) => a = "6666666666";
        static void TestString2(string a) => a = "666666666";

    }

    class MyClass
    {
        public int Age { get; set; }
    }



}
