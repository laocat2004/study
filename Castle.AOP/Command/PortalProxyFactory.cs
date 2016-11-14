using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Castle.AOP.Command
{
    /// <summary>   
    /// Proxy生成工厂，根据ICommandPortal，ServiceKey   
    /// 产生一个动态的Proxy   
    /// </summary>   
    public class PortalProxyFactory
    {
        public T CreateProxy<T>(ICommandPortal commandPortal, string serviceKey) where T:class
        {
            ProxyGenerator generator = new ProxyGenerator();
            IInterceptor interceptor
                = new CommandInterceptor(commandPortal, serviceKey);

            T proxy = generator.CreateInterfaceProxyWithoutTarget<T>(interceptor);

            return proxy;
        }
    }
    }
