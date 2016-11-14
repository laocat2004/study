using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle.AOP.Command
{
    public interface IPerson
    {
        void SayHello(string name);
        string GetFullName(string firstName, string lastName);
    }

    public class Person : IPerson
    {
        private readonly string innerName;

        public Person(string innerName)
        {
            this.innerName = innerName;
        }

        public string InnerName
        {
            get { return innerName; }
        }

        public void SayHello(string name)
        {
            Console.WriteLine("{0} Say:Hello,{1}!", InnerName, name);
        }

        public string GetFullName(string firstName, string lastName)
        {
            return string.Format("My name is {0} {1}.", firstName, lastName);
        }
    }
}
