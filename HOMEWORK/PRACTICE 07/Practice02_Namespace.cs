// /*Bài 3.5.2 — Namespace lồng nhau và xung đột tên (Khó)
// Đề bài: Khai báo namespace QuanLyTruongHoc chứa lớp HieuTruong, và bên trong
// nó khai báo thêm hai namespace lồng nhau KhoiCap2 và KhoiCap3, mỗi namespace
// con chứa MỘT lớp CÙNG TÊN HocSinh (khác nội dung phương thức GioiThieu()).
// Trong Main: dùng chỉ thị using QuanLyTruongHoc.KhoiCap2; để có thể gọi thẳng lớp
// HocSinh của khối cấp 2 mà không cần ghi tên đầy đủ, đồng thời vẫn phải dùng tên
// đầy đủ QuanLyTruongHoc.KhoiCap3.HocSinh để truy cập lớp HocSinh của khối cấp 3
// (vì namespace này không được using). In lời giới thiệu của cả ba đối tượng:
// HieuTruong, HocSinh (khối cấp 2), HocSinh (khối cấp 3).*/

// using System;
// using QuanLyTruongHoc.KhoiCap2; // Dùng using để truy cập lớp HocSinh của khối cấp 2
// // Lớp thực hành
// public class Practice02_Namespace
// {
//     static void Main(string[] args)
//     {
//         // 1. Tạo đối tượng Hiệu trưởng
//         QuanLyTruongHoc.HieuTruong hieuTruong =
//             new QuanLyTruongHoc.HieuTruong();

//         // 2. Tạo đối tượng Học sinh khối cấp 2
//         HocSinh hocSinhCap2 = new HocSinh();

//         // 3. Tạo đối tượng Học sinh khối cấp 3
//         QuanLyTruongHoc.KhoiCap3.HocSinh hocSinhCap3 =
//             new QuanLyTruongHoc.KhoiCap3.HocSinh();

//         // 4. In lời giới thiệu của cả ba đối tượng
//         Console.WriteLine("===== GIOI THIEU =====");

//         hieuTruong.GioiThieu();

//         hocSinhCap2.GioiThieu();

//         hocSinhCap3.GioiThieu();
//     }
// }

// // Namespace quản lý trường học
// namespace QuanLyTruongHoc
// {
//     // Lớp Hiệu trưởng
//     public class HieuTruong
//     {
//         public void GioiThieu()
//         {
//             Console.WriteLine("Toi la hieu truong cua truong hoc.");
//         }
//     }

//     // Namespace dành cho học sinh khối cấp 2
//     namespace KhoiCap2
//     {
//         public class HocSinh
//         {
//             public void GioiThieu()
//             {
//                 Console.WriteLine("Toi la hoc sinh khoi cap 2.");
//             }
//         }
//     }

//     // Namespace dành cho học sinh khối cấp 3
//     namespace KhoiCap3
//     {
//         public class HocSinh
//         {
//             public void GioiThieu()
//             {
//                 Console.WriteLine("Toi la hoc sinh khoi cap 3.");
//             }
//         }
//     }
// }


  
