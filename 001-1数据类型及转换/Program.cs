using System;

namespace _001_1数据类型及转换
{
    //类型
    //1.整型 int short byte
    //2.浮点型 float double decimal(精度高用于货币计算)
    //3.可空数据类型如  int? a = null, b=20, c=30;   
    //4.var隐式类型, var只能是局部变量/隐式类型必须初始化 初始化完成则类型就定好 
    //??用于合并空类型并且遇到第一个空结束    int? d = a ?? null ?? b ?? c;  遇到b结束
    class Program
    {
        static void Main(string[] args)
        {
            //ToString类型转换  类型转换为字符串型
            int a = 50;
            a.ToString();
            //Parse类型转换  注意:字符串的类型与转换类型相同   
            int b = int.Parse("35");

            //这两个方法的最大不同是它们对 null 值的处理方法： 
            //Convert.ToInt32(null) 会返回 0 而不会产生任何异常，但 int.Parse(null) 则会产生异常。

            //a.Convert.ToInt32(double value) 如果 value 为两个整数中间的数字，则返回二者中的偶数；
            //即 3.5 转换为 4，4.5 转换为 4，而 5.5 转换为 6。不过 4.6 可以转换为 5，4.4 转换为 4 。
            //b. int.Parse("4.5") 直接报错: "输入字符串的格式不正确"。
            //c. int(4.6) = 4 Int 转化其他数值类型为 Int 时没有四舍五入，强制转换。


            //对被转换类型的区别 int.Parse 是转换 String 为 int, Convert.ToInt32 是转换继承自 Object 的对象为 int 的(可以有很多其它类型的数据)。
            //你得到一个 object 对象,你想把它转换为 int,用int.Parse 就不可以,要用 Convert.ToInt32。

            //Convert类型转换   精度高转精度低会自动四舍五入    反之则位数不变
            float f = 3.5f;
            double d = Convert.ToDouble(f);//低转高不变3.5d
            int c = Convert.ToInt32(f);//高转低四舍五入4
            //由于double比decimal大   整数位只有一位的时候double类型第15位小数四舍五入    每多一位整数小数位就减2
            decimal m = Convert.ToDecimal(1.999999999999999);//2m






            //隐式类型定义时必须赋值
            var v = 5;
            var s = "ss";



            //1）对于转换对象，Convert.ToInt32() 可以为多种类型（例出数字类型外 bool，DateTime 等），
            //int.TryParse()和 int.Parse()只能是整型字符串类型（即各种整型 ToString() 之后的形式，不能为浮点型，
            //否则 int.Parse() 就会出现输入的字符串格式不正确的错误，int.TryParse() 也会返回 false，输出参数为 0 ，(int)只能是数字类型（例 float,int, uint等）；
           
            //2）对于空值 NULL，从运行报错的角度讲，(int)强制转换和 int.Parse() 都不能接受 NULL；
            //Convert.ToInt32() 其实是在转换前先做了一个判断，参数如果为 NULL，则直接返回 0，否则就调用 int.Parse() 进行转换，
            //int.TryParse() 其实是对 int.Parse() 做了一个异常处理，如果出现异常则返回 false，并且将输出参数返回 0；
           
            //3）针对于浮点型的取舍问题，浮点型只有 Convert.ToInt32() 和(int) 能进行转换，但是也是进行取舍了的，
            //Convert.ToInt32() 采取的取舍是进行四舍五入，而(int) 则是截取浮点型的整数部分，忽略小数部分，
            //例如 Convert.ToInt32(1.499d) 和(int)1.499d 都返回 1，Convert.ToInt32(1.5d) 返回 2，而(int)1.5d 还是返回 1；
           
            //4）关于溢出，将大的数据类型转换为小的数据类型时 Convert.ToInt32() 和 int.Parse() 都会报溢出错误，
            //值对于 Int32 太大或太小，而(int) 不报错，但是返回值为 - 1。
            
            
            //如此可见，我们在进行数据转换前选择转换方法要谨慎，如果是数字类型可以考虑直接用(int)强制转换，
            //如果是整型字符串类型的，考虑用 int.Parse() 进行转换，如果不是这两种类型，再考虑用 Convert.ToInt32() 进行转换。




            Console.ReadKey();

        }
    }
}
