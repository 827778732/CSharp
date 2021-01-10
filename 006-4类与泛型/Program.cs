using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_4类与泛型
{
    //泛型,类、接口、方法、数组、委托、结构等
    //在写程序时，若需要处理的数据类型不同，但算法相同时，这时候需要用到泛型。
    //泛型提供了编译时类型安全检测机制，该机制允许程序员在编译时检测到非法的类型。
    //泛型的本质是参数化类型，也就是说所操作的数据类型被指定为一个参数。


    //泛型类：定义一个类，这个类中某些字段的类型不确定，这些类型可以在类构造的时候确定下来。
    //使用where实现对泛型的约束 则M只能是struct的子类型否则编译错误
    class MyClass<T> where T : struct
    {
        private T a;
        public MyClass(T a) => this.a = a;
        //泛型方法就是定义一个方法，这个方法的参数类型可以是不确定的，当调用这个方法时再去确定这个方法参数的类型。
        public void Print<S>(S s) => Console.WriteLine(s.ToString());
        //泛型也可以通过object类型参数类型实现类型装箱  ---处理值类型系统自动拆箱
        //若处理引用类型时，必须要进行类型的强制转换，也会产生一定的影响，甚至因为类型强制转化而出现错误。
        public void Sum(object a, object b) => Console.WriteLine(a + "和" + b);
        //也可以对泛型方法的类型进行约束
        public void Print<M>(M m, M b) where M : struct
        {
            Console.WriteLine(m.GetType()+"\n"+b.GetType());
        }

    }




    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList通过object参数方法实现泛型。系统会自动进行拆箱、装箱操作，这将对系统的性能产生影响，
            System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
            //List通过泛型类的方法实现泛型,在构造时确定类内部分字段的类型
            List<int> list = new List<int>();




            //总结:字段类型不确定通过泛型来解决,泛型加where可以约束类型范围如:where struct
            Console.ReadKey();
        }
    }



}
