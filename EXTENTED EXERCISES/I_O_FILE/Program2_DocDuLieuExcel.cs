using System;
using System.Collections.Generic;
using System.IO;
using ClosedXML.Excel;

namespace ChamCongTinhLuong
{
    class Program2_DocDuLieuExcel
    {
        // Đường dẫn file Excel dữ liệu đầu vào
        private const string DuongDanFile =
            @"D:\IdeaProjects\FASTDO_CsharpCourse\EXTENTED EXERCISES\I_O_FILE\DuLieuChamCongTinhLuong.xlsx";

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int thang = 9;
            int nam = 2026;

            if (File.Exists(DuongDanFile) == false)
            {
                Console.WriteLine("Không tìm thấy file: " + DuongDanFile);
                return;
            }

            // 1. Đọc dữ liệu từ Excel
            QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();
            QuanLyChamCong quanLyChamCong = new QuanLyChamCong();
            List<string> cacLoiDoc = new List<string>();

            // Mở file chỉ đọc và cho phép chương trình khác cùng dùng (Excel đang mở cũng không sao)
            FileStream luongFile = new FileStream(DuongDanFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            XLWorkbook sach = new XLWorkbook(luongFile);
            luongFile.Close();
            if (sach.Worksheets.Count < 2)
            {
                Console.WriteLine("File Excel cần có 2 sheet: sheet 1 = nhân viên, sheet 2 = chấm công.");
                return;
            }
            DocGhiExcel.DocNhanVien(sach, quanLyNhanVien, cacLoiDoc);
            DocGhiExcel.DocChamCong(sach, quanLyChamCong, cacLoiDoc);

            Console.WriteLine("Đã đọc " + quanLyNhanVien.DanhSachNhanVien.Count + " nhân viên từ file Excel.");
            if (cacLoiDoc.Count > 0)
            {
                Console.WriteLine("CÁC DÒNG BỊ BỎ QUA KHI ĐỌC FILE:");
                foreach (string loi in cacLoiDoc)
                {
                    Console.WriteLine("  - " + loi);
                }
            }
            Console.WriteLine();

            // 2. Tính lương và in ra màn hình
            BoTinhLuong boTinhLuong = new BoTinhLuong();
            BangLuong bangLuong = boTinhLuong.TinhLuong(quanLyNhanVien.DanhSachNhanVien, quanLyChamCong, thang, nam);
            boTinhLuong.InBangLuong(bangLuong);

            // 3. Ghi kết quả ra file Excel mới (cùng thư mục, không đè lên file gốc)
            string thuMuc = Path.GetDirectoryName(DuongDanFile);
            string duongDanKetQua = Path.Combine(thuMuc, "KetQuaTinhLuong_" + thang.ToString("00") + "_" + nam + ".xlsx");
            DocGhiExcel.GhiBangLuong(duongDanKetQua, bangLuong);
            Console.WriteLine();
            Console.WriteLine("Đã ghi bảng lương ra file: " + duongDanKetQua);

            // 4. Kiểm thử các trường hợp lỗi
            ChayKiemThuLoi();

            Console.WriteLine();
            Console.WriteLine("Nhấn Enter để thoát...");
            Console.ReadLine();
        }

        // Dữ liệu tự tạo trong code để thử các lỗi: trùng chấm công, công âm, công chuẩn = 0, vượt ngưỡng, thiếu chấm công
        static void ChayKiemThuLoi()
        {
            Console.WriteLine();
            Console.WriteLine("================ KIỂM THỬ LỖI ================");

            QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();
            QuanLyChamCong quanLyChamCong = new QuanLyChamCong();
            string loi;

            quanLyNhanVien.ThemNhanVien(new NhanVienFullTime("T01", "Test công âm", 13000000m, 65000m, 10m), out loi);
            quanLyNhanVien.ThemNhanVien(new NhanVienFullTime("T02", "Test công chuẩn 0", 13000000m, 65000m, 10m), out loi);
            quanLyNhanVien.ThemNhanVien(new NhanVienPartTime("T03", "Test PT vượt ngưỡng", 60000m), out loi);
            quanLyNhanVien.ThemNhanVien(new NhanVienFullTime("T04", "Test FT quá thấp", 13000000m, 65000m, 0m), out loi);
            quanLyNhanVien.ThemNhanVien(new NhanVienFullTime("T05", "Test thiếu chấm công", 13000000m, 65000m, 10m), out loi);
            quanLyNhanVien.ThemNhanVien(new NhanVienFullTime("T06", "Test FT hợp lệ", 13000000m, 65000m, 10m), out loi);
            quanLyNhanVien.ThemNhanVien(new NhanVienPartTime("T07", "Test PT hợp lệ", 50000m), out loi);
            quanLyNhanVien.ThemNhanVien(new NhanVienPartTime("T05", "Test trùng mã", 50000m), out loi);
            Console.WriteLine("Thêm nhân viên trùng mã -> " + loi);

            quanLyChamCong.ThemChamCong(new ChamCong("T01", 9, 2026, 26m, -1m, 0m), out loi);
            quanLyChamCong.ThemChamCong(new ChamCong("T02", 9, 2026, 0m, 10m, 0m), out loi);
            quanLyChamCong.ThemChamCong(new ChamCong("T03", 9, 2026, 26m, 20m, 0m), out loi);  // 1.200.000 >= 1.000.000
            quanLyChamCong.ThemChamCong(new ChamCong("T04", 9, 2026, 26m, 1m, 0m), out loi);   // 500.000 <= 1.000.000
            quanLyChamCong.ThemChamCong(new ChamCong("T04", 9, 2026, 26m, 5m, 0m), out loi);   // trùng tháng/năm
            Console.WriteLine("Thêm chấm công trùng tháng -> " + loi);
            quanLyChamCong.ThemChamCong(new ChamCong("T06", 9, 2026, 26m, 24m, 8m), out loi);  // hợp lệ
            quanLyChamCong.ThemChamCong(new ChamCong("T07", 9, 2026, 26m, 10m, 5m), out loi);  // hợp lệ
            Console.WriteLine();

            BoTinhLuong boTinhLuong = new BoTinhLuong();
            BangLuong bangLuong = boTinhLuong.TinhLuong(quanLyNhanVien.DanhSachNhanVien, quanLyChamCong, 9, 2026);
            boTinhLuong.InBangLuong(bangLuong);
        }
    }
}
