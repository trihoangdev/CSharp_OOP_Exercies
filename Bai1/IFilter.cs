using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L71e1
{
    internal interface IFilter
    {
        bool IsNameValid(string name);
        bool IsEmailValid(string email);
        bool IsPhonenumberValid(string phonenumber);
    }
}
