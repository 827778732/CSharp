using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _004_1String类型的使用
{
    //String字符串常量每次赋值都会指向新的地址

    class Program
    {
        static void Main(string[] args)
        {
            //String字符串类常用方法
            string str = "abcdefg";


            /*1.字符串转换为其他类型*/
            char[] c = str.ToArray();//转换为数组
            List<char> cList = str.ToList();//转换为集合
            Console.WriteLine("转换为小写" + str.ToLower());//转换为小写
            Console.WriteLine("转换为大写" + str.ToUpper());//转换为大写
            //......等转换
            Console.WriteLine("--------------------------------------");




            /*2.字符串比较*/   //三种空字符串类型"",null,string.Empty 
            string a = "abc", b = "abc", d = "", e = null, f = "  ";
            Console.WriteLine("a和b是否有相同的值" + a.Equals(b));
            Console.WriteLine($"d是否是空串{string.IsNullOrEmpty(d)}");
            Console.WriteLine($"e是否是空串{string.IsNullOrEmpty(e)}");
            Console.WriteLine($"f是否是空串或者空格字符组成{string.IsNullOrWhiteSpace(f)}");
            Console.WriteLine("--------------------------------------");




            /*3.字符串增改*/     //填充//插入//
            string str2 = "  abcde";
            //PadLeft字符串填充  默认填充空格 可以指定填充字符
            Console.WriteLine("用*实现右对齐   " + str2.PadLeft(10, '*'));
            Console.WriteLine("用空格实现左对齐" + str2.PadRight(10));
            Console.WriteLine("用*实现左对齐" + str2.PadRight(10, '*'));
            //Insert字符串插入
            Console.WriteLine("开头插入a" + str2.Insert(0, "a"));
            Console.WriteLine("结尾插入a" + str2.Insert(str2.Length, "a"));
            Console.WriteLine("--------------------------------------");




            /*4.字符串删改*/     //截取//删除//
            //Trim的使用
            Console.WriteLine("移除开头空格" + str2.TrimStart());//默认移除开头空格
            Console.WriteLine("移除结尾含d或e字符" + str2.TrimEnd(new char[] { 'd', 'e' }));//移除结尾含d或e的字符
            Console.WriteLine("移除开头结尾空格" + str2.Trim());////默认为移除开始和结尾空格   可以为其添加移除的项的参数
            //Substring使用
            Console.WriteLine("开头截取到结尾" + str2.Substring(0, str2.Length));
            Console.WriteLine("从3号索引开始截取2个长度" + str2.Substring(3, 2));
            //Remove使用
            Console.WriteLine("从5号索引删除到结尾" + str2.Remove(5));
            Console.WriteLine("从0号索引删除3个长度" + str2.Remove(0, 3));
            Console.WriteLine("--------------------------------------");




            /*5.字符串查找*/   //查找//替换//
            string str3 = "abcdefgdef";
            //Indexof使用
            Console.WriteLine("字符串def开始出现的位置" + str3.IndexOf("def"));
            Console.WriteLine("字符串def最后出现的位置" + str3.LastIndexOf("def"));
            //Replace使用
            Console.WriteLine("所有d字符替换成f字符" + str3.Replace('d', 'f'));
            Console.WriteLine("所有def字串替换成-字符" + str3.Replace("def", "-"));




            //字符串其他用法
            //string.Format 占位符
            string xiaoming = string.Format("{0}{1}{2}", "小明", "22岁", "191cm");
            Console.WriteLine(xiaoming);
            //@取消转义
            string bbb = @"\f\n\b";
            Console.WriteLine(bbb);
            //@跨行输出 选中TAB
            string xiaowang = @"
                                0,
                                1,
                                2,
                                3";
            Console.WriteLine(xiaowang);
            //$字符串穿插  {}中加变量或者常量
            string xiaohong = $"小旭{22}岁,是个{"潮B"}";
            Console.WriteLine(xiaohong);



            Console.WriteLine("-------------------");
           



            //总结:操作量小好处理的用String
            //大量操作StringBuilder最好用
            Console.ReadKey();
        }
    }
}
