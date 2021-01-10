using System;

namespace _001_2值类型和引用类型及转换
{
    //值类型直接传值      引用类型传递地址传入到函数中可以修改地址指向的内容
    //值类型通过装箱操作变成引用类型
    //引用类型如  string等类型

    class Program
    {
        static void Main(string[] args)
        {
            /*值类型和引用类型的区别*/
            int i = 100;//声明值类型变量
            Student s = new Student(100);//声明并构造引用类型变量
            //传递值和地址
            Value.SetValue(i);
            Value.SetValue(s);
            Console.WriteLine(i);
            Console.WriteLine(s.Age);//s.Age=200



            /*装箱与拆箱操作*/
            int value = 100;
            object obj = value; //将value装箱 值类型变成引用类型(object)
            int b = (int)obj;  //通过强转将object类型拆箱使用
            Console.WriteLine(obj);







            Console.ReadKey();
        }
    }

    class Value
    {
        public static void SetValue(int n)
        {
            n *= 2;
        }
        public static void SetValue(Student s)
        {
            s.Age *= 2;
        }
    }

    class Student
    {
        public int Age { get; set; }
        public Student(int age)
        {
            this.Age = age;
        }
    }







}
