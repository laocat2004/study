using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle.AOP.Command
{
    public class CommandTest
    {
        public static void Test()
        {
            IDictionary<string, object> Items =
                ObjectContainer.Instance.Items;

            //初始化容器里面的对象   
            Items.Add("PersonA", new Person("PersonA"));
            Items.Add("PersonB", new Person("PersonB"));

            //初始化ICommandPortal   
            ICommandPortal commandPortal = new CommandPortal();

            //初始化ProtalProxyFactory   
            PortalProxyFactory proxyFactory = new PortalProxyFactory();

            IPerson personA = proxyFactory.CreateProxy<IPerson>(commandPortal, "PersonA");
            IPerson personB = proxyFactory.CreateProxy<IPerson>(commandPortal, "PersonB");
            IPerson personC = proxyFactory.CreateProxy<IPerson>(commandPortal, "PersonC");


            personA.SayHello("Roger");
            Console.WriteLine(personA.GetFullName("Roger", "Tong"));

            Console.WriteLine("=========================");

            personB.SayHello("Roger");
            Console.WriteLine(personB.GetFullName("Roger", "Tong"));

            Console.WriteLine("=========================");

            //由于"PersonC"在容器中不存在，所以我们测试一下是否可以抛出异常
            try
            {
                personC.SayHello("Roger");
                Console.WriteLine(personC.GetFullName("Roger", "Tong"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();
        }
    }
}
