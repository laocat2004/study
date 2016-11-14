using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DesignPartern.Observer
{
    public delegate void NotifyEventHandler(string name);
    public class AccountEvent
    {
        public event NotifyEventHandler NotifyHandler;
        private string accountName = string.Empty;
        public AccountEvent(string accountName)
        {
            this.accountName = accountName;
        }
        public void Notify()
        {
            NotifyHandler(accountName);
        }
    }
}
