using _012_1特性的使用.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012_1特性的使用
{
    /// <summary>
    /// 这里是注释,除了让人看懂这里写的是什么
    /// 对运行没什么影响
    /// </summary>
   //[Obsolete("请不要使用这个了,请使用其他代替", true)]//影响编译器运行
    [Serializable]//可以序列化和反序列化    可影响程序的运行
                  //MVC filer  ORM table key display wcf


    //[Custom]
    //[Custom()]
    //[Custom(123)]   
    //[Custom(123),Custom(123,Description ="1234")]//可以在使用时对属性字段赋值
    [Custom(123, Description = "1234", Remark = "2345")]//方法不行
    public class Student
    {
        [CustomAttribute]
        public int Id { get; set; }
        [Leng(5,10)]
        public string Name { get; set; }
        [Leng(20, 50)]
        public string Accont { get; set; }
        /// <summary>
        /// QQ号范围10001-9999999999
        /// </summary>
        [LongAttribute(10001, 9999999999)]//检查是否符合范围特性不符合特性值为false
        public long QQ { get; set; }

        [CustomAttribute]
        public void Study()
        {
            Console.WriteLine($"这里是{this.Name}跟着Eleven老师学习");
        }


        [Custom()] //给方法加特性
        [return: Custom] //给返回值加特性
        public string Answer([Custom] string name)//给参数加特性
        {
            return $"This is{name}";
        }

        
    }
}
