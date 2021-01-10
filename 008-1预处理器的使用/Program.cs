#define DEBUG
#define RELEASE
#undef DEBUG
//#define	它用于定义一系列成为符号的字符。
//#undef	它用于取消定义符号。
//#if	它用于测试符号是否为真。
//#else	它用于创建复合条件指令，与 #if 一起使用。
//#elif	它用于创建复合条件指令。
//#endif	指定一个条件指令的结束。
//#line	它可以让您修改编译器的行数以及（可选地）输出错误和警告的文件名。
//#error	它允许从代码的指定位置生成一个错误。
//#warning	它允许从代码的指定位置生成一级警告。
//#region	它可以让您在使用 Visual Studio Code Editor 的大纲特性时，指定一个可展开或折叠的代码块。
//#endregion	它标识着 #region 块的结束。

using System;
namespace _008_1预处理器的使用
{

    //Debug和Release只是两个编译的选项而已，是编译器所要进行工作的一系列指令，它们只是编译指令的集合的名称。
    //Debug允许对源码进行调试，而Release则不对源码进行调试。

    //二者的详细区分：
    //Debug：Debug通常称为调试版本，通过一系列编译选项的配合，编译的结果通常包含调试信息，
    //而且不做任何优化，以为开发人员提供强大的应用程序调试能力。

    //Release：Release通常称为发布版本，是为用户使用的，一般客户不允许在发布版本上进行调试。
    //所以不保存调试信息，同时，它往往进行了各种优化，以期达到代码最小和速度最优。为用户的使用提供便利。

    class Program
    {
        static void Main(string[] args)
        {


            //1.#if #elif(相当于else if) #else #endif(#if标志语句结束) 使用
            //用于指定编译的部分
            //在Release模式下遵循有定义才为true未定义就为false
#if DEBUG

            Console.Write("debug\n"); //若定义了debug就只会执行这个

#elif RELEASE

            Console.Write("release\n");//只定义release

#else

            Console.Write("other\n");//debug和release都未定义

#endif

            //2.#region和#endregion用于折叠代码块
            #region 折叠代码片段
            Console.WriteLine(11);
            Console.WriteLine(22);
            Console.WriteLine(33);
            #endregion


            //3.#warning 和 #error
            //当编译器遇到它们时，会分别产生警告或错误。如果编译器遇到
            //#warning 指令，会给用户显示 #warning 指令后面的文本，之后编译继续进行。
            //如果编译器遇到 #error 指令，就会给用户显示后面的文本，作为一条编译错误消息，然后会立即退出编译。
            //使用这两条指令可以检查 #define 语句是不是做错了什么事，使用 #warning 语句可以提醒自己执行某个操作。

#if DEBUG && RELEASE
#error "You've defined DEBUG and RELEASE simultaneously!"//编译器遇到#error就会立即退出编译,并显示错误信息
#endif
#warning "Don't forget to remove this line before the boss tests the code!"  //编译器遇到#warning之后编译继续,并显示警告信息
            Console.WriteLine("警告之后语句仍会运行");
            Console.ReadKey();

        }
    }


    //4.#pragma warning disable/restore 警告代码        用于取消/恢复编译器显示给用户的警告
    //以下表示只对MyClass的169警告取消警告提示
#pragma warning disable 169    // 取消编号 169 的警告（字段未使用的警告）
    public class MyClass
    {
        int neverUsedField;       // 编译整个 MyClass 类时不会发出警告
    }
#pragma warning restore 169   // 恢复编号 169 的警告
    public class MyClass2
    {
        int neverUsedField;//由于恢复了169警告所以编译器给出提示信息
    }


    //5.#line
    //#line 指令可以用于改变编译器在警告和错误信息中显示的文件名和行号信息，不常用。
    //如果编写代码时，在把代码发送给编译器前，要使用某些软件包改变输入的代码，
    //就可以使用这个指令，因为这意味着编译器报告的行号或文件名与文件中的行号或编辑的文件名不匹配。
    //#line指令可以用于还原这种匹配。也可以使用语法#line default把行号还原为默认的行号：

#line 164 "Program.cs" // 在文件的第 164 行
    // Core.cs, before the intermediate
    // package mangles it.
    // later on
#line default // 恢复默认行号






    //总结:控制编译,自定义警告错误提示,取消/恢复警告提示,折叠代码,恢复默认行号
}
