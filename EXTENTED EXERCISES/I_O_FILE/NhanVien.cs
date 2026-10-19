namespace ChamCongTinhLuong
{
    // Lớp trừu tượng: chứa phần chung của mọi nhân viên
    public abstract class NhanVien : ITinhLuong
    {
        private string maNV;
        private string hoTen;
        private decimal luongCoBan;

        public NhanVien(string maNV, string hoTen, decimal luongCoBan)
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
            this.luongCoBan = luongCoBan;
        }

        public string MaNV { get { return maNV; } }
        public string HoTen { get { return hoTen; } }
        protected decimal LuongCoBan { get { return luongCoBan; } }

        public abstract string LoaiNhanVien { get; }

        // Mỗi loại nhân viên BẮT BUỘC tự viết công thức của mình (override)
        public abstract decimal TinhLuongTheoCong(ChamCong chamCong);
        public abstract bool KiemTraThuNhap(decimal tongThuNhap, out string thongBaoLoi);

        // Mặc định không có thưởng. Full-time sẽ override lại
        public virtual decimal TinhThuong()
        {
            return 0;
        }

        // Kiểm tra chấm công: dùng chung cho mọi loại. Lớp con có thể override để thêm điều kiện
        public virtual bool KiemTraChamCong(ChamCong chamCong, out string thongBaoLoi)
        {
            if (chamCong == null)
            {
                thongBaoLoi = "Chưa có dữ liệu chấm công";
                return false;
            }
            if (chamCong.CongChuan < 0 || chamCong.CongCa < 0 || chamCong.CongOT < 0)
            {
                thongBaoLoi = "Công chuẩn, công ca, công OT không được âm";
                return false;
            }
            thongBaoLoi = "";
            return true;
        }

        // Tổng thu nhập = lương theo công + thưởng. Làm tròn MỘT LẦN ở đây
        public decimal TinhTongThuNhap(ChamCong chamCong)
        {
            decimal tong = TinhLuongTheoCong(chamCong) + TinhThuong();
            return System.Math.Round(tong, 0, System.MidpointRounding.AwayFromZero);
        }

        // Overload: tính luôn và kiểm tra hợp lệ. Trả về false + lý do nếu có lỗi (không tự sửa tiền)
        public bool TinhTongThuNhap(ChamCong chamCong, out decimal tongThuNhap, out string thongBaoLoi)
        {
            tongThuNhap = 0;

            if (KiemTraChamCong(chamCong, out thongBaoLoi) == false)
            {
                return false;
            }

            tongThuNhap = TinhTongThuNhap(chamCong);
            return KiemTraThuNhap(tongThuNhap, out thongBaoLoi);
        }
    }
}
