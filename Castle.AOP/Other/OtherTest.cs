/*======================================================================
 Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 所属项目：Castle.AOP.Other
 创 建 人：hxfsp
 创建日期：2016/8/3 22:03:17
 用    途：
========================================================================*/
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.DynamicProxy;

namespace Castle.AOP.Other
{
    public class OtherTest
    {
        public static void Test1()
        {
            ProxyGenerator generator = new ProxyGenerator();
            CallingLogInterceptor interceptor = new CallingLogInterceptor();
            SimpleSamepleEntity entity = generator.CreateClassProxy<SimpleSamepleEntity>(interceptor);
            entity.Name = "Richie";
            entity.Age = 50;
            Console.WriteLine("The entity is: " + entity);
            Console.WriteLine("Type of the entity: " + entity.GetType().FullName);
            Console.ReadKey();
        }

        public static void Test2()
        {
            ProxyGenerator generator = new ProxyGenerator();
            SimpleSamepleEntity entity = generator.CreateClassProxy<SimpleSamepleEntity>(
                new SimpleLogInterceptor(),
                new CallingLogInterceptor());
            entity.Name = "Richie";
            entity.Age = 50;
            Console.WriteLine("The entity is: " + entity);
            Console.WriteLine("Type of the entity: " + entity.GetType().FullName);
            Console.ReadKey();
        }

        public static void Test3()
        {
            ProxyGenerator generator = new ProxyGenerator();
            var options = new ProxyGenerationOptions(new InterceptorFilter()) { Selector = new InterceptorSelector() };
            SimpleSamepleEntity entity = generator.CreateClassProxy<SimpleSamepleEntity>(
                options,
                new SimpleLogInterceptor(), new CallingLogInterceptor());
            entity.Name = "Richie";
            entity.Age = 50;
            Console.WriteLine("The entity is: " + entity);
            Console.WriteLine("Type of the entity: " + entity.GetType().FullName);
            Console.ReadKey();
        }
    }
}