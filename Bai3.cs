
using System;
using System.Collections.Generic;

public class Student
{
    //mã dùng để nhận diện duy nhất một sinh viên
    public string Id { get; set; } = "";

    //họ tên dùng để hiển thị và tìm kiếm
    public string FullName { get; set; } = "";

    //điểm tổng kết của sinh viên
    public double Score { get; set; }
}

class DSABuoi2_Bai3
{
    //danh sách dùng chung cho các chức năng
    static List<Student> students = new List<Student>();

    static int FindById(string id)
    {
        //duyệt toàn bộ danh sách để tìm mã sinh viên
        for (int i = 0; i < students.Count; i++)
        {
            //trả về vị trí khi tìm được mã tương ứng
            if (students[i].Id == id)
                return i;
        }

        //-1 biểu thị không tìm thấy sinh viên
        return -1;
    }

    static void AddStudent()
    {
        Console.Write("Nhap ma sinh vien: ");
        string id = Console.ReadLine() ?? "";

        //mã không được rỗng hoặc trùng mã đã có
        if (string.IsNullOrWhiteSpace(id) || FindById(id) != -1)
        {
            Console.WriteLine("Ma rong hoac da ton tai.");
            return;
        }

        Console.Write("Nhap ho ten: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Nhap diem: ");
        string input = Console.ReadLine() ?? "";

        //chỉ chấp nhận điểm số hợp lệ trong đoạn 0 đến 10
        if (!double.TryParse(input, out double score)
            || double.IsNaN(score)
            || score < 0 || score > 10)
        {
            Console.WriteLine("Diem khong hop le.");
            return;
        }

        //tạo đối tượng sinh viên từ dữ liệu đã kiểm tra
        Student s = new Student();
        s.Id = id;
        s.FullName = name;
        s.Score = score;

        //thêm sinh viên vào cuối danh sách
        students.Add(s);

        Console.WriteLine("Them thanh cong.");
    }

    static void UpdateStudent()
    {
        Console.Write("Nhap ma can cap nhat: ");
        string id = Console.ReadLine() ?? "";

        //xác định vị trí sinh viên cần sửa
        int index = FindById(id);

        if (index == -1)
        {
            Console.WriteLine("Khong tim thay sinh vien.");
            return;
        }

        Console.WriteLine("1. Sua ho ten");
        Console.WriteLine("2. Sua diem");
        Console.Write("Chon: ");
        string choice = Console.ReadLine() ?? "";

        if (choice == "1")
        {
            Console.Write("Nhap ho ten moi: ");

            //thay đổi họ tên của sinh viên tại vị trí tìm được
            students[index].FullName = Console.ReadLine() ?? "";
            Console.WriteLine("Cap nhat thanh cong.");
        }
        else if (choice == "2")
        {
            Console.Write("Nhap diem moi: ");
            string input = Console.ReadLine() ?? "";

            //không cập nhật nếu điểm mới không hợp lệ
            if (!double.TryParse(input, out double score)
                || double.IsNaN(score)
                || score < 0 || score > 10)
            {
                Console.WriteLine("Diem khong hop le.");
                return;
            }

            //ghi điểm mới vào đối tượng sinh viên
            students[index].Score = score;
            Console.WriteLine("Cap nhat thanh cong.");
        }
        else
        {
            Console.WriteLine("Lua chon khong hop le.");
        }
    }

    static void DeleteStudent()
    {
        Console.Write("Nhap ma can xoa: ");
        string id = Console.ReadLine() ?? "";

        //tìm vị trí sinh viên trước khi xóa
        int index = FindById(id);

        if (index == -1)
        {
            Console.WriteLine("Khong tim thay sinh vien.");
            return;
        }

        //xóa phần tử và dịch các phần tử phía sau sang trái
        students.RemoveAt(index);

        Console.WriteLine("Xoa thanh cong.");
    }

    static void SearchStudent()
    {
        Console.Write("Nhap mot phan ho ten: ");
        string keyword = Console.ReadLine() ?? "";

        //đếm kết quả để biết có tìm thấy sinh viên hay không
        int found = 0;

        //duyệt từng sinh viên để kiểm tra họ tên
        for (int i = 0; i < students.Count; i++)
        {
            //IndexOf trả về -1 khi không chứa từ khóa.
            //OrdinalIgnoreCase giúp bỏ qua chữ hoa và chữ thường.
            if (students[i].FullName.IndexOf(
                keyword, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                PrintStudent(students[i]);
                found++;
            }
        }

        if (found == 0)
            Console.WriteLine("Khong tim thay sinh vien.");
    }

    static void PrintStudent(Student s)
    {
        //hiển thị các thuộc tính của một sinh viên
        Console.WriteLine($"{s.Id} | {s.FullName} | {s.Score:F2}");
    }

    static void ShowStudents()
    {
        //tránh hiển thị danh sách khi chưa có sinh viên
        if (students.Count == 0)
        {
            Console.WriteLine("Danh sach rong.");
            return;
        }

        //hiển thị lần lượt tất cả sinh viên
        for (int i = 0; i < students.Count; i++)
        {
            PrintStudent(students[i]);
        }
    }

    static void Statistics()
    {
        //không thể tính trung bình khi danh sách rỗng
        if (students.Count == 0)
        {
            Console.WriteLine("Danh sach rong.");
            return;
        }

        double sum = 0;
        int passed = 0;

        //một vòng lặp tính tổng và đếm số sinh viên đạt
        for (int i = 0; i < students.Count; i++)
        {
            //cộng điểm để tính trung bình sau khi duyệt
            sum += students[i].Score;

            //sinh viên đạt khi điểm từ 5 trở lên
            if (students[i].Score >= 5)
                passed++;
        }

        //chia tổng điểm cho số sinh viên
        double average = sum / students.Count;

        Console.WriteLine($"Diem trung binh: {average:F2}");
        Console.WriteLine($"So sinh vien dat: {passed}");
    }

    static void Main3()
    {
        //khởi tạo năm sinh viên phục vụ kiểm thử
        students.Add(new Student { Id = "SV01", FullName = "Nguyen An", Score = 8 });
        students.Add(new Student { Id = "SV02", FullName = "Tran Binh", Score = 4 });
        students.Add(new Student { Id = "SV03", FullName = "Le Chi", Score = 7 });
        students.Add(new Student { Id = "SV04", FullName = "Pham Dung", Score = 6 });
        students.Add(new Student { Id = "SV05", FullName = "Hoang An", Score = 9 });

        //menu lặp cho đến khi người dùng chọn thoát
        while (true)
        {
            Console.WriteLine("\n===== QUAN LY SINH VIEN =====");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Cap nhat sinh vien");
            Console.WriteLine("3. Xoa sinh vien");
            Console.WriteLine("4. Tim theo ho ten");
            Console.WriteLine("5. Hien thi danh sach");
            Console.WriteLine("6. Thong ke");
            Console.WriteLine("7. Xoa tat ca (kiem thu danh sach rong)");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon: ");

            string choice = Console.ReadLine() ?? "";

            //gọi phương thức tương ứng với chức năng được chọn
            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    UpdateStudent();
                    break;
                case "3":
                    DeleteStudent();
                    break;
                case "4":
                    SearchStudent();
                    break;
                case "5":
                    ShowStudents();
                    break;
                case "6":
                    Statistics();
                    break;
                case "7":
                    //xóa toàn bộ để kiểm thử thống kê rỗng
                    students.Clear();
                    Console.WriteLine("Da xoa tat ca.");
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    break;
            }
        }
    }
}
