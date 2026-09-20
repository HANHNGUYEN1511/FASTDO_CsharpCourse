// /* Bài 2.2.2 — Lớp TaiKhoan mô phỏng giao dịch ngân hàng (Khó)
// Đề bài: Viết lớp TaiKhoan chỉ có 1 trường private: soDu (double, giá trị khởi tạo
// mặc định là 0). Cung cấp các phương thức public:
// • NapTien(double soTien): chỉ cộng vào soDu nếu soTien > 0, ngược lại in ra
// thông báo lỗi và không thay đổi số dư;
// • RutTien(double soTien): chỉ trừ vào soDu nếu soTien > 0 và soTien <= soDu,
// ngược lại in thông báo lỗi tương ứng ("số tiền không hợp lệ" hoặc "số dư không
// đủ");
// • XemSoDu(): in ra số dư hiện tại.
// Trong Main, thực hiện lần lượt: nạp 500000, rút 200000, rút 1000000 (vượt số dư),
// nạp -100 (không hợp lệ), rồi xem số dư cuối cùng.*/
// public class TaiKhoan
// {
//     private double soDu = 0; // Trường private soDu với giá trị khởi tạo mặc định là 0

//     public void NapTien(double soTien)
//     {
//         if (soTien > 0)
//         {
//             soDu += soTien; // Cộng vào soDu nếu soTien > 0
//         }
//         else
//         {
//             Console.WriteLine("The amount to deposit is not valid."); // Thông báo lỗi nếu soTien <= 0
//         }
//     }

//     public void RutTien(double soTien)
//     {
//         if (soTien <= 0)
//         {
//             Console.WriteLine("The amount to withdraw is not valid."); // Thông báo lỗi nếu soTien <= 0
//         }
//         else if (soTien > soDu)
//         {
//             Console.WriteLine("The amount to withdraw exceeds the account balance."); // Thông báo lỗi nếu soTien > soDu
//         }
//         else
//         {
//             soDu -= soTien; // Trừ vào soDu nếu điều kiện hợp lệ
//         }
//     }

//     public void XemSoDu()
//     {
//         Console.WriteLine($"The current balance is: {soDu}"); // In ra số dư hiện tại
//     }

//     public static void Main(string[] args)
//     {
//         TaiKhoan taiKhoan = new TaiKhoan();

//         taiKhoan.NapTien(1000000);
//         taiKhoan.RutTien(20000000);
//         taiKhoan.XemSoDu();
//     }
// }