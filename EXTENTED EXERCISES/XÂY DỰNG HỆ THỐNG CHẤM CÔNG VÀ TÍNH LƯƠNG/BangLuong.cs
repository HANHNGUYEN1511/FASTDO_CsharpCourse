namespace HeThongChamCongTinhLuong {
    public class BangLuong
        {
            public NhanVien NhanVien { get; private set; }
            public ChamCong ChamCong { get; private set; }

            public decimal LuongTheoCong { get; private set; }
            public decimal Thuong { get; private set; }
            public decimal TongThuNhap { get; private set; }

            public BangLuong(
                NhanVien nhanVien,
                ChamCong chamCong,
                decimal luongTheoCong,
                decimal thuong,
                decimal tongThuNhap)
            {
                NhanVien = nhanVien;
                ChamCong = chamCong;
                LuongTheoCong = luongTheoCong;
                Thuong = thuong;
                TongThuNhap = tongThuNhap;
            }

            // Overload (nạp chồng): hai cách hiển thị bảng lương.
            public void HienThi()
            {
                HienThi(true);
            }

            public void HienThi(bool hienThiKyLuong)
            {
                Console.WriteLine(
                    $"{NhanVien.MaNhanVien,-6} | " +
                    $"{NhanVien.HoTen,-20} | " +
                    $"{NhanVien.LoaiNhanVien,-10} | " +
                    $"{LuongTheoCong,15:N0} | " +
                    $"{Thuong,12:N0} | " +
                    $"{TongThuNhap,15:N0}" +
                    (hienThiKyLuong
                        ? $" | {ChamCong.Thang:D2}/{ChamCong.Nam}"
                        : ""));
            }
        }
}