using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle.AOP.Command
{
    [Serializable]
    public class Response
    {
        private readonly object returnValue;

        /// <summary>   
        /// 方法调用的返回值   
        /// </summary>   
        public object ReturnValue
        {
            get { return returnValue; }
        }

        public Response()
        {
        }

        public Response(object returnValue)
        {
            this.returnValue = returnValue;
        }
    }
}
