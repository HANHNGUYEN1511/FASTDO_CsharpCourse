using System;
using System.Collections.Generic;
using System.Globalization;
using ClosedXML.Excel;

namespace ChamCongTinhLuong
{
    // Đọc dữ liệu từ file Excel và ghi bảng lương ra file Excel
    //
    // Cấu trúc file đầu vào (dòng 1 là tiêu đề, dữ liệu từ dòng 2):
    //   Sheet 1 (nhân viên): A=MNV | B=Họ tên | C=Loại | D=Lương cơ bản | E=OT/giờ | F=Thưởng (%)
    //   Sheet 2 (chấm công): A=MNV | B=Tháng | C=Năm | D=Công chuẩn | E=Công ca | F=Giờ OT
    public static class DocGhiExcel
    {
        // Thay vì if/else hay switch: tra "loại nhân viên" trong từ điển để biết tạo đối tượng nào.
        // Thêm loại mới (ví dụ hợp đồng) chỉ cần thêm 1 dòng vào đây.
        private static Dictionary<string, Func<string, string, decimal, decimal, decimal, NhanVien>> cacLoaiNhanVien
            = new Dictionary<string, Func<string, string, decimal, decimal, decimal, NhanVien>>
        {
            { "full-time", (ma, ten, luong, ot, thuong) => new NhanVienFullTime(ma, ten, luong, ot, thuong) },
            { "part-time", (ma, ten, luong, ot, thuong) => new NhanVienPartTime(ma, ten, luong) }
        };

        // ---------------------------------------------------------------- ĐỌC
        public static void DocNhanVien(XLWorkbook sach, QuanLyNhanVien quanLy, List<string> cacLoi)
        {
            IXLWorksheet sheet = sach.Worksheet(1);
            int dongCuoi = sheet.LastRowUsed().RowNumber();

            for (int dong = 2; dong <= dongCuoi; dong++)
            {
                string maNV = sheet.Cell(dong, 1).GetString().Trim();
                if (maNV == "")
                {
                    continue; // dòng trống
                }

                string hoTen = sheet.Cell(dong, 2).GetString().Trim();
                string loai = sheet.Cell(dong, 3).GetString().Trim().ToLower();

                decimal luongCoBan;
                decimal donGiaOT;
                decimal tyLeThuong;

                if (DocSo(sheet.Cell(dong, 4), out luongCoBan) == false
                    || DocSo(sheet.Cell(dong, 5), out donGiaOT) == false
                    || DocSo(sheet.Cell(dong, 6), out tyLeThuong) == false)
                {
                    cacLoi.Add("Sheet nhân viên, dòng " + dong + " (" + maNV + "): có ô số không đọc được");
                    continue;
                }

                // Ô thưởng định dạng % trong Excel (10% lưu là 0,1) thì đổi về 10
                if (sheet.Cell(dong, 6).Style.NumberFormat.Format.Contains("%"))
                {
                    tyLeThuong = tyLeThuong * 100;
                }

                if (cacLoaiNhanVien.ContainsKey(loai) == false)
                {
                    cacLoi.Add("Sheet nhân viên, dòng " + dong + " (" + maNV + "): loại nhân viên không hỗ trợ: \"" + loai + "\"");
                    continue;
                }

                if (luongCoBan < 0 || donGiaOT < 0 || tyLeThuong < 0)
                {
                    cacLoi.Add("Sheet nhân viên, dòng " + dong + " (" + maNV + "): lương/OT/thưởng không được âm");
                    continue;
                }

                NhanVien nv = cacLoaiNhanVien[loai](maNV, hoTen, luongCoBan, donGiaOT, tyLeThuong);

                string loi;
                if (quanLy.ThemNhanVien(nv, out loi) == false)
                {
                    cacLoi.Add("Sheet nhân viên, dòng " + dong + ": " + loi);
                }
            }
        }

        public static void DocChamCong(XLWorkbook sach, QuanLyChamCong quanLy, List<string> cacLoi)
        {
            IXLWorksheet sheet = sach.Worksheet(2);
            int dongCuoi = sheet.LastRowUsed().RowNumber();

            for (int dong = 2; dong <= dongCuoi; dong++)
            {
                string maNV = sheet.Cell(dong, 1).GetString().Trim();
                if (maNV == "")
                {
                    continue;
                }

                decimal thangSo;
                decimal namSo;
                decimal congChuan;
                decimal congCa;
                decimal congOT;

                if (DocSo(sheet.Cell(dong, 2), out thangSo) == false
                    || DocSo(sheet.Cell(dong, 3), out namSo) == false
                    || thangSo < 1 || thangSo > 12 || thangSo != Math.Floor(thangSo)
                    || namSo < 1 || namSo != Math.Floor(namSo))
                {
                    cacLoi.Add("Sheet chấm công, dòng " + dong + " (" + maNV + "): tháng/năm không hợp lệ");
                    continue;
                }

                if (DocSo(sheet.Cell(dong, 4), out congChuan) == false
                    || DocSo(sheet.Cell(dong, 5), out congCa) == false
                    || DocSo(sheet.Cell(dong, 6), out congOT) == false)
                {
                    cacLoi.Add("Sheet chấm công, dòng " + dong + " (" + maNV + "): có ô số không đọc được");
                    continue;
                }

                int thang = (int)thangSo;
                int nam = (int)namSo;

                ChamCong cc = new ChamCong(maNV, thang, nam, congChuan, congCa, congOT);

                string loi;
                if (quanLy.ThemChamCong(cc, out loi) == false)
                {
                    cacLoi.Add("Sheet chấm công, dòng " + dong + ": " + loi);
                }
            }
        }

        // Đọc 1 ô số. Ô trống hoặc "—" xem như 0. Trả về false nếu không phải số
        private static bool DocSo(IXLCell o, out decimal so)
        {
            so = 0;

            if (o.IsEmpty())
            {
                return true;
            }
            if (o.DataType == XLDataType.Number)
            {
                so = Convert.ToDecimal(o.GetDouble());
                return true;
            }

            // Ô dạng chữ, ví dụ "13.000.000" hoặc "14,5"
            string chu = o.GetString().Trim();
            if (chu == "" || chu == "—" || chu == "-")
            {
                return true;
            }

            if (chu.Contains(","))
            {
                // kiểu Việt Nam: dấu chấm ngăn nghìn, dấu phẩy thập phân
                chu = chu.Replace(".", "").Replace(",", ".");
            }
            else
            {
                int viTriChamCuoi = chu.LastIndexOf('.');
                bool coThapPhan = viTriChamCuoi >= 0
                    && chu.IndexOf('.') == viTriChamCuoi        // chỉ có 1 dấu chấm
                    && chu.Length - viTriChamCuoi - 1 != 3;     // và sau nó không phải đúng 3 chữ số (7.5, 14.25)
                if (coThapPhan == false)
                {
                    chu = chu.Replace(".", ""); // 13.000.000 -> 13000000
                }
            }

            return decimal.TryParse(chu, NumberStyles.Number, CultureInfo.InvariantCulture, out so);
        }

        // ---------------------------------------------------------------- GHI
        public static void GhiBangLuong(string duongDan, BangLuong bangLuong)
        {
            XLWorkbook sach = new XLWorkbook();
            IXLWorksheet sheet = sach.Worksheets.Add("BangLuong");

            string[] tieuDe = { "MNV", "Họ và tên", "Loại", "Lương theo công", "Thưởng", "Tổng thu nhập" };
            for (int cot = 0; cot < tieuDe.Length; cot++)
            {
                sheet.Cell(1, cot + 1).Value = tieuDe[cot];
            }
            sheet.Range(1, 1, 1, 6).Style.Font.Bold = true;

            int dong = 2;
            foreach (KetQuaLuong kq in bangLuong.CacDong)
            {
                sheet.Cell(dong, 1).Value = kq.MaNV;
                sheet.Cell(dong, 2).Value = kq.HoTen;
                sheet.Cell(dong, 3).Value = kq.LoaiNhanVien;
                sheet.Cell(dong, 4).Value = kq.LuongTheoCong;
                sheet.Cell(dong, 5).Value = kq.Thuong;
                sheet.Cell(dong, 6).Value = kq.TongThuNhap;
                dong++;
            }

            // Phần tổng hợp
            dong++;
            GhiDongTong(sheet, dong++, "Số nhân viên Full-time", bangLuong.DemTheoLoai("Full-time"));
            GhiDongTong(sheet, dong++, "Số nhân viên Part-time", bangLuong.DemTheoLoai("Part-time"));
            GhiDongTong(sheet, dong++, "Tổng thu nhập Full-time", bangLuong.TinhTongThuNhapTheoLoai("Full-time"));
            GhiDongTong(sheet, dong++, "Tổng thu nhập Part-time", bangLuong.TinhTongThuNhapTheoLoai("Part-time"));
            GhiDongTong(sheet, dong++, "Tổng lương theo công", bangLuong.TinhTongLuongTheoCong());
            GhiDongTong(sheet, dong++, "Tổng thưởng", bangLuong.TinhTongThuong());
            GhiDongTong(sheet, dong++, "TỔNG QUỸ LƯƠNG", bangLuong.TinhTongQuyLuong());

            // Phần lỗi (nếu có)
            if (bangLuong.CacLoi.Count > 0)
            {
                dong++;
                sheet.Cell(dong++, 1).Value = "Nhân viên không tính được lương:";
                foreach (string loi in bangLuong.CacLoi)
                {
                    sheet.Cell(dong++, 1).Value = loi;
                }
            }

            sheet.Range(2, 4, dong, 6).Style.NumberFormat.Format = "#,##0";
            sheet.Columns(1, 6).AdjustToContents();

            sach.SaveAs(duongDan);
        }

        private static void GhiDongTong(IXLWorksheet sheet, int dong, string nhan, decimal giaTri)
        {
            sheet.Cell(dong, 1).Value = nhan;
            sheet.Cell(dong, 6).Value = giaTri;
            sheet.Cell(dong, 1).Style.Font.Bold = true;
        }
    }
}
