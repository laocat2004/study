    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle.AOP.Other
{
    public class SimpleSamepleEntity
    {
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public override string ToString()
        {
            return string.Format("{{ Name: \"{0}\", Age: {1} }}", this.Name, this.Age);
        }
    }
}
