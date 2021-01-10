using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_1类的声明使用
{
    /*类的访问修饰符*/
    //public: 同一程序集(DLL或EXE)中的任何其他代码或引用该程序集的其他程序集都可以访问该类型或成员。
    //private: 只有同一类或结构中的代码可以访问该类型或成员。
    //protected: 只有同一类或结构或者此类的派生类中的代码才可以访问该类型或成员。
    //internal: 同一程序集中的任何代码都可以访问该类型或成员，但的代码不可以。
    //protected internal: 在一程序集中，protected internal体现的是internal的性质；在其他程序集中，protected internal体现的是protected的性质。


    /*类的类型修饰符*/
    //abstract：用于声明虚类，指示某个类只能是其他类的基类。 抽象类
    //sealed：指定类不能被继承。
    //static：声明静态类，类型本身只含有静态成员，不能被实例化。 
    //partial: 部分在整个同一程序集中定义分部类、结构和方法。类的分部
 

    /// <summary>
    /// 使用static修饰的类为静态类，静态类所有成员都必须是静态的，不能与abstract、sealed一起使用。
    /// static可以修饰方法、字段、属性或事件，始终通过类名而不是实例名称访问静态成员，静态字段只有一个副本。
    /// 静态类不能被实例化。
    /// </summary>
    static class MyStaticClass
    {
        //静态类无法实例化故无构造方法
        private static int a;  //静态类只能有静态成员
        public static void Run() { }//只能是静态成员方法
        public static string Name { get; set; }//只能是静态的属性
        public delegate void Run2(int x, int y);//可以有委托

    }

    /// <summary>
    /// 使用abstract修饰的类为抽象类，抽象类只能是其他类的基类，不能与sealed、static一起使用
    /// abstract可以修饰抽象类中的方法或属性，此时，方法或属性不能包含实现，且访问级别不能为私有。
    /// 抽象类不能被实例化。
    /// </summary>
    abstract class MyAbstractClass
    {
        private int a;
        public MyAbstractClass(int a) => this.a = a;//抽象类可以被继承故可以有构造方法
        public abstract void Run();//抽象方法只能声明无方法体   --注意:只有在抽象类中才有抽象方法,且子类继承抽象类必须实现抽象方法
        public static void Run2() { }//抽象类可以有静态方法
        public virtual void Run3() { }//抽象类可以有虚方法       --注意:派生类可以不重写虚方法
        public void Run4() { }//抽象类可以有实例方法
        public override sealed string ToString() { return null; }//抽象类可以有密封的重写方法

    }



    /// <summary>
    /// 使用sealed修饰的类为密封类，密封类无法被继承，不能和abstract、static一起使用。
    /// 当sealed用于方法或属性时，必须始终与override一起使用。
    /// </summary>
    sealed class MySealedClass
    {
        private int a;
        public MySealedClass(int a) => this.a = a;
        public static void Run() { }
        public override sealed string ToString() //sealed只能作用于override方法
        {
            return base.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            //总结:静态类不实例,抽象类里不私有,密封类里不继承
        }
    }

}
