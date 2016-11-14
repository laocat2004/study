using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle.AOP.Command
{
    [Serializable]
    public class Request
    {
        private string serviceKey;
        private string commandName;
        private Type[] paramTypes;
        private object[] arguments;

        /// <summary>   
        /// 容器中对象的Key值（标识）   
        /// </summary>   
        public string ServiceKey
        {
            get { return serviceKey; }
            set { serviceKey = value; }
        }

        /// <summary>   
        /// 需要调用的方法名称   
        /// </summary>   
        public string CommandName
        {
            get { return commandName; }
            set { commandName = value; }
        }

        /// <summary>   
        /// 向调用的方法传递的参数   
        /// </summary>   
        public object[] Arguments
        {
            get { return arguments; }
            set { arguments = value; }
        }

        /// <summary>   
        /// 调用方法的参数类型，通过这个属性来精确匹配一些有重载的函数   
        /// </summary>   
        public Type[] ParamTypes
        {
            get { return paramTypes; }
            set { paramTypes = value; }
        }

        public Request()
        {

        }


        public Request(string serviceKey, string commandName,
            Type[] paramTypes, object[] arguments)
        {
            this.serviceKey = serviceKey;
            this.commandName = commandName;
            this.paramTypes = paramTypes;
            this.arguments = arguments;
        }
    }
}
