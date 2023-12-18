using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L71e1
{
    internal class Director : Employee
    {
        public DateTime ReceivedDate { get; set; }      //ngày nhận chức
        public float BonusRate { get; set; }            //phần trăm tiền thưởng
        public long ResponsibilityAmount { get; set; }  //tiền trách nhiệm
        public long Profit { get; set; }                 //doanh thu trong tháng
        public Director(string fullName, string email, string phoneNumber,
            string role, long salary, int workingDay, DateTime startTime, float bonusRate, long profit)
            : base(fullName, email, phoneNumber, role, salary, workingDay)
        {
            ReceivedDate = startTime;
            BonusRate = bonusRate;
            Profit = profit;
        }
        public override long CalculateSalary()
        {
            var baseSalary = base.CalculateSalary();
            ResponsibilityAmount = (long)(0.15 * baseSalary);
            ReceivedSalary = baseSalary + ResponsibilityAmount + (long)(BonusRate * baseSalary);
            return ReceivedSalary;
        }
    }
}
