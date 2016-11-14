using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DesignPartern.Observer
{
    public delegate void FunEventHandler(int a, int b);
    public class TestDetegate
    {
        public static void Test()
        {
            FunEventHandler funEvent = new FunEventHandler(Func1);
            funEvent += new FunEventHandler(Func2);
            funEvent(3, 4);
            Console.ReadLine();
        }
        public static void Func1(int a, int b)
        {
           Console.WriteLine("相减："+(a-b));
        }
        public static void Func2(int a, int b)
        {
            Console.WriteLine("相加：" + (a +b));
        }
    }
}
