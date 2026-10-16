namespace HeThongChamCongTinhLuong
{
    public abstract class NhanVien : INhanVienTinhLuong
    {
        public string MaNhanVien { get; private set; } //private set: Chỉ code bên trong class NhanVien mới được gán hoặc thay đổi giá trị thông qua thuộc tính này => Cho phép mọi người xem mã nhân viên, nhưng không cho phép code bên ngoài tự ý sửa mã đó
        public string HoTen { get; private set; }
        public decimal LuongCoBan { get; private set; }

        protected NhanVien(
            string maNhanVien,
            string hoTen,
            decimal luongCoBan)
        {
            if (maNhanVien == null || maNhanVien.Trim()=="")
                Console.WriteLine("Mã nhân viên không được để trống.");

            if (hoTen == null || hoTen.Trim() == "")
                Console.WriteLine("Họ tên không được để trống.");

            if (luongCoBan <= 0)
                Console.WriteLine("Lương cơ bản phải lớn hơn 0.");

            MaNhanVien = maNhanVien;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }

        public abstract string LoaiNhanVien { get; }

        // Mỗi loại nhân viên tự triển khai công thức lương theo công.
        protected abstract decimal TinhLuongTheoCong(ChamCong chamCong);

        // Mỗi loại nhân viên tự triển khai quy tắc thưởng.
        protected abstract decimal TinhThuong();

        // Mỗi loại nhân viên tự kiểm tra ngưỡng thu nhập.
        protected abstract void KiemTraTongThuNhap(decimal tongThuNhap);

        public BangLuong TinhLuong(ChamCong chamCong)
        {
            if (chamCong == null)
                Console.WriteLine("Chấm công không được để trống!");
                
            if (chamCong.MaNhanVien != MaNhanVien)
                Console.WriteLine("Bản ghi chấm công không thuộc nhân viên này.");

            decimal luongTheoCong = TinhLuongTheoCong(chamCong);
            decimal thuong = TinhThuong();

            // Chỉ làm tròn một lần ở tổng thu nhập.
            decimal tongThuNhap = decimal.Round(luongTheoCong + thuong, 2);

            KiemTraTongThuNhap(tongThuNhap);

            return new BangLuong(
                this,
                chamCong,
                luongTheoCong,
                thuong,
                tongThuNhap);
        }
    }

    public class FullTime : NhanVien
    {
        public decimal DonGiaOT { get; private set; }
        public decimal TyLeThuong { get; private set; }

        public FullTime(
            string maNhanVien,
            string hoTen,
            decimal luongCoBan,
            decimal donGiaOT,
            decimal tyLeThuong)
            : base(maNhanVien, hoTen, luongCoBan)
        {
            if (donGiaOT < 0)
                Console.WriteLine("Đơn giá OT không được âm.");

            if (tyLeThuong < 0)
                Console.WriteLine("Tỷ lệ thưởng không được âm.");

            DonGiaOT = donGiaOT;
            TyLeThuong = tyLeThuong;
        }

        public override string LoaiNhanVien => "Full-time";

        protected override decimal TinhLuongTheoCong(ChamCong chamCong)
        {
            if (chamCong.CongChuan <= 0)
                Console.WriteLine("Công chuẩn Full-time phải lớn hơn 0.");
            return (LuongCoBan / chamCong.CongChuan)
                * chamCong.CongCa
                + chamCong.CongOT * DonGiaOT;
        }

        protected override decimal TinhThuong()
        {
            return LuongCoBan * TyLeThuong / 100m;
        }

        protected override void KiemTraTongThuNhap(decimal tongThuNhap)
        {
            if (tongThuNhap <= 1_000_000m)
                Console.WriteLine($"Lương Full-time của {MaNhanVien} phải lớn hơn 1.000.000đ.");
        }
    }

    public class PartTime : NhanVien
    {
        public PartTime(
            string maNhanVien,
            string hoTen,
            decimal luongTheoGio)
            : base(maNhanVien, hoTen, luongTheoGio)
        {
        }

        public override string LoaiNhanVien => "Part-time";

        protected override decimal TinhLuongTheoCong(ChamCong chamCong)
        {
            // Công ca và công OT đều tính theo giờ.
            // Đơn giá OT bằng đơn giá giờ thông thường.
            return (chamCong.CongCa + chamCong.CongOT) * LuongCoBan;
        }

        protected override decimal TinhThuong()
        {
            return 0m;
        }

        protected override void KiemTraTongThuNhap(decimal tongThuNhap)
        {
            if (tongThuNhap >= 1_000_000m)
                Console.WriteLine($"Lương Part-time của {MaNhanVien} phải nhỏ hơn 1.000.000đ.");
        }
    } 
}