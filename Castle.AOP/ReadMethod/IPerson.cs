using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle.AOP
{
    public interface IPerson
    {
        void SayHello(); 
        void SayName(string name);

        string GotoSchool(string schoolName, string grade, string classes);

        void SaySex();

        string GetSex(string sex);
    }
}
