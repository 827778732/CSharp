using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_1条件循环分支结构使用
{
    //
    //if... else... 
    //for,foreach,while,do while
    //swicth case

    class Program
    {
        static void Main(string[] args)
        {
            //else仅与前一个并且未配对的if匹配
            //for和while用法大致一致
            //do while和while差异:前者是先执行后判断 后者相反
            //foreach用来遍历数组和集合


            /*switch用法*/
            //case后常量类型需要表达式的类型相同
            //case标签后必须有 break闭合标签
            int a = 5;
            switch (a)
            {
                case '5': //char可以隐式转换为int 
                    {
                        break;
                    }
                //case "5": 类型不能通过隐式转换得来报错
                //    {

                //        break;
                //    }

                case 5:
                    {
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
            
            




            Console.ReadKey();
        }
    }
}
