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
            AccountEvent he = new AccountEvent("小何");
            SmsNotify sms = new SmsNotify();
            WeChatNotify wechat = new WeChatNotify();
            EmailNotify email = new EmailNotify();
            he.NotifyHandler += sms.NotifySms;
            he.NotifyHandler += wechat.NotifyWeChat; ;
            he.NotifyHandler += email.NotifyEmail;
            he.Notify();
        }
    }
}
