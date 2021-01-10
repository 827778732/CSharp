using System;

namespace _002_1枚举类型使用
{
    //Enum的访问性默认为pubilc
    //枚举类型是一种的值类型,它用于声明一组命名的常数
    //可以通过Enum类来遍历枚举类等操作

    //枚举类名建议带上 Enum 后缀，枚举成员名称需要全大写，单词间用下划线隔开。
    //说明： 枚举其实就是特殊的常量类，且构造方法被默认强制是私有。
    //正例： 枚举名字： DealStatusEnum， 成员名称： SUCCESS / UNKOWN_REASON

    //直接通过枚举名.来选择来使用
    public enum ErrorEnum : int //默认为int型  可以修改为其他整型
    {
        /// <summary>
        /// 错误代号0 错误原因...
        /// </summary>
        Error_0,     //默认第一个值为0依次递增1
        /// <summary>
        ///  错误代号1 错误原因
        /// </summary>
        Error_1,
        /// <summary>
        ///  错误代号2  错误原因
        /// </summary>
        Error_2,
        /// <summary>
        ///  错误代号404 错误原因
        /// </summary>
        Error_404 = 404,  //直接通过对枚举值赋值
        /// <summary>
        /// 错误代号405 错误原因
        /// </summary>
        Error_405,//由于前一个值为404则这个值为405
    }

    class Program
    {
        static void Main(string[] args)
        {
            //可以通过转型来输出枚举成员的值
            Console.WriteLine((int)ErrorEnum.Error_0);
            Console.WriteLine((int)ErrorEnum.Error_404);

            //遍历枚举名  用Enum类中的GetNames方法
            foreach (string str in Enum.GetNames(typeof(ErrorEnum)))
            {
                Console.WriteLine(str);
            }


            //遍历枚举值 由于枚举定义的值为int型
            foreach (int i in Enum.GetValues(typeof(ErrorEnum)))
            {
                Console.WriteLine(i);
            }




            Console.ReadKey();
        }
    }
}
