using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//(1)C#语言只允许单继承，即派生类只能有一个基类；
//(2)C#继承是可以传递的，C继承B，B继承A，那么C不但继承B的成员，还继承A中的成员。
//(3)派生类可以添加新成员，但不能删除继承的成员；
//(4)派生类不能继承基类的构造函数、析构函数和事件；但能继承基类的属性；
//(5)派生类的对象也是其基类的对象，但基类的对象不是其派生类的对象。故基类的引用变量可以引用其派生类对象。
//派生类继承基类的公有成员

//const: 用来声明某个常量字段或常量局部变量，必须在声明常量时赋初值。
//且const为static的

//readonly: 用来声明只读字段。
//只读字段可以在声明或构造函数中初始化，每个类或结构的实例都有一个独立的副本。
//可以与static一起使用，声明静态只读字段。
//静态只读字段可以在声明或静态构造函数中初始化，静态常量字段只有一个副本。

//virtual: 用于修饰方法、属性、索引器或事件声明，并使它们可以在派生类中被重写。
//默认情况下，方法是非虚拟的。不能重写非虚方法。
//virtual修饰符不能与static、abstract、private或override修饰符一起使用。


//override: 要扩展或修改继承的方法、属性、索引器或事件的抽象实现或虚实现，必须使用override修饰符。
//重写的成员必须是virtual、abstract或override的。


//通过对属性中的get,set方法来控制属性的可读写性
namespace _006_3类继承的使用
{
    public class Boss
    {
        public readonly int A = 66;   //只读字段公共成员  只能直接接赋值或在构造函数中赋值 
        public static int Sum = 666;//公共静态成员
        public int a;
        private int b;
        private int count;
        public int Count { set { this.count = value;}}//只有set访问器所以为只写属性
        public Boss() { }
        public Boss(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public void Run() => Console.WriteLine("这是基类的公有方法Run"); //父类公有方法可以被子类通过new隐藏
        private void Run2() => Console.WriteLine("这是基类的私有方法2");
        public virtual void Run3() => Console.WriteLine("这是基类的虚方法Run3");//虚方法可以不重写

    }


    /// <summary>
    /// Boos子类继承于Boss
    /// </summary>
    public class Boss子类 : Boss
    {
        public Boss子类()
        {
            base.a = 50;
        }

        public Boss子类(int a, int b) : base(a, b) { }
        
        
        //(在派生类直接抹去父类的Run3方法)重写父类的虚方法
        //只要是子类构造的,不管是父类引用还是子类引用调用该方法都会调用重写之后的方法
        public override void Run3()
        {
            Console.WriteLine("重写父类的虚Run3方法");
        }


        //隐藏父类的公有方法
        //父类构造调用的就是父类方法,子类构造调用的就是隐藏方法
        public new void Run()
        {
            Console.WriteLine("子类隐藏父类的Run方法");
        }


    }

    class Program
    {
        static void Main(string[] args)
        {

            //子类构造父类引用  隐式转换  向上转型一般是安全的
            Boss boss = new Boss子类();
            boss.Run3();//子类重写了方法Run3/所以调用子类的Run3方法
            boss.Run();//子类隐藏了父类的Run方法/通过父类引用可以调用父类的Run方法

            //若要安全向下转型则

            //1.通过is判断   -----若A is B   返回为true则说明A可以转换成B
            if (boss is Boss子类) {Console.WriteLine("可以转换"); }
           

            //2.通过as转换  B b= A as B  若转换成功  返回B类型的A   转换失败返回NULL
            Boss子类 boss子类 = boss as Boss子类;//重新转换为子类引用
            boss子类.Run3();//子类的重写方法
            boss子类.Run();//调用子类的隐藏方法
            



            //总结:
            //虚方法调用,什么类型构造调用的就是什么类型的方法     前提:子类重写该虚方法
            //隐藏方法调用,什么类型声明调用的就是什么类型的方法    前提:子类隐藏该公有方法
            Console.ReadKey();
        }
    }
}
