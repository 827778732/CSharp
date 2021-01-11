using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_2StringFormat使用
{

    //string.Format()用于格式化输出
    //.ToString(string Format)也可以用于格式化
    //Console.Write(string Format,object obj)进行输出格式化


    //常见形式
    //C 货币          string.Format("{0:C3}", 2)  ＄2.000
    //D 十进制        string.Format("{0:D3}", 2)  002
    //E 科学计数法    1.20E+001 	1.20E+001
    //G 常规          string.Format("{0:G}", 2)   2
    //N 用分号隔开的数字    string.Format("{0:N}", 250000)  250,000.00
    //X 十六进制     string.Format("{0:X000}", 12)   C
    //P 百分比       string.Format("{0:P1}", 0.24583) //结果为：24.6% （自动四舍五入）
    class Program
    {
        static void Main(string[] args)
        {

            //1.N分隔数字  NX      ----X代表保留小数位
            Console.WriteLine("{0:N1}", 56789);               //result: 56,789.0
            Console.WriteLine("{0:N2}", 56789);               //result: 56,789.00
            Console.WriteLine("{0:N3}", 56789);               //result: 56,789.000
            Console.WriteLine("{0:N}", 14200);                //结果为：14,200.00 （默认为小数点后面两位）
            Console.WriteLine("{0:N3}", 14200.2458);          //结果为：14,200.246 （自动四舍五入）
            //F保留小数位 FX    ----X代表保留小数位
            Console.WriteLine("{0:F}", 56789);                //result: 56789.00 (默认两位小数)
            Console.WriteLine("{0:F2}", 56789);               //result: 56789.00
            Console.WriteLine("{0:F3}", 56789);               //result: 56789.0

            //0占位可以占浮点数和整型数不够位数填0(整数位和小数位都填)     
            Console.WriteLine((567.89).ToString("0000.0000"));  //0567.8900 
            //#只能格式化浮点数类型只能做到取舍,保留几位小数或者取整     -----对整型数无效    
            Console.WriteLine((567.89).ToString("####.####")); //567.89


            //2.C格式化货币默认保留两位小数（跟系统的环境有关，中文系统默认格式化人民币，英文系统格式化美元）
            Console.WriteLine("{0:C}", 3.567);    //￥3.57
            Console.WriteLine("{0:C3}", 2.3456);  //￥2.346(自动四舍五入)


            //3.D格式化十进制数字     只多不少(补零)   注意:浮点数会抛异常
            Console.WriteLine("{0:D2}", 123);  //123
            Console.WriteLine("{0:D4}", 123);   //0123(自动补0)


            //4.格式化百分比
            Console.WriteLine("{0:P}", 0.24583); //结果为：24.58% （默认保留百分的两位小数）
            Console.WriteLine("{0:P1}", 0.24583); //结果为：24.6% （自动四舍五入）


            //5、日期格式化
            Console.WriteLine("{0:d}", System.DateTime.Now); //结果为：2009-3-20 （月份位置不是03）
            Console.WriteLine("{0:D}", System.DateTime.Now); //结果为：2009年3月20日
            Console.WriteLine("{0:f}", System.DateTime.Now); //结果为：2009年3月20日 15:37
            Console.WriteLine("{0:F}", System.DateTime.Now); //结果为：2009年3月20日 15:37:52
            Console.WriteLine("{0:g}", System.DateTime.Now); //结果为：2009-3-20 15:38
            Console.WriteLine("{0:G}", System.DateTime.Now); //结果为：2009-3-20 15:39:27
            Console.WriteLine("{0:m}", System.DateTime.Now); //结果为：3月20日
            Console.WriteLine("{0:t}", System.DateTime.Now); //结果为：15:41
            Console.WriteLine("{0:T}", System.DateTime.Now); //结果为：15:41:50


            //PS：空格占位符
            Console.WriteLine("{0,-50}","abc");//格式化成50个字符，原字符左对齐，不足则补空格
            Console.WriteLine("{0,50}","abc");//格式化成50个字符，原字符右对齐，不足则补空格


            //总结:对特定格式字符串进行格式化Format
            Console.ReadKey();
        }
    }
}
