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
            Console.WriteLine("BẢNG LƯƠNG THÁNG 09/2026 \n");

            var bangLuong = quanLy.TinhLuong(9, 2026);

            // 4. Hiển thị bảng lương và thống kê.
            quanLy.HienThiBaoCao(bangLuong);

            // 5. Tính lương riêng cho nhân viên 
            Console.WriteLine("--------------------------------\n");
            Console.WriteLine("LƯƠNG NHÂN VIÊN NGUYỄN VĂN AN-THÁNG 09/2026 \n");

            BangLuong luongNV01 = quanLy.TinhLuong("NV01", 9, 2026);
            // BangLuong luongNV02 = quanLy.TinhLuong("NV02", 9, 2026);
            // BangLuong luongNV03 = quanLy.TinhLuong("NV03", 9, 2026);
            // BangLuong luongNV04 = quanLy.TinhLuong("NV04", 9, 2026);
            // BangLuong luongNV05 = quanLy.TinhLuong("NV05", 9, 2026);
            // BangLuong luongNV06 = quanLy.TinhLuong("NV06", 9, 2026);
            // BangLuong luongNV07 = quanLy.TinhLuong("NV07", 9, 2026);
            // BangLuong luongNV08 = quanLy.TinhLuong("NV08", 9, 2026);
            // BangLuong luongNV09 = quanLy.TinhLuong("NV09", 9, 2026);
            // BangLuong luongNV10 = quanLy.TinhLuong("NV10", 9, 2026);
            luongNV01.HienThi(false);
            // luongNV02.HienThi(false);
            // luongNV03.HienThi(false);
            // luongNV04.HienThi(false);
            // luongNV05.HienThi(false);
            // luongNV06.HienThi(false);
            // luongNV07.HienThi(false);
            // luongNV08.HienThi(false);
            // luongNV09.HienThi(false);
            // luongNV10.HienThi(false);
        }
    }
}
