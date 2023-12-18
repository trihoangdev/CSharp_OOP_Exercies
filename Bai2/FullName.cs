using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L71e2
{
    //Lớp mô tả thông tin của họ và tên để lưu trữ Họ, Tên, Đệm
    internal class FullName
    {
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public FullName(string fullName)
        {
            SetFullName(fullName);
        }

        public void SetFullName(string fullName)
        {
            var data = fullName.Split(' ');
            LastName = data[0];
            FirstName = data[data.Length - 1];
            var mid = "";
            for (int i = 1; i < data.Length - 1; i++)
            {
                mid += data[i] + " ";
            }
            MidName = mid;
        }
        public override string ToString() => $"{LastName} {MidName}{FirstName}";
    }
}
