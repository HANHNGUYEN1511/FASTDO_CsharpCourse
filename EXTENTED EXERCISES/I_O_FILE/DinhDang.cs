using System.Globalization;

namespace ChamCongTinhLuong
{
    public static class DinhDang
    {
        // Hiển thị tiền kiểu Việt Nam: 12.520.000
        public static string Tien(decimal soTien)
        {
            return soTien.ToString("N0", new CultureInfo("vi-VN"));
        }

        // Overload: chọn số chữ số thập phân
        public static string Tien(decimal soTien, int soChuSoThapPhan)
        {
            return soTien.ToString("N" + soChuSoThapPhan, new CultureInfo("vi-VN"));
        }
    }
}
