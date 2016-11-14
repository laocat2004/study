/*======================================================================
 Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 所属项目：Study.DesignPartern.Observer
 创 建 人：hxfsp
 创建日期：2016/10/27 23:11:35
 用    途：
========================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study.DesignPartern.Observer
{
    public class ObserverTest
    {
        public static void Test()
        {
            AccountVistit he = new AccountVistit("何总");
            he.AddNotify(new SmsNotify());
            he.AddNotify(new EmailNotify());
            he.Change();
            AccountVistit mao = new AccountVistit("毛总");
            mao.AddNotify(new SmsNotify());
            mao.AddNotify(new EmailNotify());
            mao.AddNotify(new WeChatNotify());
            mao.Change();
        }
    }
}