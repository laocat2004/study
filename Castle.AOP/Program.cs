using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.AOP.Command;
using Castle.AOP.My;
using Castle.AOP.Other;
using Castle.AOP.ReadMethod;
using Castle.AOP.SimleInterceptor;

namespace Castle.AOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleTest.Test();
            //ReadMethodTest.Test();
            //CommandTest.Test();
            //OtherTest.Test2();
            //StudentTest.Test();
            StudentTest.Test2();
            Console.ReadLine();
        }
    }
}
