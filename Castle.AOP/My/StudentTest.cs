/*======================================================================
 Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 所属项目：Castle.AOP.My
 创 建 人：hxfsp
 创建日期：2016/8/3 22:49:33
 用    途：
========================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using Castle.DynamicProxy;

namespace Castle.AOP.My
{
    public class StudentTest
    {
        public static void Test()
        {
            ProxyGenerator generator = new ProxyGenerator();
            StudentInterceptor interceptor = new StudentInterceptor();
            Student stu = new Student();
            stu = generator.CreateClassProxy<Student>(interceptor);
            //IStudent stu =generator.CreateInterfaceProxyWithoutTarget<IStudent>(interceptor);
            //generator.CreateInterfaceProxyWithTarget<Student>(stu, interceptor);
            //IStudent Istu=generator.CreateInterfaceProxyWithTargetInterface<IStudent>(stu, interceptor);
            string ss=stu.Say("HXF","我在哪里");
            Console.WriteLine(ss);
            Console.ReadLine();
        }

        public static void Test2()
        {
            var builder = new ContainerBuilder();
            //builder.RegisterType<Teacher>().EnableClassInterceptors();
            builder.RegisterType<Teacher>().EnableClassInterceptors().InterceptedBy(typeof(TeacherInterceptor));
            builder.RegisterType<TeacherInterceptor>();
            var teacher=builder.Build().Resolve<Teacher>();
            //var teacher = new Teacher();
            teacher.Add();
        }
    }
}