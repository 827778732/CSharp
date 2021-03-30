using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _012_1特性的使用.Extension
{
    /// <summary>
    /// 验证扩展
    /// </summary>
    public static class ValidateExtension
    {
        public static bool Vailidate(this object oObject)
        {
            Type type = oObject.GetType();
            //遍历所以属性找属性特性
            foreach (var prop in type.GetProperties())
            {
                //一个属性字段可能有多个特性
                object[] attributrArray = prop.GetCustomAttributes(typeof(AbstractValidateAttribute), true);
                //遍历一个属性字段的所以特性
                foreach (AbstractValidateAttribute attribute in attributrArray)
                {
                    //检查其正确性
                    if (!attribute.Vailidate(prop.GetValue(oObject)))
                    {
                        return false;
                    }

                }

                ////若属性有LongAttribute则检查这个字段是否合法
                //if (prop.IsDefined(typeof(LongAttribute), true))
                //{
                //   LongAttribute attribute= (LongAttribute)prop.GetCustomAttribute(typeof(LongAttribute), true);
                //    if (!attribute.Vailidate(prop.GetValue(oObject)))
                //    {
                //        return false;
                //    }
                //}
                ////若属性有LengAttribute则检查这个字段是否合法
                //if (prop.IsDefined(typeof(LengAttribute), true))
                //{
                //    LengAttribute attribute = (LengAttribute)prop.GetCustomAttribute(typeof(LengAttribute), true);
                //    if (!attribute.Vailidate(prop.GetValue(oObject)))
                //    {
                //        return false;
                //    }
                //}




            }
            return true;
        }

    }



    /// <summary>
    /// 下面两类有共同部分 提取抽象
    /// </summary>
    public abstract class AbstractValidateAttribute:Attribute
    {
        public abstract bool Vailidate(object value);
    }







    /// <summary>
    /// 检查QQ长度
    /// </summary>
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Field)]//表示只能修饰字段或者属性
    public class LongAttribute: AbstractValidateAttribute
    {

        private long _Min = 0;
        private long _Max = 0;

        public LongAttribute(long min, long max)
        {
            this._Max = max;
            this._Min = min;
        }

        public override bool Vailidate(object value)
        {
            //不为空 也不为空白字符组成(\t\n,空格,null)
            if (value != null && string.IsNullOrWhiteSpace(value.ToString()))
            {
                //转换成功转换的值赋值给lResult
                if (long.TryParse(value.ToString(), out long lResult))
                {
                    if (lResult > this._Min && lResult < this._Max)
                    {
                        return true;
                    }
                }
            
            }
            return false;
           
        }

    }


    /// <summary>
    /// 检查姓名长度
    /// </summary>
    public class LengAttribute : AbstractValidateAttribute
    {
        private long _Min = 0;
        private long _Max = 0;

        public LengAttribute(long min, long max)
        {
            this._Max = max;
            this._Min = min;
        }


        public override bool Vailidate(object value)
        {
            //不为空 也不为空白字符组成(\t\n,空格,null)
            if (value != null && string.IsNullOrWhiteSpace(value.ToString()))
            {
                int length = value.ToString().Length;
                if (length > _Min && length < _Max)
                {
                    return true;
                }

            }
            return false;

        }

    }


















}
