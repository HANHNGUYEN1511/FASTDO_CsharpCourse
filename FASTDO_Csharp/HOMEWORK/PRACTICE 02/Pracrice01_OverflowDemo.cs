// /* Bài 1.5.3 — Hiện tượng tràn số (overflow) khi vượt giới hạn kiểu (Khó)
// Đề bài: Viết chương trình minh họa 2 tình huống tràn số: (1) Gán int max = // 2147483647; (giá trị int lớn nhất), sau đó tính max = max + 1; và in kết quả — quan
// sát điều gì xảy ra. (2) Gán int soLon = 300;, sau đó ép kiểu tường minh byte b = // (byte)soLon; và in giá trị của b — biết rằng byte chỉ lưu được từ 0 đến 255.*/

// public class Pracrice01_OverflowDemo
// {
//     public static void Main()
//     {
//         //Case 1: Overflow when adding 1 to the maximum int value
//         // int max = 2147483647;                        //Method 1: Declare maximum value for int
//         int max = int.MaxValue;                         //Method 2: Assign the maximum value of int to max
//         max = max + 1;                                  //Add 1 to max causes an overflow
//         Console.WriteLine("Giá trị của max sau khi tràn: " + max);

//         //Case 2: Overflow when casting int to byte
//         int num1 = 300; //
//         byte num2 = (byte)num1;                     //Formula of Explicit Conversion (Ép kiểu tường minh)
//         Console.WriteLine("Giá trị của num2 sau khi ép kiểu: " + num2);
//     }
// }