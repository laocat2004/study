using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DesignPartern.Observer
{
    /// <summary>
    /// 通知接口
    /// </summary>
    public interface INotify
    {
        void Notify(string accountName);
    }
}
