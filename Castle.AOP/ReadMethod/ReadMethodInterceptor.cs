using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Castle.AOP
{
    public class ReadMethodInterceptor : IInterceptor
    {
        void IInterceptor.Intercept(IInvocation invocation)
        {
           
            Console.WriteLine("当前方法"+ invocation.Method.Name);
            string signature = string.Empty;
            foreach (ParameterInfo info in invocation.Method.GetParameters())
            {
                string paramSignature =
                   string.Format("{0} {1}",
                                 info.ParameterType.Name,
                                 info.Name);

                if (string.IsNullOrEmpty(signature))
                    signature = paramSignature;
                else signature = signature + "," + paramSignature;
            }

            //输出方法签名   
            Console.WriteLine("Method Signature:{0} ({1})",
                invocation.Method.ReturnType.Name,
                signature);

            //直接设置返回值为函数名称   
            invocation.ReturnValue = invocation.Method.Name;
        }
    }
}
