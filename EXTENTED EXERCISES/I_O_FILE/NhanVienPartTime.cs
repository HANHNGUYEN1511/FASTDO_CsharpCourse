namespace ChamCongTinhLuong
{
    public class NhanVienPartTime : NhanVien
    {
        // Với Part-time, luongCoBan chính là lương theo giờ
        public NhanVienPartTime(string maNV, string hoTen, decimal luongTheoGio)
            : base(maNV, hoTen, luongTheoGio)
        {
        }

        public override string LoaiNhanVien { get { return "Part-time"; } }

        // (Công ca + Công OT) x Lương theo giờ
        public override decimal TinhLuongTheoCong(ChamCong chamCong)
        {
            return (chamCong.CongCa + chamCong.CongOT) * LuongCoBan;
        }

        // Không override TinhThuong: dùng thưởng mặc định = 0 của lớp cha

        public override bool KiemTraThuNhap(decimal tongThuNhap, out string thongBaoLoi)
        {
            if (tongThuNhap >= 1000000)
            {
                thongBaoLoi = "Tổng thu nhập Part-time phải < 1.000.000đ (tính được " + DinhDang.Tien(tongThuNhap) + "đ)";
                return false;
            }
            thongBaoLoi = "";
            return true;
        }
    }
}
