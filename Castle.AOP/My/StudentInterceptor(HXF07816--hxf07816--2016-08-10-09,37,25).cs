/*======================================================================
 Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 所属项目：Castle.AOP.My
 创 建 人：hxfsp
 创建日期：2016/8/3 22:47:52
 用    途：
========================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Castle.DynamicProxy;

namespace Castle.AOP.My
{
    public class StudentInterceptor : IInterceptor
    {
        void IInterceptor.Intercept(IInvocation invocation)
        {
            Console.WriteLine("当前方法 before" + invocation.Method.Name);
            //string signature = string.Empty;
            //foreach (ParameterInfo info in invocation.Method.GetParameters())
            //{
            //    string paramSignature =
            //        string.Format("{0} {1}",
            //            info.ParameterType.Name,
            //            info.Name);

            //    if (string.IsNullOrEmpty(signature))
            //        signature = paramSignature;
            //    else signature = signature + "," + paramSignature;
            //}

            ////输出方法签名   
            //Console.WriteLine("Method Signature:{0} ({1})",
            //    invocation.Method.ReturnType.Name,
            //    signature);

            ////直接设置返回值为函数名称   
            //invocation.ReturnValue = invocation.Method.Name;
            
            invocation.Proceed();
            Console.WriteLine("当前方法 after" + invocation.Method.Name);
        }

    }
}