using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DesignPartern.Observer
{
    public delegate void UpdateEventHandler(string accountName);
    /// <summary>
    /// 观察者模式基于委托来实现
    /// </summary>
    public class AccountDetegate
    {
        public UpdateEventHandler updateEventHandler;
        private string accountName = string.Empty;
        public AccountDetegate(string accountName)
        {
            this.accountName = accountName;
        }
        public void Notify()
        {
            updateEventHandler(accountName);
        }
    }
}
