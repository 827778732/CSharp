using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_1委托的使用
{
    //委托的好处：多个方法可以同时执行：多播委托        同一个方法可以多次执行


    //声明自定义委托
    public delegate void Run(int i);
    
    //其他自定义的委托
    public delegate int AAA(int a, out int b);
    public delegate int BBB(int a, ref int b, out int c);


    class Program
    {
        public static void Run1(int i)
        {
            Console.WriteLine(i);
        }

        public static void Run2(int i)
        {
            Console.WriteLine(i);
        }
        public static void Run3(int i)
        {
            Console.WriteLine(i);
        }
        public static int Run4() => 33;
        public static int Run5() => 33;
        public static int Run6() => 33;

        public static int Run7(int i) => i;
        public static int Run8(int i, int j) => i + j;
        public static int Run9(int i, int j, int k) => i + j + k;

        public static int AAA1(int a, out int b)
        {
            b = 50;
            return a+b; 
        }

        public static int BBB1(int a, ref int b, out int c)
        {
            a = 50;
            c = 50;
            b = 50;
            return a + b + c;
        }





        static void Main(string[] args)
        {
            //实例化委托  传入方法参数
            Run r = new Run(Run1);
            //多播委托
            r += Run2;
            r += Run3;
            r.Invoke(66);
            Console.WriteLine();
            foreach (var item in r.GetInvocationList())
            {
                Console.WriteLine(item.Method);
            }
            r -= Run1;
            r.Invoke(55);
            Console.WriteLine();

            //使用系统定义好的委托Action  不含有返回值,且只有一个参数的方法
            {
                Action<int> action = new Action<int>(Run1);
                action += Run2;
                action += Run3;
                action.Invoke(44);
                Console.WriteLine();
            }


            //使用系统的Func委托则是 必须有返回值的方法，参数数量可以为0-16个 其余方法无效
            {//一个返回值
                Func<int> func = new Func<int>(Run4);
                func += Run5;
                func += Run6;
                func.Invoke();
                Console.WriteLine();
            }

            {//分别含有一个两个三个int参数的方法且有一个返回值为int
                Func<int, int> func = new Func<int, int>(Run7);
                Func<int, int, int> func1 = new Func<int, int, int>(Run8);
                Func<int, int, int, int> func2 = new Func<int, int, int, int>(Run9);
                Console.WriteLine(func.Invoke(50));
                Console.WriteLine(func1.Invoke(50, 50));
                Console.WriteLine(func2.Invoke(50, 50, 50));
                Console.WriteLine();
            }

            //自定义的委托使用
            {
                int outb = 0;
                AAA a = new AAA(AAA1);
                a.Invoke(50,out outb);
                Console.WriteLine($"outb={outb}");
                Console.WriteLine();
            }
            {//作为ref的变量使用前赋值
                int refb=50, outc;
                BBB b = new BBB(BBB1);
                b.Invoke(50, ref refb, out outc);
                Console.WriteLine($"refb={refb},outc={outc}");
                Console.WriteLine();
            }



            Console.ReadKey();

        }
    }
}
