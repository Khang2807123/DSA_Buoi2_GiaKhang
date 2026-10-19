using System;
class DSABuoi2_Bai1
{
    //tạo hàm tính tổng mảng
    static int Tong(int[] a)
    {
        //đặt biến lưu trữ tổng
        int ans = 0;
        //đặt hàm for để chạy qua hết các giá trị của mảng
        for (int i = 0; i <= a.Length-1; i++)
        {
            //cộng từng phần tử của mảng vào biến tổng
            ans += a[i];
        }
        return ans;
    }
    //tạo hàm tìm giá trị nhỏ nhất của mảng
    static int Min(int[] a)
    {
        //đặt biến min để tiện so sánh
        int min = a[0];
        //đặt hàm for để chạy lần lượt 1 lần qua các phần tử mảng
        for (int i = 0; i <= a.Length - 1; i++)
        {
            //đặt ràng buộc nếu min > phần tử kế tiếp thì phần tử đó sẽ là phần tử nhỏ nhất
            //ngược lại thì phần tử nhỏ nhất giữ nguyên
            if (min > a[i])
            {
                min = a[i];
            }
        }
        return min;
    }
    //tạo hàm tìm giá trị lớn nhất của mảng
    static int Max(int[] a)
    {
        //đặt biến lưu trữ giá trị max
        int max = 0;
        //gọi hàm for để chạy 1 lượt qua các giá trị trong mảng
        for (int i = 0; i <= a.Length - 1; i++)
        {
            //đặt ràng buộc nếu max < 1 phần tử kế tiếp thì phần tử đó sẽ là phần tử lớn nhất
            //ngược lại thì phần tử lớn nhất giữ nguyên
            if (max < a[i])
            {
                max = a[i];
            }
        }
        return max;
    }
    //tạo hàm tính trung bình cộng của các phần tử
    static decimal AVG(int[] a)
    {
        //khởi tạo biến lưu trữ giá trị trung bình
        decimal tb = 0;
        //đặt hàm for để duyệt 1 lượt qua các phần tử
        for (int i = 0; i <= a.Length - 1; i++)
        {
            tb += a[i];
        }
        //trả về giá trị trung bình làm tròn 2 chữ số
        return Math.Round(tb / a.Length, 2);
    }
    //tạo hàm đếm số âm
    static int DemSoAm(int[] a)
    {
        //khởi tạo biến đếm số âm
        int SoAmCount = 0;
        //duyệt qua 1 lượt các phần tử trong mảng bằng hàm for
        for (int i = 0; i <= a.Length - 1; i++)
        {
            //đặt ràng buộc với mỗi phần tử là số âm thì biến đếm sẽ cộng thêm 1
            if (a[i] < 0)
            {
                SoAmCount += 1;
            }
        }
        return SoAmCount;
    }
    //tạo hàm đếm số dương
    static int DemSoDuong(int[] a)
    {
        //khởi tạo biến đếm số dương
        int SoDuongCount = 0;
        //duyệt qua 1 lượt các phần tử trong mảng bằng hàm for
        for (int i = 0; i <= a.Length - 1; i++)
        {
            //đặt ràng buộc với mỗi phần tử là số dương thì biến đếm sẽ cộng thêm 1
            if (a[i] > 0)
            {
                SoDuongCount += 1;
            }
        }
        return SoDuongCount;
    }
    //tạo hàm đếm số 0
    static int DemSo0(int[] a)
    {
        //khởi tạo biến đếm số dương
        int So0Count = 0;
        //duyệt qua 1 lượt các phần tử trong mảng bằng hàm for
        for (int i = 0; i <= a.Length - 1; i++)
        {
            //đặt ràng buộc với mỗi phần tử là số 0 thì biến đếm sẽ cộng thêm 1
            if (a[i] == 0)
            {
                So0Count += 1;
            }
        }
        return So0Count;
    }
    //tạo hàm reverse mảng
    static void ArrReverse(int[] a)
    {
        //khai báo index ở 2 đầu
        int left = 0;
        int right = a.Length - 1;
        string ans = "";
        while (left < right)
        {
            int temp = a[left];
            a[left] = a[right];
            a[right] = temp;
            left++;
            right--;
        }
        for (int i = 0; i <= a.Length - 1; i++)
        {
            ans += a[i] + " ";
        }
        Console.WriteLine($"The reverse array is: {ans}");
    }
    static void Main1(string[] args)
    {
        int[] a = new int[100000];
        a = [ -5, -2, 0, 3, 7, -1, 0, 10, -8,4,2,7 ];
        Console.WriteLine($"The sum of the array is {Tong(a)}");
        Console.WriteLine($"The average of the array is {AVG(a)}");
        Console.WriteLine($"The max of the array is {Max(a)}");
        Console.WriteLine($"The min of the array is {Min(a)}");
        Console.WriteLine($"The positive number count of the array is {DemSoDuong(a)}");
        Console.WriteLine($"The negative number count of the array is {DemSoAm(a)}");
        Console.WriteLine($"The number 0 count of the array is {DemSo0(a)}");
        Array.Reverse(a);
    }
}

