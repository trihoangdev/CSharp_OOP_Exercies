using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L71e1
{
    internal class FullName
    {
        public string FirstName { get; set; } = "";
        public string MidName { get; set; } = "";
        public string LastName { get; set; } = "";
        public FullName() { }
        public FullName(string fullName)
        {
            SetFullName(fullName);
        }
        public FullName(string firstName, string midName, string lastName)
        {
            FirstName = firstName;
            MidName = midName;
            LastName = lastName;
        }

        private void SetFullName(string fullName)
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
        public override string ToString() => $"{LastName} {MidName}{FirstName} ";
    }
}
