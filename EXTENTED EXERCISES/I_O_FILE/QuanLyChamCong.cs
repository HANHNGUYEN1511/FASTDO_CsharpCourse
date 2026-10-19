using System.Collections.Generic;

namespace ChamCongTinhLuong
{
    public class QuanLyChamCong
    {
        private List<ChamCong> danhSachChamCong = new List<ChamCong>();

        // Không cho 2 bản ghi cùng MNV + tháng + năm
        public bool ThemChamCong(ChamCong chamCongMoi, out string thongBaoLoi)
        {
            if (TimChamCong(chamCongMoi.MaNV, chamCongMoi.Thang, chamCongMoi.Nam) != null)
            {
                thongBaoLoi = "Nhân viên " + chamCongMoi.MaNV + " đã có chấm công tháng "
                    + chamCongMoi.Thang + "/" + chamCongMoi.Nam + " (nhập trùng)";
                return false;
            }
            danhSachChamCong.Add(chamCongMoi);
            thongBaoLoi = "";
            return true;
        }

        // Không thấy thì trả về null
        public ChamCong TimChamCong(string maNV, int thang, int nam)
        {
            foreach (ChamCong cc in danhSachChamCong)
            {
                if (cc.MaNV == maNV && cc.Thang == thang && cc.Nam == nam)
                {
                    return cc;
                }
            }
            return null;
        }
    }
}
