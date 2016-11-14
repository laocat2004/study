/*======================================================================
 Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 所属项目：Castle.AOP.Other
 创 建 人：hxfsp
 创建日期：2016/8/3 22:05:31
 用    途：
========================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Castle.DynamicProxy;

namespace Castle.AOP.Other
{
    public class InterceptorFilter : IProxyGenerationHook
    {
        public bool ShouldInterceptMethod(Type type, MethodInfo memberInfo)
        {
            return memberInfo.IsSpecialName &&
                (memberInfo.Name.StartsWith("set_") || memberInfo.Name.StartsWith("get_"));
        }
        public void NonVirtualMemberNotification(Type type, MemberInfo memberInfo)
        {
        }
        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
            throw new NotImplementedException();
        }
    }
}