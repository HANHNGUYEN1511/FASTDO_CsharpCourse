  /*
      INhanVienTinhLuong
                         ▲
                         │ implements
                  NhanVien (abstract)
                    ▲           ▲
                    │           │
                FullTime     PartTime

NhanVien 1 ─────────── * ChamCong
    │
    └───────────────► BangLuong
                          ▲
                          │ được tạo bởi
                     QuanLyLuong
                          │
             ┌────────────┴────────────┐
             │                         │
         DuLieuMau                  Program 
         */


using System;

namespace HeThongChamCongTinhLuong
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Khởi tạo đối tượng quản lý lương.
            QuanLyLuong quanLy = new QuanLyLuong();

            // 2. Nạp dữ liệu kiểm thử.
            DuLieuMau.NapDuLieu(quanLy);

            // 3. Tính lương toàn bộ nhân viên tháng 09/2026.
            Console.WriteLine("BẢNG LƯƠNG THÁNG 09/2026");

            var bangLuong = quanLy.TinhLuong(9, 2026);

            // 4. Hiển thị bảng lương và thống kê.
            quanLy.HienThiBaoCao(bangLuong);

            // 5. Tính lương riêng cho nhân viên NV01.
            Console.WriteLine("CHI TIẾT LƯƠNG NHÂN VIÊN NV01 THÁNG 09/2026");

            BangLuong luongNV01 = quanLy.TinhLuong("NV01", 9, 2026);

            luongNV01.HienThi(false);

            // 6. Thử thêm chấm công cho nhân viên NV01.
           Console.WriteLine("KIỂM TRA CHẤM CÔNG CHO NHÂN VIÊN NV01 THÁNG 09/2026");

            quanLy.ThemChamCong(new ChamCong("NV01", 9, 2026, 26m, 20m, 2m));

            Console.WriteLine("Đã thêm chấm công cho NV01. Tính lại lương NV01 tháng 09/2026:");

            // 7. Kết thúc chương trình.
           Console.WriteLine("Nhấn phím bất kỳ để kết thúc chương trình...");
           Console.ReadKey();
        }
    }
}
