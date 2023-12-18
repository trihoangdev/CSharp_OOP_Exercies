using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L71e1
{
    abstract class BaseEmployee : IEmployee
    {
        private static int autoId = 1000;
        public string Id { get; set; }
        public FullName FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public long Salary { get; set; }
        public int WorkingDay { get; set; }
        public long ReceivedSalary { get; set; }
        public BaseEmployee()
        {
            Id = $"EMP{autoId++}";
        }
        public BaseEmployee(string fullName, string email, string phoneNumber, 
            string role, long salary, int workingDay = 0):this()
        {
            FullName = new FullName(fullName);
            Email = email;
            PhoneNumber = phoneNumber;
            Role = role;
            Salary = salary;
            WorkingDay = workingDay;
        }

        public abstract long CalculateSalary();
        public abstract void CheckIn(string time);
        public abstract void CheckOut(string time);
    }
}
