namespace ChamCongTinhLuong
{
    // Kết quả lương của 1 nhân viên trong 1 kỳ
    public class KetQuaLuong
    {
        private string maNV;
        private string hoTen;
        private string loaiNhanVien;
        private decimal luongTheoCong;
        private decimal thuong;
        private decimal tongThuNhap;

        public KetQuaLuong(string maNV, string hoTen, string loaiNhanVien,
                           decimal luongTheoCong, decimal thuong, decimal tongThuNhap)
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
            this.loaiNhanVien = loaiNhanVien;
            this.luongTheoCong = luongTheoCong;
            this.thuong = thuong;
            this.tongThuNhap = tongThuNhap;
        }

        public string MaNV { get { return maNV; } }
        public string HoTen { get { return hoTen; } }
        public string LoaiNhanVien { get { return loaiNhanVien; } }
        public decimal LuongTheoCong { get { return luongTheoCong; } }
        public decimal Thuong { get { return thuong; } }
        public decimal TongThuNhap { get { return tongThuNhap; } }
    }
}
