using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study.Resposity;

namespace Study.Autofac.ThreeIOCType
{
    public interface IProductService: IDependency
    {
        string GetProductReso();
    }
}
