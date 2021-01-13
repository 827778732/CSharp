using System;
using System.Collections.Generic;
namespace _006_4类与泛型
{
    //泛型,类、接口、方法、数组、委托、结构等
    //在写程序时，若需要处理的数据类型不同，但算法相同时，这时候需要用到泛型。
    //泛型约束一般是基类约束(不能说sealed)
    // 1.约束可以使用基类的属性方法             ------权力
    // 2.保证T一定时约束类型或者约束类型的子类  ------义务
    // 3.泛型可以使用多个,约束可以叠加使用更灵魂
    class MyClass<T>
        //where T : struct
    {
        public T Get<T>(T t)
            where T:class,new()//约束叠加
        //where T : IMyInterface<T> //接口约束   传递过来的参数是接口,或者实现了接口的类
        //where T:class   //引用类型约束
        //where T struct  //值类型约束
        //where T:new()   //无参数构造函数约束
        {
            //t.PingPang()    //接口方法
            //T tNew = null; //引用类型可以为null
            //T tNew = default(T);//值类型可以为默认值
            //T tNew = new T();//无参数构造约束

            return t;
        }



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
            Console.WriteLine(m.GetType() + "\n" + b.GetType());
        }



     



    }

    //泛型委托
    public delegate void SayH<T>(T t);
    //泛型接口
    public interface IMyInterface<T>
    {
        void PingPang();
    }







    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList通过object参数方法实现泛型。系统会自动进行拆箱、装箱操作，这将对系统的性能产生影响，
            System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
            //List通过泛型类的方法实现泛型,在构造时确定类内部分字段的类型
            List<int> list = new List<int>();

            MyClass<int> myClass = new MyClass<int>(2);
            myClass.Print<int>(2);
            myClass.Print(3);


            



            //总结:字段类型不确定通过泛型来解决.
            //T泛型决定类型,where对泛型约束从而使用泛型的类型
            //泛型方法和普通方法效率差不太多比较快,object实现的泛型方法需要自动装拆箱效率下降比较慢
            Console.ReadKey();
        }
    }



}
