using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Study.Castle
{
    public class IntermediaryIntercetor:IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            //执行房东的逻辑
            invocation.Proceed();
            CollectIntermediaryFees();
        }

        private void CollectIntermediaryFees()
        {
            Console.WriteLine("中介收取服务费！");
        }
    }
}
