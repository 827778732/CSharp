using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_5类与多态
{

    //多态性往往表现为"一个接口，多个功能"。
    //多态性可以是静态的或动态的。在静态多态性中，函数的响应是在编译时发生的。
    //在动态多态性中，函数的响应是在运行时发生的。



    //静态多态性
    //静态绑定（早期绑定):(编译时)函数和对象的连接机制。 两种技术实现静态多态性：函数重载/运算符重载。
    //1.函数重载 (this索引器也可重载)
    //2.运算符重载
    //+, -, !, ~, ++, --	这些一元运算符只有一个操作数，且可以被重载。
    //+, -, *, /, %	这些二元运算符带有两个操作数，且可以被重载。
    //==, !=, <, >, <=, >=	这些比较运算符可以被重载。
    //&&, ||	这些条件逻辑运算符不能被直接重载。
    //+=, -=, *=, /=, %=	这些赋值运算符不能被重载。
    //=, ., ?:, ->, new, is, sizeof, typeof	这些运算符不能被重载。





    //动态多态性   ------通过(抽象类)和(虚方法)实现的
    //C# 允许您使用关键字 abstract 创建抽象类，用于提供接口的部分类的实现。当一个派生类继承自该抽象类时，实现即完成。抽象类包含抽象方法，抽象方法可被派生类实现。派生类具有更专业的功能。
    //请注意，下面是有关抽象类的一些规则：
    //1.您不能创建一个抽象类的实例。
    //2.您不能在一个抽象类外部声明一个抽象方法。
    //3.通过在类定义前面放置关键字 sealed，可以将类声明为密封类。当一个类被声明为 sealed 时，它不能被继承。抽象类不能被声明为 sealed。








    class Box
    {
        //长宽高
        private int length;
        private int width;
        private int height;


        public void Set(int x, int y, int z)
        {
            this.length = x;
            this.width = y;
            this.height = z;
        }
        public void Area()
        {
            Console.WriteLine(this.length * this.width * this.height);
        }

        //函数重载条件函数名相同参数(类型、个数、顺序)和返回值和修饰无关
        public void Run(int i) => Console.WriteLine("您传递的参数为int型");
        public int Run(double d)
        {
            Console.WriteLine("您传递的参数为double并且返回值为1");
            return 1;
        }
        public void Run(int i, double d) { Console.WriteLine("第一参数为int第二个为double"); }
        public void Run(double d, int i) { Console.WriteLine("第一个参数为double第二个参数为int"); }




        //运算符重载
        public static Box operator +(Box a, Box b)
        {
            Box box = new Box();
            box.length = a.length + b.length;
            box.width = a.width + b.width;
            box.height = a.height + b.height;
            return box;
        }
        public static Box operator -(Box a, Box b)
        {
            Box box = new Box();
            box.length = a.length - b.length;
            box.width = a.width - b.width;
            box.height = a.height - b.height;
            return box;
        }
        //重载==就要重载!=
        public static bool operator ==(Box a, Box b)
        {
            if (a.length == b.length && a.width == b.width && a.height == b.height)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Box a, Box b)
        {
            if (a.length != b.length || a.width != b.width || a.height != b.height)
            {
                return true;
            }
            return false;
        }
        //重载>就要同时重载<
        public static bool operator >(Box a, Box b)
        {
            if (a.length > b.length && a.width>b.width && a.height > b.height)
            {
                return true;
            }
            return false;
        }
        public static bool operator <(Box a, Box b)
        {
            if (a.length < b.length && a.width< b.width && a.height< b.height)
            {
                return true;
            }
            return false;
        }
        //可以通过重载&和|来实现重载&&和||的效果
    }


    /// <summary>
    /// 抽象多态基类
    /// </summary>
    abstract class Shape
    {
        public abstract int Area();
    }

    class Rectangle : Shape
    {
        private int length;
        private int width;
        public Rectangle(int a = 0, int b = 0)//若不给值则默认就为0
        {
            length = a;
            width = b;
        }
        //Console.WriteLine("Rectangle(长方形)类的面积：");
        public override int Area()
        {
            return (width * length);
        }
    }
    class Triangle : Shape
    {
        private int baseLine;
        private int height;
        public Triangle(int a = 0, int b = 0)
        {
            baseLine = a;
            height = b;
        }
        public override int Area()
        {
            //Console.WriteLine("三角形类的面积：");
            return (2 * baseLine * height / 4);
        }
    }

    /// <summary>
    /// 一般多态基类
    /// </summary>
    class Animal
    {
        public virtual void Eat()
        {
            Console.WriteLine("这是animal的eat方法");
        }
    }

    class Dog : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("这是dog的eat");
        }
    }

    class Cat : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("这是cat的eat");
        }

    }








    class Program
    {
        static void Main(string[] args)
        {
            //静态多态性  通过方法重载和运算符重载
            Box a = new Box();
            a.Set(1, 2, 3);
            a.Area();
            Box b = new Box();
            b.Set(4, 5, 6);
            b.Area();
            Box c = a + b;//重载运算符
            c.Area();


            //动态多态性    继承/重写((virtual/abstract)/override)/子类构造父类引用

            //抽象基类实现    做法:abstract/override
            Shape r = new Rectangle(2,3);//实例长方形类
            Console.WriteLine(r.Area());

            Shape t = new Triangle(3, 5);//实例三角形类
            Console.WriteLine(t.Area());

            //一般基类实现    做法:virtual/override
            Animal animal1 = new Animal(); // 实例Animal类
            Animal animal2 = new Dog(); // 实例Dog类
            Animal animal3 = new Cat(); // 实例Cat类

            animal1.Eat(); // 调用Animal类的eat方法
            animal2.Eat(); // 实例Dog类
            animal3.Eat(); // 实例Cat类





            //总结:多态分两种静态多态和动态多态
            //静态多态通过方法重载和运算符重载实现(静态绑定)
            //动态多态通过继承一般类或抽象类实现方法的重写即可
            Console.ReadKey();
        }
    }


}
