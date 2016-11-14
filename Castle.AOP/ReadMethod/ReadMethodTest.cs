using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Castle.AOP.ReadMethod
{
    public class ReadMethodTest
    {
        public static void Test()
        {
            ProxyGenerator generator = new ProxyGenerator();

            //采用默认的基类(Object)   
            IPerson person =
                generator.CreateInterfaceProxyWithoutTarget<IPerson>
                          (new ReadMethodInterceptor());

            DisplayMessage(person);

            ProxyGenerator proxyGenerator = new ProxyGenerator();
            ProxyGenerationOptions options = new ProxyGenerationOptions();
            //改变接口对象的基类为MarshalByRefObject   
            options.BaseTypeForInterfaceProxy = typeof(MarshalByRefObject);

            Console.WriteLine();
            Console.WriteLine("=====================================");

            IPerson person1 =
                (IPerson)proxyGenerator.CreateInterfaceProxyWithoutTarget(
                              typeof(IPerson),
                              null, options,
                              new ReadMethodInterceptor());

            DisplayMessage(person1);

            Console.ReadLine();
        }

        private static void DisplayMessage(IPerson person)
        {
            Console.WriteLine("Current BaseType:{0}", person.GetType().BaseType);
            Console.WriteLine();

            person.SayHello();
            Console.WriteLine();

            person.SayName("Roger");
            Console.WriteLine();

            Console.WriteLine(
                "Return Value:{0}",
                person.GotoSchool("华师附小", "三年级", "三班"));
        }
    }
}
