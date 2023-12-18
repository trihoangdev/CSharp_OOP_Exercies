using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L71e2
{
    //Lớp mô tả thông tin môn học
    internal class Subject
    {
        private static int autoId = 11001;
        public int SubjectId { get; set; }       //mã môn
        public string SubjectName { get; set; }     //tên môn
        public int Credit { get; set; }             //số tín chỉ
        public int NumOfLesson { get; set; }        //số tiết học
        public Subject()
        {
            SubjectId = autoId++;
        }
        public Subject(string name, int credit, int numOfLesson) : this()
        {
            SubjectName = name;
            Credit = credit;
            NumOfLesson = numOfLesson;
        }

        public override bool Equals(object obj) //2 môn học là 1 nếu trùng mã MH
        {
            return obj is Subject subject && SubjectId == subject.SubjectId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
