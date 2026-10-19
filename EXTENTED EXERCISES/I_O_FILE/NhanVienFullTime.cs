namespace ChamCongTinhLuong
{
    public class NhanVienFullTime : NhanVien
    {
        private decimal donGiaOT;
        private decimal tyLeThuong; // 10 nghĩa là 10%

        public NhanVienFullTime(string maNV, string hoTen, decimal luongCoBan, decimal donGiaOT, decimal tyLeThuong)
            : base(maNV, hoTen, luongCoBan)
        {
            this.donGiaOT = donGiaOT;
            this.tyLeThuong = tyLeThuong;
        }

        public override string LoaiNhanVien { get { return "Full-time"; } }

        // (Lương cơ bản / Công chuẩn) x Công ca + Công OT x Đơn giá OT
        public override decimal TinhLuongTheoCong(ChamCong chamCong)
        {
            return LuongCoBan / chamCong.CongChuan * chamCong.CongCa + chamCong.CongOT * donGiaOT;
        }

        // Thưởng = Lương cơ bản x Tỷ lệ thưởng (%)
        public override decimal TinhThuong()
        {
            return LuongCoBan * tyLeThuong / 100;
        }

        // Full-time có công thức chia cho công chuẩn nên công chuẩn phải > 0
        public override bool KiemTraChamCong(ChamCong chamCong, out string thongBaoLoi)
        {
            if (base.KiemTraChamCong(chamCong, out thongBaoLoi) == false)
            {
                return false;
            }
            if (chamCong.CongChuan <= 0)
            {
                thongBaoLoi = "Công chuẩn phải > 0";
                return false;
            }
            return true;
        }

        public override bool KiemTraThuNhap(decimal tongThuNhap, out string thongBaoLoi)
        {
            if (tongThuNhap <= 1000000)
            {
                thongBaoLoi = "Tổng thu nhập Full-time phải > 1.000.000đ (tính được " + DinhDang.Tien(tongThuNhap) + "đ)";
                return false;
            }
            thongBaoLoi = "";
            return true;
        }
    }
}
