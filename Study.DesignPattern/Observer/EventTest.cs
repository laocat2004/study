using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DesignPartern.Observer
{
    public class EventTest
    {
        public static void Test()
        {
            AccountEvent he = new AccountEvent(10000,"小何");
            Email email = new Email();
            Sms sms = new Sms();
            he.Notify += email.SendEmail;
            he.Notify += sms.SendSms;
            he.Update(1000);
            he.Update(4000);
            Console.ReadLine();
        }
    }
}
