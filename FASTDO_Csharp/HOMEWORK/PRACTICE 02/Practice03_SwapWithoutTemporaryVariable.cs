// /*Bài 1.7.3 — Hoán đổi giá trị 2 biến không dùng biến trung gian (Khó)
// Đề bài: Cho 2 biến int a = 5; và int b = 10;. Hãy viết chương trình hoán đổi
// (tráo đổi) giá trị của a và b cho nhau mà không được khai báo thêm bất kỳ
// biến thứ 3 nào, chỉ được dùng các phép toán cộng và trừ. In giá trị của a, b trước
// và sau khi hoán đổi.*/

// partial class Practice03_SwapWithoutTemporaryVariable
// {
//     public static void Main(string[] args)
//     {
//         // Step 1: Declare and initialize two integer variables
//         int a = 4;
//         int b = 6;

//         // Print the values before swapping
//         Console.WriteLine($"Before swapping: a = {a}, b = {b}");

//         // Step 2: Swap the values using addition and subtraction
//         a = a + b; // Now a contains the sum of a and b
//         b = a - b; // Now b contains the original value of a
//         a = a - b; // Now a contains the original value of b
//         b = a - b; // Now b contains the original value of a

//         // Print the values after swapping
//         Console.WriteLine($"After swapping: a = {a}, b = {b}");
//     }
// }