using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Castle
{
    class RentHouseStoryGeneralProxyVersion
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("房东委托中介帮其出租房屋！");
            ILandlordible landlord = new Intermediary(new Landlord());
            Console.WriteLine("中介成功出租房屋");
            landlord.RentHouse();
        }
    }
}
