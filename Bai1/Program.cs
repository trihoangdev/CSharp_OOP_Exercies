using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace L71e1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            List<Employee> employees = new List<Employee>();
            int choice = 0;
            CreateFakeData(employees);
            do
            {
                Console.Clear();
                Console.WriteLine("==================================MENU======================================");
                Console.WriteLine("1. Thêm mới một nhân viên vào danh sách nhân viên");
                Console.WriteLine("2. Hiển thị danh sách nhân viên ra màn hình.");
                Console.WriteLine("3. Tính lương của các nhân viên trong danh sách.");
                Console.WriteLine("4. Sắp xếp danh sách nhân viên theo mức lương thực lĩnh giảm dần");
                Console.WriteLine("5. Sắp xếp danh sách nhân viên theo số ngày đi làm trong tháng giảm dần.");
                Console.WriteLine("6. Tìm và hiển thị thông tin nhân viên theo mã nhân viên.");
                Console.WriteLine("7. Cập nhật mức lương cho nhân viên mã x vừa được tăng lương.");
                Console.WriteLine("8. Xóa bỏ nhân viên có mã cho trước");
                Console.WriteLine("9. Thoát chương trình");
                Console.WriteLine("============================================================================");
                Console.Write("Mời bạn chọn: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateEmp(employees);
                        break;
                    case 2:
                        if (employees.Count > 0)
                            ShowEmp(employees);
                        else
                        {
                            ShowMessSuccess("DANH SÁCH NHÂN VIÊN RỖNG");
                        }
                        break;
                    case 3:
                        if (employees.Count > 0)
                        {
                            CalculateSalary(employees);
                        }
                        else
                        {
                            ShowMessSuccess("DANH SÁCH NHÂN VIÊN RỖNG");
                        }
                        break;
                    case 4:
                        if (employees.Count > 0)
                        {
                            SortByReceivedSalaryDESC(employees);
                        }
                        else
                        {
                            ShowMessSuccess("DANH SÁCH NHÂN VIÊN RỖNG");
                        }
                        break;
                    case 5:
                        if (employees.Count > 0)
                        {
                            SortByWorkingDayDESC(employees);
                        }
                        else
                        {
                            ShowMessSuccess("DANH SÁCH NHÂN VIÊN RỖNG");
                        }
                        break;
                    case 6:
                        if (employees.Count > 0)
                        {
                            Console.Write("Nhập mã nhân viên cần tìm: ");
                            var id = Console.ReadLine();
                            var listEmp = new List<Employee>();
                            var emp = FindEmpById(employees, id);
                            if (emp != null)
                            {
                                listEmp.Add(emp);
                                ShowEmp(listEmp);
                            }
                            else
                            {
                                ShowMessSuccess($"Không có nhân viên có mã {id}");
                            }
                        }
                        else
                        {
                            ShowMessSuccess("DANH SÁCH NHÂN VIÊN RỖNG");
                        }
                        break;
                    case 7:
                        if (employees.Count > 0)
                        {
                            Console.Write("Nhập mã nhân viên cần tăng lương: ");
                            var id = Console.ReadLine();
                            var emp = FindEmpById(employees, id);
                            if (emp != null)
                            {
                                Console.Write("Nhập mức lương mới của nhân viên(kđ): ");
                                var salary = long.Parse(Console.ReadLine());
                                if (salary > emp.Salary)
                                {
                                    emp.Salary = salary;
                                    ShowMessSuccess($"Cập nhật lương cho nhân viên {id} thành công!");
                                }
                                else
                                {
                                    ShowMessSuccess("Mức lương mới phải lớn hơn mức lương hiện tại!");
                                }
                            }
                            else
                            {
                                ShowMessSuccess($"Không có nhân viên có mã {id}");
                            }
                        }
                        else
                        {
                            ShowMessSuccess("DANH SÁCH NHÂN VIÊN RỖNG");
                        }
                        break;
                    case 8:
                        if (employees.Count > 0)
                        {
                            Console.Write("Nhập mã nhân viên cần xoá: ");
                            var id = Console.ReadLine();
                            var emp = FindEmpById(employees, id);
                            if (emp != null)
                            {
                                employees.Remove(emp);
                                ShowMessSuccess("Xoá nhân viên thành công!");
                            }
                            else
                            {
                                ShowMessSuccess($"Không có nhân viên có mã {id}. Xoá nhân viên thất bại!");
                            }
                        }
                        else
                        {
                            ShowMessSuccess("DANH SÁCH NHÂN VIÊN RỖNG");
                        }
                        break;
                    case 9:
                        ShowMessSuccess("Thoát chương trình");
                        break;
                }
                Console.ReadKey();
            } while (choice != 9);
        }
        //Tìm và hiển thị thông tin nhân viên theo mã nhân viên.
        private static Employee FindEmpById(List<Employee> employees, string id)
        {
            foreach (var emp in employees)
                if (emp.Id.CompareTo(id) == 0)
                    return emp;
            return null;
        }

        //Sắp xếp nhân viên theo Số ngày làm việc
        //-> Sử dụng Insertion Sort
        private static void SortByWorkingDayDESC(List<Employee> employees)
        {
            for (int i = 1; i < employees.Count; i++)
            {
                var employee = employees[i];
                int j = i - 1;
                while (j >= 0 && employees[j].WorkingDay < employee.WorkingDay)
                {
                    //tiến hành đổi emp vị trí thứ j sang phải
                    employees[j + 1] = employees[j];
                    j--;
                }
                employees[j + 1] = employee;
            }
            ShowMessSuccess("Sắp xếp thành công!");
        }

        //Sắp xếp nhân viên theo Lương thực lĩnh giảm dần
        //-> Sử dụng Bubble Sort
        private static void SortByReceivedSalaryDESC(List<Employee> employees)
        {
            //sử dụng Bubble Sort
            for (int i = 0; i < employees.Count - 1; i++)
            {
                for (int j = i + 1; j < employees.Count; j++)
                {
                    if (employees[i].ReceivedSalary < employees[j].ReceivedSalary)
                    {
                        //tiến hành đổi chỗ
                        var item = employees[i];
                        employees[i] = employees[j];
                        employees[j] = item;
                    }
                }
            }
            ShowMessSuccess("Sắp xếp thành công!");
        }

        //Phương thức tính lương của nhân viên
        private static void CalculateSalary(List<Employee> employees)
        {
            foreach (var item in employees)
            {
                if (item.GetType() == typeof(Employee))
                {
                    var emp = item as Employee;
                    emp.CalculateSalary();
                }
                else if (item.GetType() == typeof(Manager))
                {
                    var m = item as Manager;
                    m.CalculateSalary();
                }
                else
                {
                    var d = item as Director;
                    d.CalculateSalary();
                }
            }
            ShowMessSuccess("Tính lương nhân viên thành công");
        }
        //phương thức tạo data fake 
        private static void CreateFakeData(List<Employee> employees)
        {
            employees.Add(new Director("Hoàng Minh Trí", "tri06012003@gmail.com", "0939594342", "GĐ Kinh Doanh", 25_000, 19, DateTime.Now, 0.5f, 15_000));
            employees.Add(new Employee("Ngô Hoàng Anh", "ngohoanganh@xmail.com", "0123456987", "Dev", 16400, 23));
            employees.Add(new Employee("Trần Văn Minh", "minhtran@xmail.com", "0123456987", "Dev", 15600, 22));
            employees.Add(new Employee("Hoàng Khánh Duy", "khanhduy@xmail.com", "0123456987", "Tester", 19600, 21));
            employees.Add(new Employee("Ngô Văn Tài", "ngovantai@xmail.com", "0123456987", "Tester", 18500, 23));
            employees.Add(new Employee("Mai Văn Nam", "maivannam@xmail.com", "0123456987", "Dev", 15600, 21));
            employees.Add(new Employee("Lê Trần Nam", "letrannam@xmail.com", "0123456987", "Dev", 12600, 20));
            employees.Add(new Employee("Nguyễn Hoàng Nhung", "hoangnhung@xmail.com", "0123456987", "Tester", 16600, 22));
            employees.Add(new Director("Trần Quốc Nam", "quocnam@xmail.com", "0123456987", "GD kinh doanh", 16600, 22, DateTime.Now, 0.75f, 20_000));
            employees.Add(new Manager("Ma Quý Tùng", "quytung@xmail.com", "0123456987", "QL nhan su", 18800, 22, 0.5f));
            employees.Add(new Manager("Lương Bằng Bách", "luongbach@xmail.com", "0123456987", "QL kinh doanh", 19700, 21, 0.5f));
        }
        //Phương thức hiển thị danh sách nhân viên
        private static void ShowEmp(List<Employee> employees)
        {
            var titleId = "ID";
            var titleFullName = "Họ và tên";
            var titleEmail = "Email";
            var titlePhone = "SĐT";
            var titleRole = "Chức vụ";
            var titleSalary = "Mức lương (kđ)";
            var titleReceivedSalary = "Lương thực lĩnh(kđ)";
            var titleWorkingDay = "Số ngày làm việc";
            var titleBonusRate = "Tiền thưởng (%)";
            var titleReceivedDate = "Ngày nhận chức";
            var titleProfit = "Doanh thu(kđ)";
            var titleResponsibility = "Tiền trách nhiệm(kđ)";
            var noData = '-';
            Console.WriteLine($"{titleId,-10}{titleFullName,-40}{titleEmail,-40}" +
                $"{titlePhone,-15}{titleRole,-15}{titleSalary,-20}" +
                $"{titleWorkingDay,-20}{titleReceivedSalary,-20}{titleBonusRate,-20}" +
                $"{titleReceivedDate,-40}{titleProfit,-20}{titleResponsibility,-20}");
            foreach (var item in employees)
            {
                if (item.GetType() == typeof(Employee))
                {
                    var emp = item as Employee;//ép kiểu về Employee
                    Console.WriteLine($"{emp.Id,-10}{emp.FullName,-40}{emp.Email,-40}" +
                        $"{emp.PhoneNumber,-15}{emp.Role,-15}{emp.Salary,-20}" +
                        $"{emp.WorkingDay,-20}{emp.ReceivedSalary,-20}{noData,-20}" +
                        $"{noData,-40}{noData,-20}{noData,-20}");
                }
                else if (item.GetType() == typeof(Manager))
                {
                    //ép kiểu về Manager
                    var manager = item as Manager;
                    Console.WriteLine($"{manager.Id,-10}{manager.FullName,-40}{manager.Email,-40}" +
                        $"{manager.PhoneNumber,-15}{manager.Role,-15}{manager.Salary,-20}" +
                        $"{manager.WorkingDay,-20}{manager.ReceivedSalary,-20}{manager.BonusRate,-20}" +
                        $"{noData,-40}{noData,-20}{noData,-20}");
                }
                else
                {
                    //ép kiểu về Director
                    var d = item as Director;
                    Console.WriteLine($"{d.Id,-10}{d.FullName,-40}{d.Email,-40}" +
                        $"{d.PhoneNumber,-15}{d.Role,-15}{d.Salary,-20}" +
                        $"{d.WorkingDay,-20}{d.ReceivedSalary,-20}{d.BonusRate,-20}" +
                        $"{d.ReceivedDate.Year + "/" + d.ReceivedDate.Month + "/" + d.ReceivedDate.Day ,-40}" +
                        $"{d.Profit,-20}{d.ResponsibilityAmount,-20}");
                }
            }
        }
        //phương thức tạo mới nhân viên 
        private static void CreateEmp(List<Employee> employees)
        {
            int option;
            Console.WriteLine("===> Lựa chọn <===");
            Console.WriteLine("1. Nhân viên");
            Console.WriteLine("2. Quản lý");
            Console.WriteLine("3. Giám đốc");
            Console.Write("Bạn muốn thêm nhân viên nào vào hệ thống? ");
            Filter filter = new Filter();
            option = int.Parse(Console.ReadLine());
            string name, email, phone;
            do
            {
                Console.Write("Họ và tên: ");
                name = Console.ReadLine();
                if (!filter.IsNameValid(name))
                    Console.WriteLine("Tên phải có độ dài trong khoảng [2,40]!");
            } while (!filter.IsNameValid(name));
            do
            {
                Console.Write("Email: ");
                email = Console.ReadLine();
                if (!filter.IsEmailValid(email))
                    Console.WriteLine("Email sai định dạng! Email mẫu: example@xmail.com");
            } while (!filter.IsEmailValid(email));
            do
            {
                Console.Write("SĐT: ");
                phone = Console.ReadLine();
                if (!filter.IsPhonenumberValid(phone))
                    Console.WriteLine("SĐT sai định dạng! SĐT có dạng [09|08|03] và 8 số tiếp theo");
            } while (!filter.IsPhonenumberValid(phone));
            Console.Write("Mức lương(kđ): ");
            var salary = long.Parse(Console.ReadLine());
            Console.Write("Số ngày làm việc trong tháng: ");
            var workingDay = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                Employee emp = new Employee(name, email, phone, "Nhân viên", salary, workingDay);
                employees.Add(emp);
                ShowMessSuccess("Thêm mới nhân viên thành công");
            }
            else if (option == 2)
            {
                Console.Write("Phần trăm tiền thưởng (...%): ");
                var bonusRate = float.Parse(Console.ReadLine());
                Employee emp = new Manager(name, email, phone, "Quản lý", salary, workingDay, bonusRate);
                employees.Add(emp);
                ShowMessSuccess("Thêm mới nhân viên thành công");
            }
            else if (option == 3)
            {
                Console.Write("Ngày nhận chức (yyyy/MM/dd): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());
                if (startDate == null) { startDate = DateTime.Now; }
                Console.Write("Phần trăm tiền thưởng (...%): ");
                var bonusRate = float.Parse(Console.ReadLine());
                Console.Write("Doanh thu trong tháng(kđ): ");
                var profit = long.Parse(Console.ReadLine());
                Employee emp = new Director(name, email, phone, "Giám đốc",
                    salary, workingDay, startDate, bonusRate, profit);
                employees.Add(emp);
                ShowMessSuccess("Thêm mới nhân viên thành công");
            }
            else
            {
                ShowMessSuccess("Thêm mới nhân viên thất bại!");
                return;
            }

        }

        private static void ShowMessSuccess(string s)
        {
            Console.WriteLine($"======> {s} <======");
        }
    }
}
