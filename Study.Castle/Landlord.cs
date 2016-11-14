using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Castle
{
    public class Landlord : ILandlordible
    {
        public void RentHouse()
        {
            Console.WriteLine("房东收取租金！");
        }
    }
}
