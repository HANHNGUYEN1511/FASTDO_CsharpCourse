using System.Collections.Generic;

namespace ChamCongTinhLuong
{
    public class QuanLyNhanVien
    {
        private List<NhanVien> danhSachNhanVien = new List<NhanVien>();

        public List<NhanVien> DanhSachNhanVien { get { return danhSachNhanVien; } }

        // Trả về false nếu trùng mã nhân viên
        public bool ThemNhanVien(NhanVien nhanVienMoi, out string thongBaoLoi)
        {
            foreach (NhanVien nv in danhSachNhanVien)
            {
                if (nv.MaNV == nhanVienMoi.MaNV)
                {
                    thongBaoLoi = "Mã nhân viên " + nhanVienMoi.MaNV + " đã tồn tại";
                    return false;
                }
            }
            danhSachNhanVien.Add(nhanVienMoi);
            thongBaoLoi = "";
            return true;
        }
    }
}
