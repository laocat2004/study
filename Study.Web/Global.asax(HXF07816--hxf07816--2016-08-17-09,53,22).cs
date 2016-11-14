using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Study.Autofac;
using Study.Resposity;
using Study.Web.Controllers;

namespace Study.Web
{
    public class MvcApplication :
    {
        protected void Application_Start()
        {
            var builder = AutoRegisterService();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //配置的方式
        private ContainerBuilder RegisterService()
        {
            var builder = new ContainerBuilder();
            //注册Controller
            builder.RegisterControllers(Assembly.Load("Study.Web")).PropertiesAutowired();
            //注册Service
            builder.RegisterAssemblyTypes(Assembly.Load("Study.Autofac"))
                .AsSelf() //注册自己
                .PropertiesAutowired()  //属性注入
                .AsImplementedInterfaces(); //接口注入
            builder.RegisterAssemblyTypes(Assembly.Load("Study.Resposity"))
                .AsSelf(); //注册自己
            return builder;
        }

        /// <summary>
        /// 自动注册
        /// </summary>
        /// <returns></returns>
        private ContainerBuilder AutoRegisterService()
        {
            //获取所有的DLL
            var assemblies = new DirectoryInfo(
                      HttpContext.Current.Server.MapPath("~/bin/"))
                .GetFiles("*.dll")
                .Select(r => Assembly.LoadFrom(r.FullName)).ToArray();
            var builder = new ContainerBuilder();
            //注册Controller
            builder.RegisterControllers(assemblies).PropertiesAutowired();
            //注册其他的层
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t=> typeof(IDependency).IsAssignableFrom(t))
                .AsSelf()
                .PropertiesAutowired()
                .AsImplementedInterfaces();
            return builder;
        }
    }
}
