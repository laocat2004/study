/*======================================================================
 Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 所属项目：Study.DesignPartern.Observer
 创 建 人：hxfsp
 创建日期：2016/10/27 23:04:21
 用    途：观察者模式
========================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study.DesignPartern.Observer
{
    public class AccountVistit
    {
        public List<INotify> list = new List<INotify>();
        string accountName = string.Empty;
        public AccountVistit(string accountName) {
            this.accountName = accountName;
        }
        /// <summary>
        /// 账号发生改变
        /// </summary>
        public void Change()
        {
            Console.WriteLine(accountName+"取款");
            Notify();
        }

        /// <summary>
        /// 增加通知
        /// </summary>
        /// <param name="notify"></param>
        public void AddNotify(INotify notify) {
            list.Add(notify);
        }

        /// <summary>
        ///删除通知
        /// </summary>
        /// <param name="notify"></param>
        public void DeleteNotify(INotify notify) {
            list.Remove(notify);
        }

        /// <summary>
        /// 通知
        /// </summary>
        public void Notify()
        {
            foreach (var item in list)
            {
                item.Notify(accountName);
            }
        }

    }
}