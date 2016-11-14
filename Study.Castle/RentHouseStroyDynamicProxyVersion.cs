using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Study.Castle
{
    class RentHouseStroyDynamicProxyVersion
    {
        static void Main(string[] args)
        {
            Console.WriteLine("房东委托中介帮其出租房屋！");
            Landlord proxyLandlord = CreateLandlordProxy();
            Console.WriteLine("中介成功出租房屋");
            proxyLandlord.RentHouse();
        }

        private static Landlord CreateLandlordProxy()
        {
            ProxyGenerator proxyGenerator = new ProxyGenerator();
            Landlord proyLandlord = proxyGenerator.CreateClassProxy<Landlord>(new IntermediaryIntercetor());
            return proyLandlord;
        }
    }
}
