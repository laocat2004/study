/*======================================================================
 Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 所属项目：Castle.AOP.My
 创 建 人：hxfsp
 创建日期：2016/8/3 22:47:06
 用    途：
========================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Extras.DynamicProxy2;

namespace Castle.AOP.My
{
    //[Intercept(typeof(StudentInterceptor))]
    public class Student:IStudent
    {
        /// <summary>
        /// 方法被拦截必须是虚方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public  virtual  string Say(string name,string text)
        {
            Console.WriteLine("Say "+name+","+text);
            return "Say " + name + "," + text;
        }

        public virtual void SayHello()
        {
            Console.WriteLine("Heelo");
        }
    }
}