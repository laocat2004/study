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
        #region 应用
        private static Dictionary<int, FunEventHandler> dic = null;
        public TestDetegate()
        {
            dic.Add(1, Method1);
            dic.Add(2, Method2);
        }

        //private static FunEventHandler funEvent;
        #endregion
        public static void Test()
        {
            FunEventHandler funEvent = new FunEventHandler(Method1);
            //funEvent += Method1;
            funEvent += Method2;
            funEvent(3, 4);
            dic[1](1, 2);
            Console.ReadLine();
        }
        public static void Method1(int a, int b)
        {
            Console.WriteLine("相减：" + (a - b));
        }
        public static void Method2(int a, int b)
        {
            Console.WriteLine("相加：" + (a + b));
        }

        #region Fun委托 有返回值的委托，输入参数可以多个
        public void FunTest()
        {
            Func<int> fun1 = new Func<int>(Fun1);
            Func<string, int> fun2 = Fun2;
        }

        public int Fun1()
        {
            return 1;
        }

        public int Fun2(string str)
        {
            return 1;
        }

        #endregion

        #region Action委托 没有返回值的委托,输入参数可以有多个
        public void ActionTest()
        {
            Action ac1 = Action1;
            Action<string, string> ac2 = Action2;
        }

        public void Action1()
        {
        }

        public void Action2(string str1, string str2)
        {

        }

        public void Action3()
        {

        }

        #endregion

        #region Predicate委托 返回值为bool类型的委托，输入参数只可以有一个
        public void PredicateTest()
        {
            Predicate<int> pre1 = Predicate1;
            List<int> list = new List<int>() {1,2,3,4,5,6};
            list.Find(pre1);
        }

        public bool Predicate1(int str)
        {
            return str>10;
        }

        #endregion
    }

}
