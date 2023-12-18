using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L71e1
{
    internal interface IEmployee
    {
        //các hành động chung của Nhân viên
        void CheckIn(string time);
        void CheckOut(string time);
        long CalculateSalary();
    }
}
