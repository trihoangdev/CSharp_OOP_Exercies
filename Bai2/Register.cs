using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L71e2
{
    //Lớp mô tả thông tin của bảng đăng ký
    internal class Register
    {
        private static int autoId = 10000;
        public int RegisterId { get; set; }
        public Student Student { get; set; }        //sinh viên đăng ký
        public Subject Subject { get; set; }        //môn học đăng ký
        public DateTime RegisterTime { get; set; }  //thời gian đăng ký
        public Register()
        {
            RegisterId = autoId++;
        }
        public Register(Student student, Subject subject, DateTime registerTime) : this()
        {
            Student = student;
            Subject = subject;
            RegisterTime = registerTime;
        }

        public override bool Equals(object obj)
        {
            return obj is Register register &&
                EqualityComparer<Student>.Default.Equals(Student, register.Student) &&
                EqualityComparer<Subject>.Default.Equals(Subject, register.Subject);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
