using System;
using System.Collections.Generic;

namespace ChamCongTinhLuong
{
    // Chỉ làm việc với kiểu NhanVien (đa hình): không cần biết là Full-time hay Part-time
    public class BoTinhLuong
    {
        // Overload 1: tính lương cho MỘT nhân viên
        public bool TinhLuong(NhanVien nhanVien, ChamCong chamCong, out KetQuaLuong ketQua, out string thongBaoLoi)
        {
            ketQua = null;
            decimal tongThuNhap;

            if (nhanVien.TinhTongThuNhap(chamCong, out tongThuNhap, out thongBaoLoi) == false)
            {
                return false;
            }

            ketQua = new KetQuaLuong(nhanVien.MaNV, nhanVien.HoTen, nhanVien.LoaiNhanVien,
                                     nhanVien.TinhLuongTheoCong(chamCong), nhanVien.TinhThuong(), tongThuNhap);
            return true;
        }

        // Overload 2: tính lương cho DANH SÁCH nhân viên. Người bị lỗi được ghi lại, không tính vào quỹ lương
        public BangLuong TinhLuong(List<NhanVien> danhSach, QuanLyChamCong quanLyChamCong, int thang, int nam)
        {
            BangLuong bangLuong = new BangLuong(thang, nam);

            foreach (NhanVien nv in danhSach)
            {
                ChamCong cc = quanLyChamCong.TimChamCong(nv.MaNV, thang, nam);
                KetQuaLuong ketQua;
                string loi;

                if (TinhLuong(nv, cc, out ketQua, out loi))
                {
                    bangLuong.ThemDong(ketQua);
                }
                else
                {
                    bangLuong.ThemLoi(nv.MaNV + " - " + nv.HoTen + ": " + loi);
                }
            }
            return bangLuong;
        }

        // In bảng lương ra màn hình
        public void InBangLuong(BangLuong bangLuong)
        {
            Console.WriteLine("===== BẢNG LƯƠNG THÁNG " + bangLuong.Thang.ToString("00") + "/" + bangLuong.Nam + " =====");
            Console.WriteLine("MNV".PadRight(6) + "Họ và tên".PadRight(18) + "Loại".PadRight(11)
                + "Lương theo công".PadLeft(16) + "Thưởng".PadLeft(12) + "Tổng thu nhập".PadLeft(16));
            Console.WriteLine(new string('-', 79));

            if (bangLuong.CacDong.Count == 0)
            {
                Console.WriteLine("(Không có nhân viên nào hợp lệ để hiển thị)");
            }

            foreach (KetQuaLuong dong in bangLuong.CacDong)
            {
                Console.WriteLine(dong.MaNV.PadRight(6) + dong.HoTen.PadRight(18) + dong.LoaiNhanVien.PadRight(11)
                    + DinhDang.Tien(dong.LuongTheoCong).PadLeft(16)
                    + DinhDang.Tien(dong.Thuong).PadLeft(12)
                    + DinhDang.Tien(dong.TongThuNhap).PadLeft(16));
            }

            Console.WriteLine(new string('-', 79));
            Console.WriteLine("Số nhân viên Full-time  : " + bangLuong.DemTheoLoai("Full-time"));
            Console.WriteLine("Số nhân viên Part-time  : " + bangLuong.DemTheoLoai("Part-time"));
            Console.WriteLine("Tổng thu nhập Full-time : " + DinhDang.Tien(bangLuong.TinhTongThuNhapTheoLoai("Full-time")) + "đ");
            Console.WriteLine("Tổng thu nhập Part-time : " + DinhDang.Tien(bangLuong.TinhTongThuNhapTheoLoai("Part-time")) + "đ");
            Console.WriteLine("Tổng lương theo công    : " + DinhDang.Tien(bangLuong.TinhTongLuongTheoCong()) + "đ");
            Console.WriteLine("Tổng thưởng             : " + DinhDang.Tien(bangLuong.TinhTongThuong()) + "đ");
            Console.WriteLine("TỔNG QUỸ LƯƠNG          : " + DinhDang.Tien(bangLuong.TinhTongQuyLuong()) + "đ");

            if (bangLuong.CacLoi.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("CÓ " + bangLuong.CacLoi.Count + " NHÂN VIÊN KHÔNG TÍNH ĐƯỢC LƯƠNG (không vào quỹ lương):");
                foreach (string loi in bangLuong.CacLoi)
                {
                    Console.WriteLine("  - " + loi);
                }
            }
        }
    }
}
