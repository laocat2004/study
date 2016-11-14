using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Castle.AOP.Command
{
    public class CommandInterceptor : IInterceptor
    {
        private readonly ICommandPortal portal;
        private readonly string serviceKey;

        public CommandInterceptor(ICommandPortal portal,
            string serviceKey)
        {
            this.portal = portal;
            this.serviceKey = serviceKey;
        }

        //容器内接口实现对象的Key值   
        public string ServiceKey
        {
            get { return serviceKey; }
        }

        //方法调用门户   
        public ICommandPortal Portal
        {
            get { return portal; }
        }

        public void Intercept(IInvocation invocation)
        {
            List<Type> paramTypes = new List<Type>();

            foreach (ParameterInfo paramInfo in
                invocation.Method.GetParameters())
                paramTypes.Add(paramInfo.ParameterType);


            //生成Request对象并调用Portal的Invoke方法   
            Request request = new Request(
                ServiceKey,
                invocation.Method.Name,
                paramTypes.ToArray(),
                invocation.Arguments);


            Response response = Portal.Invoke(request);


            //如果方法顺利执行，则填充返回值，否则触发异常   

            if (response.ReturnValue is Exception)
                throw (Exception)response.ReturnValue;

            invocation.ReturnValue = response.ReturnValue;
        }
    }
}
