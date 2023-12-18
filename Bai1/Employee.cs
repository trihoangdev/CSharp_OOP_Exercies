using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L71e1
{
    internal class Employee : BaseEmployee
    {
        //các constructor
        public Employee() { }

        public Employee(string fullName, string email, string phoneNumber, string role,
            long salary, int workingDay = 0) : base(fullName, email, phoneNumber, role, salary, workingDay)
        {
        }

        public override long CalculateSalary()
        {
            var calculateSalary = (long)Salary * WorkingDay / 22;
            var bonus = (long)(WorkingDay >= 22 ? calculateSalary * 0.2 : 0);
            ReceivedSalary = calculateSalary + bonus;
            return calculateSalary;
        }

        public override void CheckIn(string time)
        {
            Console.WriteLine($"Nhân viên đi làm lúc {time}");
        }
        public override void CheckOut(string time)
        {
            Console.WriteLine($"Nhân viên ra về lúc {time}");
        }
    }
}
