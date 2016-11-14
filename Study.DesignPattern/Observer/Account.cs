using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DesignPartern.Observer
{
    /// <summary>
    /// 账户对象
    /// </summary>
    public class Account
    {
        /// <summary>
        /// 账户发生改变
        /// </summary>
        public void Change()
        {
            EmailNotify();
            SmsNotify();
            WeChatNotify();
        }

        private void EmailNotify(){}
        private void SmsNotify(){}
        private void WeChatNotify(){}
    }
}
