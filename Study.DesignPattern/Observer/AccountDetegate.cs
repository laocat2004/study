using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DesignPartern.Observer
{
    public delegate void UpdateEventHandler(string accountName);
    //public delegate void UpdateEventHandler1(object sender,EventArgs e);
    /// <summary>
    /// 观察者模式基于委托来实现
    /// </summary>
    public class AccountDetegate
    {
        public event UpdateEventHandler updateEventHandler;
        //public event UpdateEventHandler1 updateEventHandler1;
        private string accountName = string.Empty;
        public AccountDetegate(string accountName)
        {
            this.accountName = accountName;
        }
        public void Notify()
        {
            if (updateEventHandler != null)
            {
                //updateEventHandler1(new object() ,new EventArgs());
                updateEventHandler(accountName);
            }
        }


    }
}
