using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Castle.AOP.SimleInterceptor
{
    public class SimpleTest
    {
        public static void Test()
        {
            ProxyGenerator generator = new ProxyGenerator();
            SimpleInterceptor interceptor = new SimpleInterceptor();
            Person person = generator.CreateClassProxy<Person>(interceptor);
            
            person.SayName("HXF");
            person.SayHello();
            person.SayOther();
            Console.ReadLine();
        }
    }
}
