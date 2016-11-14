/*======================================================================
 Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 所属项目：Study.Autofac.ThreeIOCType
 创 建 人：hxfsp
 创建日期：2016/8/9 23:47:54
 用    途：
========================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;

namespace Study.Autofac.ThreeIOCType
{
    public class ProductTest
    {
        /// <summary>
        /// 构造器注入
        /// </summary>
        /// <returns></returns>
        public static IProductService ConstructInject()
        {
            var builder = new ContainerBuilder();
            //用到的类都需要在Autofac中进行注册
            //注册ProductController
            builder.RegisterType<ProductController>();
            //注册ProductService
            //builder.RegisterType<ProductService>();
            builder.RegisterType<ProductService>().AsImplementedInterfaces();
            var container=builder.Build();
            var controller = container.Resolve<ProductController>();
            var product= controller.GetIProductService();
            return product;
        }

        /// <summary>
        /// 属性注入
        /// </summary>
        /// <returns></returns>
        public static IProductService PropertyInject()
        {
            var builder = new ContainerBuilder();
            //属性注入的方式
            builder.RegisterType<ProductController>().PropertiesAutowired();
            //注册ProductService
            builder.RegisterType<ProductService>().AsImplementedInterfaces();
            builder.RegisterType<TeacherService>().AsImplementedInterfaces();
            var container = builder.Build();
            var controller = container.Resolve<ProductController>();
            //var student = controller.GetTeacherService();
            var product =  controller.GetIProductService();;
            return product;
        }

        ////方法注入
        //public static ProductController MethodInject()
        //{
        //    var build = new ContainerBuilder();
        //    build.Register(t => { var result = new ProductController();
        //                            return result;
        //    });
        //    var container = build.Build();
        //    var controller = container.Resolve<ProductController>();
        //    return controller;
        //}
    }
}