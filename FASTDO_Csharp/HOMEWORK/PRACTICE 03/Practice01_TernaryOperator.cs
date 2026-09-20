// /* Bài 1.9.4 — Phân loại số nguyên bằng toán tử ba ngôi, kết hợp
// typeof/sizeof (Khó)
// Đề bài: Viết chương trình nhận vào một số nguyên từ bàn phím, dùng toán tử
// điều kiện ba ngôi (?:, có thể lồng nhau) để xác định số đó là "duong", "am" hay
// "khong" mà không dùng lệnh if. Sau đó, in ra kiểu dữ liệu của biến vừa nhập bằng
// toán tử typeof, và kích thước (byte) của kiểu đó bằng toán tử sizeof.
// */
// public class Practice01_TernaryOperator
// {
//     public static void Main(string[] args)
//     {
//         // Prompt the user to enter an integer
//         Console.Write("Please enter an integer: ");
//         int number2 = int.TryParse(Console.ReadLine(), out int parsedNumber) ? parsedNumber : 0;     // Mục đích TryParse: Chuyển chuỗi thành int. Chuỗi có thể không hợp lệ
//         // int number2 = int.Parse(Console.ReadLine());                                                 // Mục đích Parse: Chuyển chuỗi thành int. Chuỗi phải hợp lệ
//         // int number2 = Convert.ToInt32(Console.ReadLine());                                           // Mục đích Convert: Chuyển đổi dữ liệu. (Shorter of below two lines)

//         // // Convert.ToInt32: Chuyển đổi dữ liệu sang kiểu int. Nếu chuỗi không hợp lệ, sẽ ném ra ngoại lệ FormatException (Detailed)
//         // string number1 = Console.ReadLine();
//         // int number2 = Convert.ToInt32(number1);

//         // Use the ternary operator to classify the number as "duong", "am", or "khong"
//         string classification = (number2 > 0) ? "duong" : (number2 < 0) ? "am" : "khong";

//         // Print the classification result
//         Console.WriteLine($"The number {number2} is classified as: {classification}");

//         // Print the type of the variable and its size in bytes
//         Console.WriteLine($"Type of the variable: {typeof(int)}");
//         Console.WriteLine($"Size of the variable in bytes: {sizeof(int)}");
//     }
// }