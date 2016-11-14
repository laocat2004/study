using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Castle.AOP.Other
{
    public class CallingLogInterceptor : IInterceptor
    {
        private int _indent = 0;
        private void PreProceed(IInvocation invocation)
        {
            Console.WriteLine("CallingLogInterceptor");
            if (this._indent > 0)
                Console.Write(" ".PadRight(this._indent * 4, ' '));
            this._indent++;
            Console.Write("Intercepting: " + invocation.Method.Name + "(");
            if (invocation.Arguments != null && invocation.Arguments.Length > 0)
                for (int i = 0; i < invocation.Arguments.Length; i++)
                {
                    if (i != 0) Console.Write(", ");
                    Console.Write(invocation.Arguments[i] == null
                        ? "null"
                        : invocation.Arguments[i].GetType() == typeof(string)
                           ? "\"" + invocation.Arguments[i].ToString() + "\""
                           : invocation.Arguments[i].ToString());
                }
            Console.WriteLine(")");
        }
        private void PostProceed(IInvocation invocation)
        {
            this._indent--;
        }
        public void Intercept(IInvocation invocation)
        {
            this.PreProceed(invocation);
            invocation.Proceed();
            this.PostProceed(invocation);
        }
    }
}
