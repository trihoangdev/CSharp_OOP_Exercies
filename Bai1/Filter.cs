using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace L71e1
{
    internal class Filter : IFilter
    {
        public bool IsEmailValid(string email)
        {
            var pattern = @"^[a-z0-9_]+[a-z0-9.-_]+@[a-z0-9]+\.[a-z]{2,4}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public bool IsNameValid(string name)
        {
            //tên phải có từ 2->40 ký tự
            var pattern = @"^[\p{L} ]{2,40}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(name)) return true;
            return false;
        }

        public bool IsPhonenumberValid(string phonenumber)
        {
            var pattern = @"^0(3|8|9)+\d{8}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(phonenumber);
        }
    }
}
