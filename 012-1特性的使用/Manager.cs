using _012_1特性的使用.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _012_1特性的使用
{
    public class Manager
    {
        //特性在反射的使用
        public static void Show(Student student)
        {
            Type type = typeof(Student); //或者student.GetType();
           
            
            
            //在student里找特性   若存在则构造特性对象
            if (type.IsDefined(typeof(CustomAttribute), true))
            {
                //object oAttribute = type.GetCustomAttribute(typeof(CustomAttribute)); //构造实例
                CustomAttribute attribute = (CustomAttribute)type.GetCustomAttribute(typeof(CustomAttribute), true);//构造实例
                Console.WriteLine($"{attribute.Description}_{attribute.Remark}");
                attribute.Show();//这时候特性方法才能生效
            }
           


            //在student字段上在找特性 若存在则构造特性对象
            PropertyInfo property = type.GetProperty("Id");//找到id字段
            if (property.IsDefined(typeof(CustomAttribute), true))//在id字段找特性
            {
                CustomAttribute attribute = (CustomAttribute)property.GetCustomAttribute(typeof(CustomAttribute), true);//构造实例
                Console.WriteLine($"{attribute.Description}_{attribute.Remark}");
                attribute.Show();//这时候特性方法才能生效
            }
            
            
            
            //在student的方法上找特性 若存在则构造特性对象
            MethodInfo method = type.GetMethod("Answer");//找到Answer方法
            if (method.IsDefined(typeof(CustomAttribute), true))//在Answer方法找特性
            {
                CustomAttribute attribute = (CustomAttribute)method.GetCustomAttribute(typeof(CustomAttribute), true);//构造实例
                Console.WriteLine($"{attribute.Description}_{attribute.Remark}");
                attribute.Show();//这时候特性方法才能生效
            }



            //在Answer方法第一个参数找特性
            ParameterInfo parameterInfo = method.GetParameters()[0];
            if (parameterInfo.IsDefined(typeof(CustomAttribute), true))
            {
                CustomAttribute attribute = (CustomAttribute)parameterInfo.GetCustomAttribute(typeof(CustomAttribute), true);//构造实例
                Console.WriteLine($"{attribute.Description}_{attribute.Remark}");
                attribute.Show();//这时候特性方法才能生效
            }



            //在Answer方法的返回值找特性
            ParameterInfo returnParameter = method.ReturnParameter;
            if (returnParameter.IsDefined(typeof(CustomAttribute), true))
            {
                CustomAttribute attribute = (CustomAttribute)returnParameter.GetCustomAttribute(typeof(CustomAttribute), true);//构造实例
                Console.WriteLine($"{attribute.Description}_{attribute.Remark}");
                attribute.Show();//这时候特性方法才能生效
            }


            //做数据检查(可以写在数据库保存方法)
            //if (student.QQ > 10001 && student.QQ < 9999999999)
            //{ 

            //}
            //else
            //{

            //}
            //
            //主动调用通过特性实现的扩展方法 (使用反射)     检查数据是否合法
            student.Vailidate();

            student.Study();
            string result = student.Answer("Enven");
        }
    }
}
