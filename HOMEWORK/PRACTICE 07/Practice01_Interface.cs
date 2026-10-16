// /*Bài 3.4.2 — Một lớp triển khai đồng thời hai interface (Khó)
// Đề bài: Định nghĩa hai interface độc lập: ISoSanhDiem với phương thức int
// SoSanh(HocSinh k) (trả về 1 nếu điểm của đối tượng hiện tại lớn hơn k, -1 nếu nhỏ
// hơn, 0 nếu bằng), và IHienThiHocSinh với phương thức void HienThi(). Xây dựng
// lớp HocSinh (có họ tên và điểm) triển khai ĐỒNG THỜI cả hai interface trên (một
// điều C# không cho phép làm với kế thừa lớp, vì một lớp chỉ được kế thừa một lớp
// cơ sở, nhưng có thể triển khai nhiều interface). Viết Main tạo hai học sinh, hiển thị
// thông tin từng em rồi so sánh điểm để in ra học sinh có điểm cao hơn*/
// public class Practice01_Interface
// {
//     public static void Main()
//     {
//         // Tạo hai học sinh
//         HocSinh hs1 = new HocSinh("Nguyen A", 8.5);
//         HocSinh hs2 = new HocSinh("Tran B", 7.5);

//         // Hiển thị thông tin
//         Console.WriteLine("Học sinh 1");
//         hs1.HienThi();

//         Console.WriteLine("Học sinh 2");
//         hs2.HienThi();

//         // So sánh điểm
//         int ketQua = hs1.SoSanh(hs2);

//         Console.WriteLine("Kết quả so sánh");

//         if (ketQua == 1)
//         {
//             Console.WriteLine(hs1.HoTen + " có điểm cao hơn.");
//         }
//         else if (ketQua == -1)
//         {
//             Console.WriteLine(hs2.HoTen + " có điểm cao hơn.");
//         }
//         else
//         {
//             Console.WriteLine("Hai học sinh có điểm bằng nhau.");
//         }
//     }
// }
// // Interface 1: So sanh diem
// interface ISoSanhDiem
// {
//     int SoSanh(HocSinh k);
// }

// // Interface 2: Hien thi hoc sinh
// interface IHienThiHocSinh
// {
//     void HienThi();
// }

// // Lop HocSinh trien khai ca 2 interface
// class HocSinh : ISoSanhDiem, IHienThiHocSinh
// {
//     // Thuoc tinh
//     public string HoTen { get; set; }
//     public double Diem { get; set; }

//     // Ham khoi tao
//     public HocSinh(string hoTen, double diem)
//     {
//         HoTen = hoTen;
//         Diem = diem;
//     }

//     // Cai dat phuong thuc HienThi()
//     public void HienThi()
//     {
//         Console.WriteLine("Ho ten: " + HoTen);
//         Console.WriteLine("Diem: " + Diem);
//     }

//     // Cai dat phuong thuc SoSanh()
//     public int SoSanh(HocSinh k) // k là đối tượng học sinh khác để so sánh 
//     {
//         if (Diem > k.Diem)
//         {
//             return 1;
//         }
//         else if (Diem < k.Diem)
//         {
//             return -1;
//         }
//         else
//         {
//             return 0;
//         }
//     }
// }

