using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_2结构类型使用
{
    //struct默认访问性为private
    //结构体是值类型

    // 和类的对比:
    //  　　　　　　　　  　　　　　　　　　　结构 　　　　　　　　　　　　　　　　　　 类
    //数据类型　　　　　　　　　　　　　　　　值类型　　　　　　　　　　　　　　　　　　引用类型
    //是否必须使用new运算符实例化　　　　　　 否　　　　　　　　　　　　　　　　　　　　是
    //是否可声明无参数的构造函数　　　　　　　否　　　　　　　　　　　　　　　　　　　　是
    //数据成员可否在声明的同时初始化　　　　　声明为const或static可以，数据成员不可以　 可以
    //直接派生自什么类型　　　　　　　　　　　System.ValueType　　　　　　　　　　　    有
    //是否有析构函数　　　　　　　　　　　　　无　　　　　　　　　　　　　　　　　　　　有
    //可否从类派生　　　　　　　　　　　　　　否　　　　　　　　　　　　　　　　　　　　可以
    //可否实现接口　　　　　　　　　　　　　　可以　　　　　　　　　　　　　　　　　　　可以
    //实例化时在栈还是在堆分配内存　　　　　　栈　　　　　　　　　　　　　　　　　　　　堆，栈中保存引用
    //该类型的变量可否被赋值为null　　　　　　否　　　　　　　　　　　　　　　　　　　　可以
    //可否定义私有的无参构造函数　　　　　　　否　　　　　　　　　　　　　　　　　　　　可以
    //是否总有一个默认的无参构造函数　　　　  是　　　　　　　　　　　　　　　　　　　　否

    //  结构和类的适用场合分析：
    //1、当堆栈的空间很有限，且有大量的逻辑对象时，创建类要比创建结构好一些；
    //2、对于点、矩形和颜色这样的轻量对象，假如要声明一个含有许多个颜色对象的数组，则CLR需要为每个对象分配内存，在这种情况下，使用结构的成本较低；
    //3、在表现抽象和多级别的对象层次时，类是最好的选择，因为结构不支持继承。
    //4、大多数情况下，目标类型只是含有一些数据，或者以数据为主。

    struct Point
    {
        //三维坐标
        private int x;
        private int y;
        private int z;
        //结构体不能有显式无参的构造函数
        public Point(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public void Print()
        {
            Console.WriteLine($"点坐标为\nx:{this.x} y:{this.y} z:{this.z}");
        }
    }
   
    //泛型结构
    struct MyStruct<T>
    {
        List<T> data;
        public MyStruct(List<T> data)
        {
            this.data = data;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point(1, 2, 3);
            A.Print();


            Console.ReadKey();
        }
    }
}
