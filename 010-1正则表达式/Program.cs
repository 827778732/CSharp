using System;
using System.Text.RegularExpressions;
//正则表达式用于匹配字符串            .net提供的正则表达式类Regex
//几大常用方法
//Replace替换指定正则表达式匹配的字符串
//IsMatch指定正则表达式是否匹配到字符串
//Match返回正则表达式的匹配的字符串
//Split根据正则表达式分割字符串

//    字符转义
//    字符类---匹配单个字符
//    定位点---匹配位置
//    分组构造
//    限定符---描述重复次数
//    反向引用构造
//    备用构造
//    替换
//    杂项构造


namespace _010_1正则表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            /*1.--------------------------定位点字符(定位置符)--------------------
             *    ^ 匹配必须(从字符串)或(一行的开头开始)。     $ 匹配必须出现在字符串的(末尾)或(出现在行)或(字符串末尾的 \n 之前)。
             *   \b 匹配单词边界开头/结尾。    \B 匹配单词非边界
             *   \A 指定匹配必须出现在字符串开头 。
             *   \z 指定匹配必须出现在字符串结尾。     \Z 匹配必须出现在字符串的(末尾)或(出现在字符串末尾的\n)之前。
             *   \G 指定匹配必须出现在上一个匹配结束的地方。
             */
            string Input = "I am blue cat";
            Console.WriteLine(Input + " ----测试例子");
            Console.WriteLine(Regex.Replace(Input, @"^", @"(^)匹配到开头的位置"));
            Console.WriteLine(Regex.Replace(Input, @"$", @"($)匹配到结尾的位置"));
            Console.WriteLine(Regex.Replace(Input, @"ue\b", @"(\b)匹配到blue单词边界ue"));
            Console.WriteLine(Regex.Replace(Input, @"lu\B", @"(\B)匹配到blue单词非边界lu"));
            Console.WriteLine("\n");




            /*2.-------------------------基本语法元字符(字符类)--------------------------
             *   . 匹配除换行符(\n)以外的任意字符。     \. 匹配.字符
             *  \w 匹配字母、数字、下划线、汉字。       \W 匹配（除\w之外的字符)   
             *  \s 匹配任意空白字符(如制表\t垂直制表\v换页\f等)。   \S 匹配不是空白的字符)
             *  \d 匹配十进制数字(0-9数字)。  \D 匹配不是十进制数字(0-9数字)
             *  [abc]匹配单个字符(a,b,c)。 [^abc]匹配非(a,b,c)的字符
             *  [a-z]匹配单个字符范围a-z。  [^a-z]匹配的字符不在a-z范围
             */
            string Input2 = "马老师, fuck\tyou 250.";
            Console.WriteLine(Input2 + " ----测试例子");
            Console.WriteLine(Regex.Replace(Input2, @"\.", @"*") + @" (\.)匹配到.字符");
            Console.WriteLine(Regex.Replace(Input2, @"\w", @"*") + @" (\w)匹配到字母数字下划线汉字等");
            Console.WriteLine(Regex.Replace(Input2, @"\s", "*") + @" (\s)匹配到空白字符\n\f\t空格等");
            Console.WriteLine(Regex.Replace(Input2, @"\d", "*") + @" (\d)匹配到十进制数字");
            Console.WriteLine(Regex.Replace(Input2, @"[abc]", "*") + @" ([abc])匹配到方括号内的字符");
            Console.WriteLine(Regex.Replace(Input2, @"[a-h]", "*") + @" ([a-z])匹配到方括号内范围的字符");
            Console.WriteLine("\n");




            /*3.--------------------------限定符(重复描述字符)-----------------------
             * *  匹配上一个元素零次或多次。   *? 对比*附加了次数尽可能少
             * +  匹配上一个元素一次或多次。   +? 对于+附加了次数尽可能少
             * ?  匹配上一个元素零次或一次。   ?? 对于?附加了次数尽可能更少
             *{n}匹配一个元素恰好n次。              {n}?与{n}无区别
             *{n,}匹配上一个元素至少n次             {n,}?与{n,}无区别
             *{n,m}匹配上一个元素至少n次但不多于m次 {n,m}?介于n-m次数直接但次数尽可能少
             */
            string Input3 = "123 abc456 78910def";
            Console.WriteLine(Input3 + @" -----测试用例");
            Console.WriteLine(Regex.Replace(Input3, @"\d*\d", "*") + @" (*)用于匹配上一个字符0或多次");
            Console.WriteLine(Regex.Replace(Input3, @"\d+\d", "*") + @" (+)用于匹配上一个字符1次或多次");
            Console.WriteLine(Regex.Replace(Input3, @"\d?\d", "*") + @" (?)用于匹配上一个字符0或1次");
            Console.WriteLine(Regex.Replace(Input3, @"\d{3}", "*") + @" ({n})用于匹配上一个字符n次");
            Console.WriteLine(Regex.Replace(Input3, @"\d{1,}", "*") + @" ({n,})用于匹配上一个字符至少n次");
            Console.WriteLine(Regex.Replace(Input3, @"\d{1,3}", "*") + @" ({n,m})用于匹配上一个字符至少n次但不多于m次");
            Console.WriteLine("\n");


            /*4.-----------------------构造(只列举几个)----------
            * | 匹配以竖线 (|) 字符分隔的任何一个元素。  ----进行或运算
            * (subexpression) 将括号内作为一个组,列如(\d*\d){2}=>(\d*\d)(\d*\d)
            */
            string Input4 = "user827778732 passwordwyl123567";
            Console.WriteLine(Input4+" -----测试用例");
            Console.WriteLine(Regex.Match(Input4,@"(\d{8,})|(user)"));
            Console.WriteLine(Regex.Match(Input4,@"user\d{8,}"));
            Console.WriteLine(Regex.Match(Input4, @"password\w{8,}"));


            Console.WriteLine(Regex.Match("255.255.255.255 ",@"(\d{1,}.)(\d{0,}.){2}(\d{0,})"));




            //字符串(格式)匹配正则表达式
            Console.ReadKey();
        }



    }
}
