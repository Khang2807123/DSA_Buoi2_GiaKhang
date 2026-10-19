
using System;

public class DynamicArray<T>
{
    // Mảng dùng để lưu trữ dữ liệu thực tế.
    private T[] items;

    // Số phần tử hợp lệ, chỉ được thay đổi trong lớp.
    public int Count { get; private set; }

    // Dung lượng bằng số ô đã cấp phát của mảng.
    public int Capacity => items.Length;

    public DynamicArray(int capacity = 4)
    {
        // Không cho phép cấp phát dung lượng âm.
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity));

        // Cấp phát mảng với dung lượng ban đầu.
        items = new T[capacity];

        // Mảng mới chưa chứa phần tử nào.
        Count = 0;
    }

    private void EnsureCapacity()
    {
        // Khi còn ô trống thì không cần mở rộng.
        if (Count < Capacity)
            return;

        // Nếu Capacity bằng 0 thì bắt đầu bằng 4.
        // Ngược lại, tăng dung lượng gấp đôi.
        int newCapacity = Capacity == 0 ? 4 : Capacity * 2;

        // Tạo mảng mới có nhiều ô hơn.
        T[] newItems = new T[newCapacity];

        // Ghi nhận số phần tử cần sao chép.
        Console.WriteLine($"Mo rong: {Capacity} -> {newCapacity}");
        Console.WriteLine($"So phan tu sao chep: {Count}");

        // Sao chép đúng Count phần tử hợp lệ.
        for (int i = 0; i < Count; i++)
        {
            // Giữ nguyên thứ tự của dữ liệu cũ.
            newItems[i] = items[i];
        }

        // Chuyển vùng lưu trữ sang mảng mới.
        items = newItems;
    }

    public void Add(T item)
    {
        // Đảm bảo còn chỗ trước khi thêm phần tử.
        EnsureCapacity();

        // Ghi phần tử mới vào ô trống đầu tiên.
        items[Count] = item;

        // Tăng số phần tử hợp lệ sau khi thêm.
        Count++;
    }

    public T this[int index]
    {
        get
        {
            // Không cho phép đọc ngoài vùng dữ liệu hợp lệ.
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            // Truy cập trực tiếp phần tử theo chỉ số.
            return items[index];
        }

        set
        {
            // Không cho phép ghi ngoài vùng dữ liệu hợp lệ.
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            // Cập nhật phần tử mà không thay đổi Count.
            items[index] = value;
        }
    }
}

class DSABuoi2_Bai4
{
    static void Main()
    {
        // Tạo mảng động có dung lượng ban đầu bằng 4.
        DynamicArray<int> arr = new DynamicArray<int>();

        // Thêm lần lượt các số từ 1 đến 10.
        for (int i = 1; i <= 10; i++)
        {
            // Thêm i vào cuối mảng động.
            arr.Add(i);

            // Theo dõi Count và Capacity sau mỗi lần thêm.
            Console.WriteLine($"Add {i}: Count = {arr.Count}, Capacity = {arr.Capacity}");
        }

        // Đọc phần tử tại index 2 thông qua indexer.
        Console.WriteLine($"Gia tri index 2: {arr[2]}");

        // Cập nhật phần tử tại index 2 thành 99.
        arr[2] = 99;

        Console.WriteLine($"Sau cap nhat: {arr[2]}");

        // Duyệt và in toàn bộ phần tử hợp lệ.
        Console.WriteLine("Mang hien tai:");
        for (int i = 0; i < arr.Count; i++)
        {
            Console.Write(arr[i] + " ");
        }

        Console.WriteLine();

        // Kiểm tra truy cập với index âm.
        try
        {
            Console.WriteLine(arr[-1]);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Loi: index am.");
        }

        // Kiểm tra index bằng Count, không hợp lệ.
        try
        {
            Console.WriteLine(arr[arr.Count]);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Loi: index bang Count.");
        }

        // Kiểm tra capacity âm khi khởi tạo.
        try
        {
            DynamicArray<int> invalid = new DynamicArray<int>(-1);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Loi: capacity am.");
        }
    }
}
