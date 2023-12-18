using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace L71e2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8; //cho phép nhập kí tự có dấu
            Console.OutputEncoding = Encoding.UTF8; //cho phép in ra màn hình ký tự có dấu
            int choice = 0;
            List<Student> students = new List<Student>();       //danh sách sinh viên có trong hệ thống
            CreateFaKeDataStudent(students);
            List<Subject> subjects = new List<Subject>();       //danh sách các môn học có trong hệ thống
            CreateFakeDataSubjects(subjects);
            List<Register> registers = new List<Register>();    //danh sách các bảng đăng ký có trong hệ thống
            CreateFakeDataRegisters(registers, students, subjects);
            do
            {
                Console.Clear();
                Console.WriteLine("=========================> CÁC CHỨC NĂNG <========================");
                Console.WriteLine("*    01. Thêm mới sinh viên vào danh sách sinh viên.             *");
                Console.WriteLine("*    02. Thêm mới môn học vào danh sách môn học.                 *");
                Console.WriteLine("*    03. Thêm mới bản đăng ký môn học vào danh sách đăng ký.     *");
                Console.WriteLine("*    04. Hiển thị danh sách sinh viên ra màn hình.               *");
                Console.WriteLine("*    05. Hiển thị danh sách môn học ra màn hình.                 *");
                Console.WriteLine("*    06. Hiển thị danh sách đăng ký ra màn hình.                 *");
                Console.WriteLine("*    07. Sắp xếp danh sách sinh viên theo tên a-z.               *");
                Console.WriteLine("*    08. Sắp xếp danh sách môn học theo số tín chỉ giảm dần.     *");
                Console.WriteLine("*    09. Sắp xếp danh sách đăng ký theo thời gian đăng ký.       *");
                Console.WriteLine("*    10. Sắp xếp danh sách đăng ký theo mã sinh viên.            *");
                Console.WriteLine("*    11. Sắp xếp danh sách đăng ký theo mã môn học.              *");
                Console.WriteLine("*    12. Tìm danh sách đăng ký theo mã môn học.                  *");
                Console.WriteLine("*    13. Tìm danh sách đăng ký theo mã sinh viên.                *");
                Console.WriteLine("*    14. Sửa tên sinh viên theo mã sinh viên cho trước.          *");
                Console.WriteLine("*    15. Sửa số tiết học theo mã môn học cho trước.              *");
                Console.WriteLine("*    16. Xóa môn học khỏi danh sách môn học.                     *");
                Console.WriteLine("*    17. Xóa sinh viên khỏi danh sách sinh viên.                 *");
                Console.WriteLine("*    18. Xóa bản đăng ký theo mã đăng ký.                        *");
                Console.WriteLine("*    19. Thoát chương trình.                                     *");
                Console.WriteLine("==================================================================");
                Console.Write("==> Xin mời bạn chọn chức năng:  ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        var student = CreateNewStudent(students);
                        if (student != null)
                        {
                            students.Add(student);
                            ShowMessage("Thêm sinh viên thành công!");
                        }
                        else
                            ShowMessage("Thêm mới sinh viên thất bại!");
                        break;
                    case 2:
                        var subject = CreateNewSubject();
                        if (subject != null)
                        {
                            subjects.Add(subject);
                            ShowMessage("Thêm mới môn học thành công!");
                        }
                        else
                            ShowMessage("Thêm mới môn học thất bại!");
                        break;
                    case 3:
                        var register = CreateNewRegister(students, subjects);
                        if (register != null && register.Subject != null && register.Student != null)
                        {
                            if (!Contains(registers, register))
                            {
                                registers.Add(register);
                                ShowMessage($"Sinh viên \"{register.Student.StudentId}\" " +
                                        $"đăng ký thành công môn học \"{register.Subject.SubjectId}\".");
                            }
                            else
                            {
                                ShowMessage($"Lỗi. Sinh viên \"{register.Student.StudentId}\" " +
                                      $"đã đăng ký môn học \"{register.Subject.SubjectId}\" trước đó.");
                            }

                        }
                        else
                            ShowMessage("Thêm mới bản đăng kí môn học thất bại!");
                        break;
                    case 4:
                        if (students.Count > 0)
                        {
                            ShowStudents(students);
                        }
                        else
                            ShowMessage("Danh sách sinh viên rỗng!");
                        break;
                    case 5:
                        if (subjects.Count > 0)
                        {
                            ShowSubjects(subjects);
                        }
                        else
                            ShowMessage("Danh sách môn học rỗng!");
                        break;
                    case 6:
                        if (registers.Count > 0)
                        {
                            ShowRegisters(registers);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 7:
                        if (students.Count > 0)
                        {
                            SortStudentByNameASC(students);
                            ShowMessage("Sắp xếp sinh viên thành công!");
                        }
                        else
                            ShowMessage("Danh sách sinh viên rỗng!");
                        break;
                    case 8:
                        if (subjects.Count > 0)
                        {
                            SortSubjectByCreditDESC(subjects);
                            ShowMessage("Sắp xếp môn học thành công!");
                        }
                        else
                            ShowMessage("Danh sách môn học rỗng!");
                        break;
                    case 9:
                        if (registers.Count > 0)
                        {
                            SortRegisterByRegisterTimeASC(registers);
                            ShowMessage("Sắp xếp danh sách đăng ký môn học thành công!");
                        }
                        else
                            ShowMessage("Danh sách đăng ký môn học rỗng!");
                        break;
                    case 10:
                        if (registers.Count > 0)
                        {
                            SortRegisterByStudentIdASC(registers);
                            ShowMessage("Sắp xếp danh sách đăng ký môn học thành công!");
                        }
                        else
                            ShowMessage("Danh sách đăng ký môn học rỗng!");
                        break;
                    case 11:
                        if (registers.Count > 0)
                        {
                            SortRegisterBySubjectIdASC(registers);
                            ShowMessage("Sắp xếp danh sách đăng ký môn học thành công!");
                        }
                        else
                            ShowMessage("Danh sách đăng ký môn học rỗng!");
                        break;
                    case 12:
                        if (registers.Count > 0)
                        {
                            Console.Write("Nhập mã môn học: ");
                            var subjectId = int.Parse(Console.ReadLine());
                            var result = FindRegisterBySubjectId(registers, subjectId);
                            if (result.Count > 0)
                            {
                                ShowMessage("Kết quả tìm kiếm theo mã môn học");
                                ShowRegisters(result);
                            }
                        }
                        else
                            ShowMessage("Danh sách đăng ký môn học rỗng!");
                        break;
                    case 13:
                        if (registers.Count > 0)
                        {
                            Console.Write("Nhập mã sinh viên: ");
                            var studentId = Console.ReadLine();
                            var result = FindRegisterByStudentId(registers, studentId);
                            if (result.Count > 0)
                            {
                                ShowMessage("Kết quả tìm kiếm theo mã sinh viên");
                                ShowRegisters(result);
                            }
                        }
                        else
                            ShowMessage("Danh sách đăng ký môn học rỗng!");
                        break;
                    case 14:
                        if (students.Count > 0)
                        {
                            Console.Write("Nhập mã sinh viên: ");
                            var studentId = Console.ReadLine();
                            var studentIndex = FindStudentIndexById(students, studentId);
                            if (studentIndex > -1)
                            {
                                Console.Write("Nhập tên mới của sinh viên: ");
                                var newName = Console.ReadLine();
                                students[studentIndex].FullName = new FullName(newName);
                                ShowMessage($"Sửa thông tin sinh viên có mã {studentId} thành công!");
                            }
                            else
                            {
                                ShowMessage($"Không tìm thấy sinh viên có mã {studentId}");
                            }
                        }
                        else
                            ShowMessage("Danh sách sinh viên rỗng!");
                        break;
                    case 15:
                        if (subjects.Count > 0)
                        {
                            Console.Write("Nhập mã môn học: ");
                            var subjectId = int.Parse(Console.ReadLine());
                            var subjectIndex = FindSubjectIndexById(subjects, subjectId);
                            if (subjectIndex > -1)
                            {
                                Console.Write("Nhập số tiết học mới: ");
                                var newNumOfLesson = int.Parse(Console.ReadLine());
                                subjects[subjectIndex].NumOfLesson = newNumOfLesson;
                                ShowMessage($"Sửa thông tin môn học có mã {subjectId} thành công!");
                            }
                            else
                            {
                                ShowMessage($"Không tìm thấy môn học có mã {subjectId}");
                            }
                        }
                        else
                            ShowMessage("Danh sách sinh viên rỗng!");
                        break;
                    case 16:
                        if (subjects.Count > 0)
                        {
                            Console.Write("Nhập mã môn học cần xoá: ");
                            var subjectId = int.Parse(Console.ReadLine());
                            var subjectIndex = FindSubjectIndexById(subjects, subjectId);
                            if (subjectIndex > -1)
                            {
                                Console.WriteLine("Bạn có chắc muốn xoá môn học khỏi danh sách? (y/n)");
                                var ans = Console.ReadLine();
                                if (ans.ToLower().CompareTo("y") == 0)
                                {
                                    subjects.RemoveAt(subjectIndex);
                                    ShowMessage($"Xoá thông tin môn học có mã {subjectId} thành công!");
                                }
                                else
                                {
                                    ShowMessage($"Xoá thông tin môn học có mã {subjectId} thất bại!");
                                }
                            }
                            else
                            {
                                ShowMessage($"Không tìm thấy môn học có mã {subjectId}");
                            }
                        }
                        else
                            ShowMessage("Danh sách sinh viên rỗng!");
                        break;
                    case 17:
                        if (students.Count > 0)
                        {
                            Console.Write("Nhập mã sinh viên cần xoá: ");
                            var studentId = Console.ReadLine();
                            var studentIndex = FindStudentIndexById(students, studentId);
                            if (studentIndex > -1)
                            {
                                Console.WriteLine("Bạn có chắc muốn xoá sinh viên khỏi danh sách? (y/n)");
                                var ans = Console.ReadLine();
                                if (ans.ToLower().CompareTo("y") == 0)
                                {
                                    students.RemoveAt(studentIndex);
                                    ShowMessage($"Xoá thông tin sinh viên có mã {studentId} thành công!");
                                }
                                else
                                {
                                    ShowMessage($"Xoá thông tin sinh viên có mã {studentId} thất bại!");
                                }
                            }
                            else
                            {
                                ShowMessage($"Không tìm thấy sinh viên có mã {studentId}");
                            }
                        }
                        else
                            ShowMessage("Danh sách sinh viên rỗng!");
                        break;
                    case 18:
                        if (registers.Count > 0)
                        {
                            Console.Write("Nhập mã bản đăng ký cần xoá: ");
                            var registerId = int.Parse(Console.ReadLine());
                            var registerIndex = FindRegisterById(registers, registerId);
                            if (registerIndex > -1)
                            {
                                Console.WriteLine("Bạn có chắc muốn xoá bản ghi khỏi danh sách? (y/n)");
                                var ans = Console.ReadLine();
                                if (ans.ToLower().CompareTo("y") == 0)
                                {
                                    registers.RemoveAt(registerIndex);
                                    ShowMessage($"Xoá thông tin bản ghi có mã {registerIndex} thành công!");
                                }
                                else
                                {
                                    ShowMessage($"Xoá thông tin bản ghi có mã {registerIndex} thất bại!");
                                }
                            }
                            else
                            {
                                ShowMessage($"Không tìm thấy bản ghi có mã {registerIndex}");
                            }
                        }
                        else
                            ShowMessage("Danh sách sinh viên rỗng!");
                        break;
                    case 19:
                        ShowMessage("Thoát chương trình!");
                        break;
                }
                if (choice != 19)
                    Console.WriteLine("Press any key to back to menu...");
                Console.ReadKey();
            } while (choice != 19);
        }
        //lấy vị trí của bản ghi có Id tương ứng
        private static int FindRegisterById(List<Register> registers, int registerId)
        {
            for (int i = 0; i < registers.Count; i++)
                if (registers[i].RegisterId == registerId)
                    return i;
            return -1;
        }

        //Tìm danh sách đăng ký theo mã sinh viên.
        private static List<Register> FindRegisterByStudentId(List<Register> registers, string studentId)
        {
            var resultList = new List<Register>();
            foreach (var item in registers)
                if (item.Student.StudentId.CompareTo(studentId) == 0)
                    resultList.Add(item);
            return resultList;
        }

        //Tìm danh sách đăng ký theo mã môn học.
        private static List<Register> FindRegisterBySubjectId(List<Register> registers, int subjectId)
        {
            var resultList = new List<Register>();
            foreach (var item in registers)
                if (item.Subject.SubjectId == subjectId)
                    resultList.Add(item);
            return resultList;
        }

        // Sắp xếp danh sách đăng ký môn học theo mã môn học tăng dần.
        private static void SortRegisterBySubjectIdASC(List<Register> registers)
        {
            //sử dụng BubbleSort
            for (int i = 0; i < registers.Count - 1; i++)
            {
                for (int j = i + 1; j < registers.Count; j++)
                    if (registers[i].Subject.SubjectId.CompareTo(registers[j].Subject.SubjectId) > 0)
                    {
                        //đổi chỗ
                        var temp = registers[i];
                        registers[i] = registers[j];
                        registers[j] = temp;
                    }
            }
        }

        //Sắp xếp danh sách đăng ký môn học theo mã sinh viên tăng dần.
        private static void SortRegisterByStudentIdASC(List<Register> registers)
        {
            //sử dụng BubbleSort
            for (int i = 0; i < registers.Count - 1; i++)
            {
                for (int j = i + 1; j < registers.Count; j++)
                    if (registers[i].Student.StudentId.CompareTo(registers[j].Student.StudentId) > 0)
                    {
                        //đổi chỗ
                        var temp = registers[i];
                        registers[i] = registers[j];
                        registers[j] = temp;
                    }
            }
        }

        //Sắp xếp danh sách đăng ký môn học theo thời gian đăng ký từ sớm nhất đến muộn nhất.
        private static void SortRegisterByRegisterTimeASC(List<Register> registers)
        {
            //sử dụng BubbleSort
            for (int i = 0; i < registers.Count - 1; i++)
            {
                for (int j = i + 1; j < registers.Count; j++)
                    if (registers[i].RegisterTime > registers[j].RegisterTime)
                    {
                        //đổi chỗ
                        var temp = registers[i];
                        registers[i] = registers[j];
                        registers[j] = temp;
                    }
            }
        }

        //Sắp xếp danh sách môn học theo số tín chỉ giảm dần.
        private static void SortSubjectByCreditDESC(List<Subject> subjects)
        {
            //sử dụng BubbleSort
            for (int i = 0; i < subjects.Count - 1; i++)
            {
                for (int j = i + 1; j < subjects.Count; j++)
                    if (subjects[i].Credit < subjects[j].Credit)
                    {
                        //đổi chỗ
                        //đổi chỗ
                        var temp = subjects[i];
                        subjects[i] = subjects[j];
                        subjects[j] = temp;
                    }
            }
        }

        //Sắp xếp danh sách sinh viên theo tên a-z. Nếu tên trùng nhau thì sắp xếp theo họ a-z.
        private static void SortStudentByNameASC(List<Student> students)
        {
            //sử dụng bubble Sort
            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = i + 1; j < students.Count; j++)
                {
                    if (students[i].FullName.FirstName.CompareTo(students[j].FullName.FirstName) > 0)
                    {
                        //đổi chỗ
                        var temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                    else if (students[i].FullName.FirstName.CompareTo(students[j].FullName.FirstName) == 0)
                    {
                        //tiến hành so sánh họ
                        if (students[i].FullName.LastName.CompareTo(students[j].FullName.LastName) > 0)
                        {
                            //đổi chỗ
                            var temp = students[i];
                            students[i] = students[j];
                            students[j] = temp;
                        }
                    }
                }
            }
        }

        //Hiển thị danh sách đăng ký ra màn hình.
        private static void ShowRegisters(List<Register> registers)
        {
            var id = "Mã đăng ký";
            var stId = "Mã sinh viên";
            var stName = "Tên sinh viên";
            var suId = "Mã môn học";
            var suName = "Tên môn học";
            var regTime = "Thời gian đăng ký";
            Console.WriteLine($"{id,-15:d}{stId,-15:d}{stName,-25:d}{suId,-15:d}{suName,-25:d}{regTime,-15:d}");
            foreach (var reg in registers)
            {
                Console.WriteLine($"{reg.RegisterId,-15:d}{reg.Student.StudentId,-15:d}" +
                    $"{reg.Student.FullName,-25:d}{reg.Subject.SubjectId,-15:d}" +
                    $"{reg.Subject.SubjectName,-25:d}{reg.RegisterTime.ToString("yyyy-MM-dd HH:mm:ss"),-15:d}");
            }
        }

        // kiểm tra xem một bản đăng ký đã tồn tại trước đó chưa
        private static bool Contains(List<Register> registers, Register register)
        {
            foreach (var r in registers)
            {
                if (r.Equals(register)) return true;
            }
            return false;
        }

        //Thêm mới bản đăng ký môn học vào danh sách đăng ký.
        private static Register CreateNewRegister(List<Student> students, List<Subject> subjects)
        {
            Console.Write("MSSV: ");
            var studentId = Console.ReadLine();
            Console.Write("Mã môn học: ");
            var subjectId = int.Parse(Console.ReadLine());
            var registerTime = DateTime.Now;
            var studentIndex = FindStudentIndexById(students, studentId);
            var subjectIndex = FindSubjectIndexById(subjects, subjectId);
            var subject = subjectIndex == -1 ? null : subjects[subjectIndex];
            var student = studentIndex == -1 ? null : students[studentIndex];
            return new Register(student, subject, registerTime);
        }
        //tìm vị trí của subject trong danh sách bằng id
        private static int FindSubjectIndexById(List<Subject> subjects, int subjectId)
        {
            for (int i = 0; i < subjects.Count; i++)
                if (subjects[i].SubjectId == subjectId)
                    return i;
            return -1;
        }

        //Hiển thị danh sách môn học ra màn hình. 
        private static void ShowSubjects(List<Subject> subjects)
        {
            var titleId = "Mã môn học";
            var titleName = "Tên môn học";
            var titleCredit = "Số tín chỉ";
            var titleLesson = "Số tiết học";
            Console.WriteLine($"{titleId,-15}{titleName,-40}{titleCredit,-15}{titleLesson,-15}");
            foreach (var subject in subjects)
                Console.WriteLine($"{subject.SubjectId,-15}{subject.SubjectName,-40}" +
                    $"{subject.Credit,-15}{subject.NumOfLesson,-15}");
        }

        //tạo mới môn học
        private static Subject CreateNewSubject()
        {
            Console.Write("Tên môn học: ");
            var name = Console.ReadLine();
            Console.Write("Số tín chỉ: ");
            var credit = int.Parse(Console.ReadLine());
            Console.Write("Số tiết học: ");
            var lesson = int.Parse(Console.ReadLine());
            return new Subject(name, credit, lesson);
        }

        //Hiển thị danh sách sinh viên có trong hệ thống
        private static void ShowStudents(List<Student> students)
        {
            var titleId = "MSSV";
            var titleName = "Họ và tên";
            var titleBirthDate = "Ngày sinh";
            var titleEmail = "Email";
            var titlePhoneNumber = "SĐT";
            var titleMajor = "Chuyên ngành";
            Console.WriteLine($"{titleId,-15}{titleName,-40}{titleBirthDate,-20}" +
                $"{titleEmail,-40}{titlePhoneNumber,-15}{titleMajor,-20}");
            foreach (var student in students)
                Console.WriteLine($"{student.StudentId,-15}{student.FullName,-40}" +
                    $"{student.DateOfBirth.Year + "/" + student.DateOfBirth.Month + "/" + student.DateOfBirth.Day,-20}" +
                    $"{student.Email,-40}{student.PhoneNumber,-15}" +
                    $"{student.Major,-20}");
        }
        //thêm mới sinh viên vào danh sách
        private static Student CreateNewStudent(List<Student> students)
        {
            Filter filter = new Filter();
            Console.Write("MSSV: ");
            var id = Console.ReadLine();
            if (!filter.IsValidStudentId(id))
            {
                Console.WriteLine("MSSV chưa đúng định dạng. Vui lòng xem lại! " +
                    "Mã đúng có dạng: <B><2 số><4 chữ cái><3 số>.VD:B25DCCN171");
                return null;
            }
            else
            {
                //kiểm tra mã sinh viên đã tồn tại hay chưa,
                //nếu có rồi thì bỏ qua, chưa có thì cho phép tạo mới thông tin
                var indexOfStudent = FindStudentIndexById(students, id);
                if (indexOfStudent >= 0)
                {
                    Console.WriteLine($"==> Sinh viên mã \"{id}\" đã tồn tại.");
                    return null;
                }
            }
            Console.Write("Họ và tên: ");
            var name = Console.ReadLine();
            if (!filter.IsValidStudentName(name))
            {
                Console.WriteLine("Tên chưa đúng định dạng. Vui lòng xem lại!" +
                    " Họ và tên chỉ có thể chứa các chữ cái," +
                    " các từ phân tách nhau bởi dấu cách, không quá 40 kí tự");
                return null;
            }
            Console.Write("Ngày sinh: ");
            var birthDate = Console.ReadLine().Trim();
            if (!filter.IsValidBirthDate(birthDate))
            {
                Console.WriteLine("Ngày sinh chưa đúng định dạng. Vui lòng xem lại!" +
                    "Ngày sinh có dạng 2001/12/01");
                return null;
            }
            var dateFormat = "yyyy/MM/dd";
            DateTime dob = DateTime.ParseExact(birthDate, dateFormat, null);
            Console.Write("Email: ");
            var email = Console.ReadLine();
            if (!filter.IsValidEmail(email))
            {
                Console.WriteLine("Email chưa đúng định dạng. Vui lòng xem lại!" +
                    "Email có dạng: example@xmail.com");
                return null;
            }
            Console.Write("SĐT: ");
            var phone = Console.ReadLine();
            if (!filter.IsValidPhone(phone))
            {
                Console.WriteLine("SĐT chưa đúng định dạng. Vui lòng xem lại!" +
                    "Số điện thoại có 10 chữ số, bắt đầu với 03, 08, 09, sau đó là 8 số.");
                return null;
            }
            Console.Write("Chuyên ngành: ");
            var major = Console.ReadLine();
            return new Student(id, name, dob, email, phone, major);
        }
        //tìm vị trí của student trong danh sách bằng id
        private static int FindStudentIndexById(List<Student> students, string id)
        {
            for (int i = 0; i < students.Count; i++)
                if (students[i].StudentId.CompareTo(id) == 0)
                    return i;
            return -1;//nếu không có id nào (sinh viên chưa tồn tại trong danh sách) thì return -1
        }
        //tạo data fake thêm các bảng đăng ký
        private static void CreateFakeDataRegisters(List<Register> registers, List<Student> students, List<Subject> subjects)
        {
            registers.Add(new Register(students[0], subjects[0], DateTime.Now));
            registers.Add(new Register(students[1], subjects[0], DateTime.Now));
            registers.Add(new Register(students[2], subjects[0], DateTime.Now));
            registers.Add(new Register(students[3], subjects[0], DateTime.Now));
            registers.Add(new Register(students[4], subjects[0], DateTime.Now));
            registers.Add(new Register(students[0], subjects[5], DateTime.Now));
            registers.Add(new Register(students[1], subjects[2], DateTime.Now));
            registers.Add(new Register(students[2], subjects[1], DateTime.Now));
            registers.Add(new Register(students[3], subjects[3], DateTime.Now));
            registers.Add(new Register(students[4], subjects[4], DateTime.Now));
            registers.Add(new Register(students[1], subjects[1], DateTime.Now));
            registers.Add(new Register(students[1], subjects[5], DateTime.Now));
            registers.Add(new Register(students[0], subjects[1], DateTime.Now));
            registers.Add(new Register(students[0], subjects[2], DateTime.Now));
            registers.Add(new Register(students[0], subjects[3], DateTime.Now));
        }
        //tạo data fake thêm các môn học
        private static void CreateFakeDataSubjects(List<Subject> subjects)
        {
            subjects.Add(new Subject("C++", 3, 36));
            subjects.Add(new Subject("C", 3, 36));
            subjects.Add(new Subject("C#", 4, 48));
            subjects.Add(new Subject("Java", 4, 46));
            subjects.Add(new Subject("Kotlin", 3, 36));
            subjects.Add(new Subject("Android", 5, 60));
            subjects.Add(new Subject("SQL", 3, 36));
            subjects.Add(new Subject("Python", 4, 48));
            subjects.Add(new Subject("JavaScript", 3, 36));
            subjects.Add(new Subject("Web design", 2, 25));
        }
        //tạo Data fake có sẵn cho Student
        private static void CreateFaKeDataStudent(List<Student> students)
        {
            var dateFormat = "dd/MM/yyyy";
            students.Add(new Student("B25DCCN101", "Trần Văn Nam", DateTime.ParseExact("15/06/2007", dateFormat, null), "vannam@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN103", "Ngô Văn Tài", DateTime.ParseExact("15/04/2007", dateFormat, null), "vantai123@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN102", "Hồ Hoàng Yến", DateTime.ParseExact("27/07/2007", dateFormat, null), "hoangyenkk@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN105", "Võ Hoàng Yến", DateTime.ParseExact("11/09/2007", dateFormat, null), "yenvo@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN104", "Vy Thị Yến", DateTime.ParseExact("14/02/2007", dateFormat, null), "yenvi@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN108", "Mai Văn Dũng", DateTime.ParseExact("19/08/2007", dateFormat, null), "vandung@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN107", "Lê Thanh Thảo", DateTime.ParseExact("18/09/2007", dateFormat, null), "thanhthao@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN106", "Ngô Nhật Phong", DateTime.ParseExact("10/10/2007", dateFormat, null), "nhatphong@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN109", "Ma Thanh Thức", DateTime.ParseExact("16/11/2007", dateFormat, null), "thanhthuc@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN111", "Khúc Thị Lệ Quyên", DateTime.ParseExact("18/12/2007", dateFormat, null), "lequyenkhuc@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN110", "Trương Trọng Anh", DateTime.ParseExact("17/05/2007", dateFormat, null), "tronganhtruong@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN112", "Nguyễn Quỳnh Anh", DateTime.ParseExact("25/01/2007", dateFormat, null), "quynhanhng@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN115", "Thân Văn Huấn", DateTime.ParseExact("30/04/2007", dateFormat, null), "vanhuanth@xmail.com", "0912365211", "CNTT"));
        }

        private static void ShowMessage(string msg)
        {
            Console.WriteLine($"===> {msg} <===");
        }
    }
}
