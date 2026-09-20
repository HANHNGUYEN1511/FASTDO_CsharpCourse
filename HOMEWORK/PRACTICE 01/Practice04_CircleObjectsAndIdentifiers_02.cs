// /* Bài 1.4.2 — Hai đối tượng HinhTron và quy tắc đặt định danh (Khó)
// Đề bài: Viết lớp HinhTron có biến thành viên công khai (public) banKinh (kiểu
// double), phương thức TinhDienTich() trả về diện tích (banKinh * banKinh * 3.14),
// phương thức TinhChuVi() trả về chu vi (2 * 3.14 * banKinh), và phương thức
// Display() in cả 3 giá trị. Trong class chứa Main, hãy tạo 2 đối tượng HinhTron với
// bán kính khác nhau (gán trực tiếp vào biến banKinh của mỗi đối tượng), in kết quả
// của từng đối tượng. Đồng thời, viết chú thích liệt kê ví dụ về 2 định danh (tên biến)
// hợp lệ và 2 định danh không hợp lệ theo đúng quy tắc đặt tên đã học.*/

// public class Practice04_CircleObjectsAndIdentifiers_02
// {
//     public static void Main(string[] args)
//     {
//         // Method 2: Create the instance of the Circle class    
//         Circle circle = new Circle();
//         circle.r = double.Parse(Console.ReadLine());            // Read the radius from user input

//         Console.Write("Please enter the radius of the circle: " + " cm");
//         Console.WriteLine("Area: " + circle.circleArea() + " cm²");
//     }
// }
// public class Circle
// {
//     public double r;
//     //Create method to calculate the area of the circle
//     public double circleArea()
//     {
//         return r * r * Math.PI;
//     }
// }