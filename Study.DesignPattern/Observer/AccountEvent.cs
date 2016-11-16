using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DesignPartern.Observer
{
    public delegate void NotifyEventHandler(object sender, AccountEventArgs e);
    /// <summary>
    /// 基于事件来写观察者模式
    /// </summary>
    public class AccountEvent
    {
        public event NotifyEventHandler Notify;
        public string accountName = string.Empty;
        public decimal accountmoney = 0;
        public readonly string bankName = "招商银行";
        public AccountEvent(decimal money, string name)
        {
            this.accountName = name;
            this.accountmoney = money;
        }
        public void Update(decimal updateMoney)
        {
            if (Notify != null)
            {
                accountmoney -= updateMoney;
                if (updateMoney >= 1000)
                {
                    Notify(this, new AccountEventArgs(updateMoney));
                }
            }
        }
    }

    public class Email
    {
        public void SendEmail(object sender, AccountEventArgs e)
        {
            AccountEvent acount = (AccountEvent)sender;
            Console.WriteLine("邮件提醒您{0}先生，您账户发生取钱：{1}，现在余额：{2}。【{3}】", 
                acount.accountName, e.updatemoney, acount.accountmoney, acount.bankName);
        }
    }

    public class Sms
    {
        public void SendSms(object sender, AccountEventArgs e)
        {
            AccountEvent acount = (AccountEvent)sender;
            Console.WriteLine("短信提醒您{0}先生，您账户发生取钱：{1}，现在余额：{2}。【{3}】",
                acount.accountName, e.updatemoney, acount.accountmoney, acount.bankName);
        }
    }

    public class AccountEventArgs : EventArgs
    {
        public decimal updatemoney;

        public AccountEventArgs(decimal updatemoney)
        {
            this.updatemoney = updatemoney;
        }
    }
}
