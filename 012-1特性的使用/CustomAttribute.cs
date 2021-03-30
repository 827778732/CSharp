using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012_1特性的使用
{
    /// <summary>
    /// 自定义特性
    /// </summary>    
    /// 修饰特性的特性//表示此特性对谁修饰 //表示是否可以多重修饰(一般不可以false) //表示特性可不可以被继承
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]  //当前为默认值


    public class CustomAttribute : Attribute
    {
        public CustomAttribute() { }
        public CustomAttribute(int id) { }
        public string Description { get; set; }
        public string Remark = null;
        public void Show()
        {
            Console.WriteLine($"This is{nameof(CustomAttribute)}");
        }
        //委托 事件等等
    }
}
