using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Castle.AOP.Command
{
    public class CommandPortal : ICommandPortal
    {
        public Response Invoke(Request request)
        {
            IDictionary<string, object> Items =
                ObjectContainer.Instance.Items;



            //检测容器是否包含指定的实例对象(按ServiceKey区分)   
            //如果不包含则向调用方抛回异常   
            if (!Items.ContainsKey(request.ServiceKey))
                return new Response(
                    new Exception("Invalid ServiceKey:"
                        + request.ServiceKey));


            object invokeObj = Items[request.ServiceKey];

            //设置BindingFlags标志，用于指定方法的搜索条件   
            //并通过反射找到相应的方法   

            const BindingFlags FindFlags =
                BindingFlags.FlattenHierarchy | BindingFlags.Instance |
                BindingFlags.NonPublic | BindingFlags.Public;


            Type invokeType = invokeObj.GetType();


            MethodInfo methodInfo =
                invokeType.GetMethod(
                    request.CommandName,
                    FindFlags,
                    null,
                    request.ParamTypes,
                    null);


            if (methodInfo == null)
                return new Response(
                    new Exception("Invalid MethodName:"
                        + request.CommandName));


            //调用找到的方法，如果调用发生异常，则返回异常的信息   
            try
            {
                return new Response(
                    methodInfo.Invoke(invokeObj,
                    request.Arguments));
            }
            catch (Exception ex)
            {
                return new Response(ex);
            }
        }
    }
}
