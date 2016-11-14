using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle.AOP
{
    public class Person
    {
        public virtual void SayHello()
        {
            Console.WriteLine("您好！");
        }

        public virtual void SayName(string pHometown)
        {
            Console.WriteLine("我是天涯人，我来自：{0}。", pHometown);
        }

        public void SayOther()
        {
            Console.WriteLine("是的，我是中国人。");
        }

    }
}
