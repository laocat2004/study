/*======================================================================
 Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 所属项目：Study.DesignPartern.Observer
 创 建 人：hxfsp
 创建日期：2016/10/27 23:16:06
 用    途：
========================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study.DesignPartern.Observer
{
    public class EmailNotify : INotify
    {
        public void Notify(string accountName)
        {
            Console.WriteLine(accountName + "您好，邮件提醒您，您的账户正在发生交易操作");
        }

        public void NotifyEmail(string accountName)
        {
            Console.WriteLine(accountName + "您好，邮件提醒您，您的账户正在发生交易操作【委托方式】");
        }

        public void NotifyEmailA(EventArgs args)
        {
            Console.WriteLine( "您好，邮件提醒您，您的账户正在发生交易操作【委托方式】");

        }
    }
}