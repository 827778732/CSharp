using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_1接口的使用
{

    //1.接口是一个引用类型，通过接口可以实现多重继承。
    //2接口成员不能有public、protected、private、static、abstract、override、virtual、internal修饰符，使用new修饰符不会报错，但会给出警告说不需要关键字new。
    //3.接口成员的访问级别是默认的（默认为public），所以在声明时不能再为接口成员指定任何访问修饰符，否则 编译器会报错。
    //接口成员可以分为4类：方法、属性、事件、索引器，而不能包含成员变量
    //接口的修饰符可以是,类内:new、private、protected 命名空间内:public、internal、partial

    delegate void Boom();//委托定义---属于命名空间

    interface IInterface //接口命名一般为I开头
    {
        void Run();//定义方法
        int Age { get; set; }//定义属性
        event Boom boom;//定义事件
        int this[int index] { get; set; }//定义索引器
    }




    class MyClass : IInterface //继承接口就应该实现接口成员
    {
        private int[] data = new int[10];
        private int age;
        public MyClass()
        {
            for (int i = 0; i < 10; i++)
            {
                data[i] = i;
            }
        }
        public int this[int index] { get => this.data[index]; set => this.data[index] = value; }
        public int Age { get => this.age; set => this.age = value; }
        //显式实现的接口属性
        int IInterface.Age { get; set; }
        public event Boom boom;
        //显式实现接口方法只能是类转为IInterface接口类型才能使用
        void IInterface.Run()
        {
            Console.WriteLine("显式实现的父类Run方法");
        }
        //隐式实现的接口成员可以用 virtual、static、abstract(抽象类继承接口可以使用)、override(父类virtual修饰的方法子类才能用)
        public void Run()
        {
            Console.WriteLine("隐式实现的父类Run方法");
        }
    }


    /// <summary>
    /// 子类再次继承IInterface接口------实现子类显式实现接口成员
    /// </summary>
    class MyClass子类 : MyClass, IInterface
    {
        //隐藏继承父类隐式实现的接口方法
        public new void Run()
        {
            Console.WriteLine("隐藏父类隐式实现的接口方法");
        }

        //继承IInterface接口以来显式实现接口方法
        void IInterface.Run()
        {
            Console.WriteLine("子类显式实现的接口方法");
        }

    }

    abstract class AvstractClass : IInterface
    {
        public int this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public event Boom boom;
        public abstract void Run();//只有抽象类继承接口才能使隐式实现的接口方法为抽象方法

        void IInterface.Run()//显式实现接口的方法
        {
            Console.WriteLine("抽象类显式实现的接口方法");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.Run();//这样使用的是隐式的接口方法
            myClass.Age = 100;//使用隐式的接口属性
            Console.WriteLine("-------------------------");

            IInterface I = (IInterface)myClass;//转换为接口类型,就可以使用显示实现的接口成员
            I.Run();//使用的是显式接口方法
            I.Age = 50;//使用显式的接口属性
            Console.WriteLine("-------------------------");



            MyClass子类 myClass1 = new MyClass子类();
            myClass1.Run();//使用被覆盖继承的隐式接口方法
            Console.WriteLine("-------------------------");



            //若子类继承了IInterface接口
            //子类显式实现接口的Run方法,(并且转换为对应接口类型)调用的就是显式子类接口方法
            //若没有显式实现Run方法则调用的就是继承过来隐式方法(也可在子类隐藏)
            //--------------------------------------------------
            //若子类没有继承IInterface接口
            //子类无法显式实现接口的Run方法
            //(转换为对应的接口类型)调用的就是父类的显式接口方法
            IInterface b = (IInterface)myClass1;//将子类转换为接口类型  
            b.Run();//由于子类显式实现了接口方法则调用的就是子类的显式接口方法
            Console.WriteLine("-------------------------");




            //总结:只有继承了接口的类才能显式实现接口的方法且不能被继承,通过转换为接口类型来调用
            //隐式实现的接口方法都被子类所继承,子类可加new加以隐藏
            Console.ReadKey();
        }


    }
}
