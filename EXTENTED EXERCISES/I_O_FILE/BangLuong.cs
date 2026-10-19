using System.Collections.Generic;

namespace ChamCongTinhLuong
{
    // Bảng lương của 1 kỳ: các dòng hợp lệ + các lỗi + số liệu tổng hợp
    public class BangLuong
    {
        private int thang;
        private int nam;
        private List<KetQuaLuong> cacDong = new List<KetQuaLuong>();
        private List<string> cacLoi = new List<string>();

        public BangLuong(int thang, int nam)
        {
            this.thang = thang;
            this.nam = nam;
        }

        public int Thang { get { return thang; } }
        public int Nam { get { return nam; } }
        public List<KetQuaLuong> CacDong { get { return cacDong; } }
        public List<string> CacLoi { get { return cacLoi; } }

        public void ThemDong(KetQuaLuong ketQua) { cacDong.Add(ketQua); }
        public void ThemLoi(string thongBao) { cacLoi.Add(thongBao); }

        public decimal TinhTongQuyLuong()
        {
            decimal tong = 0;
            foreach (KetQuaLuong dong in cacDong) { tong += dong.TongThuNhap; }
            return tong;
        }

        public decimal TinhTongLuongTheoCong()
        {
            decimal tong = 0;
            foreach (KetQuaLuong dong in cacDong) { tong += dong.LuongTheoCong; }
            return tong;
        }

        public decimal TinhTongThuong()
        {
            decimal tong = 0;
            foreach (KetQuaLuong dong in cacDong) { tong += dong.Thuong; }
            return tong;
        }

        // Đếm số nhân viên theo loại, ví dụ "Full-time"
        public int DemTheoLoai(string loai)
        {
            int dem = 0;
            foreach (KetQuaLuong dong in cacDong)
            {
                if (dong.LoaiNhanVien == loai) { dem++; }
            }
            return dem;
        }

        // Tổng thu nhập theo loại nhân viên
        public decimal TinhTongThuNhapTheoLoai(string loai)
        {
            decimal tong = 0;
            foreach (KetQuaLuong dong in cacDong)
            {
                if (dong.LoaiNhanVien == loai) { tong += dong.TongThuNhap; }
            }
            return tong;
        }
    }
}
