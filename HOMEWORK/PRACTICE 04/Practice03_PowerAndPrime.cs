// /* Bài 2.3.3 — Kết hợp hàm tính lũy thừa và hàm kiểm tra số nguyên tố
// (Khó)
// Đề bài: Viết 2 phương thức:
// • LuyThua(int x, int y): tính x mũ y (với y >= 0) bằng vòng lặp `for`,
// không dùng Math.Pow;
// • LaSoNguyenTo(int n): trả về bool cho biết n có phải là số nguyên tố hay
// không.
// Trong Main, dùng vòng lặp duyệt các số từ 2 đến 20; với mỗi số nguyên tố tìm được
// (gọi LaSoNguyenTo), in ra số đó cùng với bình phương của nó (gọi LuyThua(n, 2)).*/
// public class Practice03_PowerAndPrime
// {
//     // Method to calculate power of a number
//     static int Power(int x, int y)
//     {
//         int result = 1;

//         for (int i = 1; i <= y; i++)
//         {
//             result = result * x;
//         }

//         return result;
//     }

//     // Method to check if a number is prime
//     static bool isPrimeNumber(int n)
//     {
//         if (n < 2)
//         {
//             return false;
//         }

//         for (int i = 2; i < n; i++)
//         {
//             if (n % i == 0)
//             {
//                 return false;
//             }
//         }

//         return true;
//     }

//     public static void Main(string[] args)
//     {
//         for (int n = 2; n <= 20; n++)
//         {
//             if (isPrimeNumber(n))
//             {
//                 int square = Power(n, 2);

//                 Console.WriteLine($"{n} - Bình phương: {square}");
//             }
//         }
//     }
// }