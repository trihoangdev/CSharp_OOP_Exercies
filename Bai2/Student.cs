using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L71e2
{
    //Lớp mô tả thông tin Sinh viên
    class Student
    {
        public string StudentId { get; set; }
        public FullName FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public String Major { get; set; }
        public Student(string id, string fullName, DateTime dateOfBirth,
            string email, string phoneNumber, string major)
        {
            StudentId = id;
            FullName = new FullName(fullName);
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            Major = major;
        }

        public override bool Equals(object obj) //hai sinh viên là 1 nếu trùng mã SV
        {
            return obj is Student student && StudentId == student.StudentId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
