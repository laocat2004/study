using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle.AOP.Command
{
    public interface ICommandPortal
    {
        /// <summary>   
        /// 根据请求的信息来调用对象容器中相应对象的相应方法，   
        /// 并包装返回的值为一个Response   
        /// </summary>   
        Response Invoke(Request request);
    }
}
