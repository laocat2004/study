using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DesignPartern.Observer
{
    public class ObserverDetegeTest
    {
        public static void Test()
        {
            AccountDetegate he= new AccountDetegate("何总");
            SmsNotify sms= new SmsNotify();
            WeChatNotify wechat = new WeChatNotify();
            EmailNotify email = new EmailNotify();
            he.updateEventHandler += new UpdateEventHandler(sms.NotifySms);
            he.updateEventHandler += wechat.NotifyWeChat; ;
            he.updateEventHandler += email.NotifyEmail;
            he.Notify();
            AccountDetegate mao = new AccountDetegate("毛总");
            mao.updateEventHandler += sms.NotifySms;
            mao.updateEventHandler += wechat.NotifyWeChat;
            mao.Notify();
        }
    }
}
