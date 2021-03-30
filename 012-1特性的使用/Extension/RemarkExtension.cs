using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _012_1特性的使用.Extension
{
    /// <summary>
    /// 标识用户状态
    /// </summary>
    public enum UserState
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Remark("正常")]
        Norml = 0,//左边是字段名称  右边是数据库值    哪里描述？注释
        /// <summary>
        /// 冻结
        /// </summary>
        [Remark("冻结")]
        Frozen = 1,
        /// <summary>
        /// 删除
        /// </summary>
        [Remark("删除")]
        Deleted = 2,
    }

    //枚举项加一个描述  实体类的属性也可以Display
    //别名    映射列名     先根据特性描述的名字然后在根据实际的名字
    [AttributeUsage(AttributeTargets.Field)]
    public class RemarkAttribute : Attribute
    {
        private string _Remark = null;
        public RemarkAttribute(string remark)
        {
            this._Remark = remark;
        }
        public string GetRemark()
        {
            return this._Remark;
        }
    }

    //Remark扩展
    public static class RemarkExtension
    {
       /// <summary>
       /// 扩展方法
       /// </summary>
       /// <param name="value"></param>
       /// <returns></returns>
        public static string GetRemark(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo field = type.GetField(value.ToString());
            //在枚举中查找特性 若找到则创建特性对象使用
            if (field.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute attribute = (RemarkAttribute)field.GetCustomAttribute(typeof(RemarkAttribute), true);
                return attribute.GetRemark();
            }
            return value.ToString();
        }
        //对哪个类型扩展就在扩展方法中的参数前加this
        //public static void (this AR 参数) 表示对AR的扩展方法
        //对string 类型的扩展方法
        public static string Get(this string arr)
        {
            return arr;
        }

    }
}
