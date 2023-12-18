using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L71e2
{
    //interface mô tả các regular expression cần kiểm tra đầu vào
    internal interface IFilter
    {
        bool IsValidStudentId(string studentId);        //kiểm tra mã sinh viên có đúng định dạng không
        bool IsValidStudentName(string studentName);    //kiểm tra tên sinh viên có đúng định dạng không
        bool IsValidBirthDate(string birthDate);        //kiểm tra ngày sinh có đúng định dạng không
        bool IsValidEmail(string email);                //kiểm tra email có đúng định dạng không
        bool IsValidPhone(string phone);                //Kiểm tra SĐT có đúng định dạng không
    }
}
