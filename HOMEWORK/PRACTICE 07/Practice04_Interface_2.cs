
// using System;

// public class Practice01_Interface_2
// {
//     public static void Main()
//     {
//         // Nhập thông tin học sinh 3
//         Console.Write("Nhap ho ten hoc sinh 3: ");
//         string hoTen3 = Console.ReadLine();

//         Console.Write("Nhap diem hoc sinh 3: ");
//         double diem3 = Convert.ToDouble(Console.ReadLine());

//         HocSinh hs3 = new HocSinh(hoTen3, diem3);

//         // Nhập thông tin học sinh 4
//         Console.Write("\nNhap ho ten hoc sinh 4: ");
//         string hoTen4 = Console.ReadLine();

//         Console.Write("Nhap diem hoc sinh 4: ");
//         double diem4 = Convert.ToDouble(Console.ReadLine());

//         HocSinh hs4 = new HocSinh(hoTen4, diem4);

//         // Hiển thị thông tin
//         Console.WriteLine("\n=== THONG TIN HOC SINH ===");
//         hs3.HienThi();
//         Console.WriteLine();
//         hs4.HienThi();

//         // So sánh điểm
//         int ketQua = hs3.SoSanh(hs4);

//         Console.WriteLine("\n=== KET QUA SO SANH ===");

//         if (ketQua == 1)
//         {
//             Console.WriteLine(hs3.HoTen + " co diem cao hon.");
//         }
//         else if (ketQua == -1)
//         {
//             Console.WriteLine(hs4.HoTen + " co diem cao hon.");
//         }
//         else
//         {
//             Console.WriteLine("Hai hoc sinh co diem bang nhau.");
//         }
//     }

//     interface ISoSanhDiem
//     {
//         int SoSanh(HocSinh k);
//     }

//     interface IHienThiHocSinh
//     {
//         void HienThi();
//     }

//     class HocSinh : ISoSanhDiem, IHienThiHocSinh
//     {
//         public string HoTen { get; set; }
//         public double Diem { get; set; }

//         public HocSinh(string hoTen, double diem)
//         {
//             HoTen = hoTen;
//             Diem = diem;
//         }

//         public void HienThi()
//         {
//             Console.WriteLine("Ho ten: " + HoTen);
//             Console.WriteLine("Diem: " + Diem);
//         }

//         public int SoSanh(HocSinh k)
//         {
//             if (Diem > k.Diem)
//             {
//                 return 1;
//             }
//             else if (Diem < k.Diem)
//             {
//                 return -1;
//             }
//             else
//             {
//                 return 0;
//             }
//         }
//     }
// }
