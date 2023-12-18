using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L71e1
{
    internal class Manager : Employee
    {
        public float BonusRate { get; set; }    //phần trăm tiền thưởng
        public Manager() { }

        public Manager(string fullName, string email, string phoneNumber,
            string role, long salary, int workingDay, float bonusRate) : base(fullName, email,
                phoneNumber, role, salary, workingDay)
        {
            BonusRate = bonusRate;  
        }
        public override long CalculateSalary()
        {
            var baseSalary = base.CalculateSalary();
            ReceivedSalary = baseSalary + (long)(BonusRate * baseSalary);
            return ReceivedSalary;
        }
    }
}
