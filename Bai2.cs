
using System;

class Program
{
    static void Insert(int[] data, ref int count, int index, int value)
    {
        //vị trí chèn hợp lệ nằm từ 0 đến count
        if (index < 0 || index > count)
            throw new ArgumentOutOfRangeException(nameof(index));

        //nếu count bằng độ dài mảng thì không còn ô trống
        if (count == data.Length)
            throw new InvalidOperationException("Mang da day.");

        //dịch từ phải sang trái để không ghi đè dữ liệu cũ
        for (int i = count; i > index; i--)
        {
            //đưa phần tử bên trái sang ô bên phải
            data[i] = data[i - 1];
        }

        //gán giá trị mới vào vị trí đã tạo trống
        data[index] = value;

        //tăng số phần tử hợp lệ sau khi chèn thành công
        count++;
    }

    static void RemoveAt(int[] data, ref int count, int index)
    {
        //vị trí xóa hợp lệ nằm từ 0 đến count - 1
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException(nameof(index));

        //dịch từ trái sang phải để lấp vị trí bị xóa
        for (int i = index; i < count - 1; i++)
        {
            //lấy phần tử bên phải ghi đè lên ô hiện tại
            data[i] = data[i + 1];
        }

        //giảm số phần tử hợp lệ sau khi dịch xong
        count--;
    }

    static void PrintArray(int[] data, int count)
    {
        //chỉ in count phần tử đang được sử dụng
        for (int i = 0; i < count; i++)
        {
            Console.Write(data[i] + " ");
        }

        Console.WriteLine();
    }

    static void Main2()
    {
        //cấp phát 10 ô nhưng ban đầu chỉ dùng 5 ô.
        int[] data = new int[10] { 4, 7, 2, 9, 5, 0, 0, 0, 0, 0 };
        int count = 5;

        Console.WriteLine("Mang ban dau:");
        PrintArray(data, count);

        //chèn 99 tại index 2
        Insert(data, ref count, 2, 99);
        Console.WriteLine("Sau khi chen 99:");
        PrintArray(data, count);

        //xóa phần tử tại index 1
        RemoveAt(data, ref count, 1);
        Console.WriteLine("Sau khi xoa index 1:");
        PrintArray(data, count);

        //kiểm thử chèn đầu và chèn cuối
        Insert(data, ref count, 0, 100);
        Insert(data, ref count, count, 200);
        Console.WriteLine("Sau khi chen dau va cuoi:");
        PrintArray(data, count);

        //kiểm thử xóa đầu và xóa cuối
        RemoveAt(data, ref count, 0);
        RemoveAt(data, ref count, count - 1);
        Console.WriteLine("Sau khi xoa dau va cuoi:");
        PrintArray(data, count);

        //kiểm tra vị trí âm
        try
        {
            Insert(data, ref count, -1, 10);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Loi: index am.");
        }

        //kiểm tra xóa tại index bằng count
        try
        {
            RemoveAt(data, ref count, count);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Loi: index xoa khong hop le.");
        }

        //tạo mảng đầy để kiểm tra ngoại lệ
        int[] full = { 1, 2, 3 };
        int fullCount = 3;

        try
        {
            Insert(full, ref fullCount, 1, 99);
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Loi: mang da day.");
        }
    }
}
