/*======================================================================
 Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 所属项目：Castle.AOP.My
 创 建 人：hxfsp
 创建日期：2016/8/3 23:35:10
 用    途：
========================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Castle.AOP.My
{
    public interface IStudent
    {
        string Say(string name, string text);

        void SayHello();
    }
}