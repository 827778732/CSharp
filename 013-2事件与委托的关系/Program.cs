using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_2事件与委托的关系
{
    //事件本质是一个被限制的委托变量
    //事件不能像委托一样定义在命名空间中
    //事件使用分两部    注册事件(订阅)  使用事件
    //事件使用 发布-订阅（publisher-subscriber） 模型。
    public delegate void delegate_Show(string tag);

   


    class Program
    {
        //定义事件变量
        public static event delegate_Show event_Show;

        //事件方法 将来要注册到事件中的方法
        public static void Program_ShowEvent(string name)
        {
            Console.WriteLine($"{name}:我是事件");
        }

        public static void Show(string tag)
        {
            Console.WriteLine(tag + ":hello");
        }

     




        static void Main(string[] args)
        {
            //委托使用
            {
                //简易的写法
                {
                    delegate_Show delegate_Show = Show;
                    delegate_Show("bb");
                }
                {
                    delegate_Show delegate_Show = new delegate_Show(Show);
                    delegate_Show.Invoke("aa");
                }
            }



            {
                //注册事件
                event_Show += Program_ShowEvent;

                //调用事件     先判断一下事件是否为空
                if (event_Show != null)
                {
                    event_Show("老逼登");
                }



            }
           







        }












    }
}
