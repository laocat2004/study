/*======================================================================
 Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 所属项目：Castle.AOP.My
 创 建 人：hxfsp
 创建日期：2016/8/4 23:37:18
 用    途：
========================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Extras.DynamicProxy2;

namespace Castle.AOP.My
{
    //[Intercept(typeof(TeacherInterceptor))]
    public class Teacher
    {
        public virtual void Add()
        {
            Console.WriteLine("Teacher-Add");
        }
    }
}