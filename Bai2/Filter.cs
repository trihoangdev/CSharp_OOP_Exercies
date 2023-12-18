using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace L71e2
{
    internal class Filter : IFilter
    {
        //kiểm tra định dạng ngày tháng năm sinh
        public bool IsValidBirthDate(string birthDate)
        {
            var pattern = @"\d{4}/\d{2}/\d{2}";
            var regex = new Regex(pattern);
            return regex.IsMatch(birthDate);
        }
        //kiểm tra định dạng Email
        public bool IsValidEmail(string email)
        {
            var pattern = @"^[a-z0-9_]+[a-z0-9.-_]+@+[a-z0-9]+.[a-z]{2,4}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
        //kiểm tra định dạng SĐT
        public bool IsValidPhone(string phone)
        {
            var pattern = @"0(3|8|9)\d{8}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(phone);
        }
        //Kiểm tra định dạng mã sinh viên
        public bool IsValidStudentId(string studentId)
        {
            var pattern = @"B\d{2}[a-z]{4}\d{3}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(studentId);
        }
        //kiểm tra định dạng họ tên sinh viên
        public bool IsValidStudentName(string name)
        {
            var pattern = @"[\p{L} ]{2,40}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(name);
        }
    }
}
