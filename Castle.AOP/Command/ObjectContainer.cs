using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle.AOP.Command
{
    public class ObjectContainer
    {
        private readonly IDictionary<string, object> items
           = new SortedList<string, object>();

        public IDictionary<string, object> Items
        {
            get { return items; }
        }

        private ObjectContainer()
        {

        }

        /// <summary>   
        /// 单例模式   
        /// </summary>   
        public static readonly ObjectContainer
            Instance = new ObjectContainer();
    }
}
