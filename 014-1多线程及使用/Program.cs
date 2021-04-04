using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _014_1多线程及使用
{


    class TestClient
    {
        private Thread workThread;
        private Context mainThreadSynContext;
        private string a = "正在等待子线程执行";

        //构造方法为主线程执行的方法
        public TestClient()
        {
            //获取当前线程   主线程
            mainThreadSynContext = Thread.CurrentContext;


            //创建子线程
            workThread = new Thread(new ThreadStart(Zix));
            workThread.Start();

            while (true)
            {
                Console.WriteLine(a);
                Thread.Sleep(1000);
            }
        }

        //回调函数
        public void OnConnected()
        {
            a = "子线程执行完成";
            Console.WriteLine("嘿嘿我回到主线程了");

        }

        //子线程函数 执行完毕调用回调函数回到主线程
        public void Zix()
        {
            Thread.Sleep(5000);
            mainThreadSynContext.DoCallBack(new CrossContextDelegate(OnConnected));

            //mainThreadSynContext.Post(new SendOrPostCallback(OnConnected), null);
        }



    }


    class Program
    {
        static int o = 100;

        static void Run(int count)
        {
            Console.WriteLine($"开启{count}个线程去抢{o}张票");

            new Thread(() =>
            {
                while (true && o >= 0)
                {
                    Thread.Sleep(10);
                    Console.WriteLine($"代号:A;正在强第{--o}张票");
                    Thread.Sleep(10);
                }

            }).Start();
            new Thread(() =>
            {
                while (true && o >= 0)
                {
                    Thread.Sleep(10);
                    Console.WriteLine($"代号:B;正在强第{--o}张票");
                    Thread.Sleep(10);
                }

            }).Start();


        }



        static void Main(string[] args)
        {
            int aa = System.Environment.TickCount;




            //并行(同时进行)线程三种写法For、ForEach、Invoke   推荐使用场景，循环特别耗，Invoke可以调用复杂方法
            //一般4核处理器最多并行8个线程
            Parallel.For(1, 11, x => {
                Console.WriteLine(x);//他不会按照顺序执行
            });
            Console.WriteLine("-------------------------------");



            var Number = Enumerable.Range(20, 10);
            Parallel.ForEach(Number, x =>
            {
                Console.WriteLine(x); //他不会按照顺序执行
            });
            Console.WriteLine("-------------------------------");


            Parallel.Invoke(
                () => { Console.WriteLine("Hello"); },
                () =>  Console.WriteLine("aaa"),
                () => Console.WriteLine("bbb")
                );



            //Run(5);
            //TestClient t = new TestClient();
            Console.WriteLine(((System.Environment.TickCount - aa) / 1000.0).ToString() + "s 票被抢光");
            Console.ReadKey();
        }














    }







}
