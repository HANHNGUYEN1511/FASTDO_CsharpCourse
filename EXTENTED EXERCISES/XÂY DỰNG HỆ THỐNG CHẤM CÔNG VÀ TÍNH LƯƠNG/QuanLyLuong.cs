// namespace HeThongChamCongTinhLuong
// {
//     public class QuanLyLuong
//     {
//         private readonly Dictionary<string, NhanVien> danhSachNhanVien = new();
//         private readonly Dictionary<(string MaNV, int Thang, int Nam), ChamCong>
//             danhSachChamCong = new();

//         public void ThemNhanVien(NhanVien nhanVien)
//         {
//             if (nhanVien == null)
//                 throw new ArgumentNullException(nameof(nhanVien));

//             if (danhSachNhanVien.ContainsKey(nhanVien.MaNhanVien))
//                 throw new InvalidOperationException(
//                     $"Mã nhân viên {nhanVien.MaNhanVien} đã tồn tại.");

//             danhSachNhanVien.Add(nhanVien.MaNhanVien, nhanVien);
//         }

//         public void ThemChamCong(ChamCong chamCong)
//         {
//             if (chamCong == null)
//                 throw new ArgumentNullException(nameof(chamCong));

//             if (!danhSachNhanVien.ContainsKey(chamCong.MaNhanVien))
//                 throw new InvalidOperationException(
//                     $"Không tìm thấy nhân viên {chamCong.MaNhanVien}.");

//             var khoa = (
//                 chamCong.MaNhanVien,
//                 chamCong.Thang,
//                 chamCong.Nam
//             );

//             if (danhSachChamCong.ContainsKey(khoa))
//                 throw new InvalidOperationException(
//                     $"Nhân viên {chamCong.MaNhanVien} đã có chấm công " +
//                     $"tháng {chamCong.Thang:D2}/{chamCong.Nam}.");

//             danhSachChamCong.Add(khoa, chamCong);
//         }

//         // Overload: tính lương một nhân viên.
//         public BangLuong TinhLuong(string maNhanVien, int thang, int nam)
//         {
//             if (!danhSachNhanVien.TryGetValue(maNhanVien, out NhanVien nhanVien))
//                 Console.WriteLine(
//                     $"Không tìm thấy nhân viên {maNhanVien}.");

//             var khoa = (maNhanVien, thang, nam);            // Tạo khóa để tìm dữ liệu chấm công. Dòng này tạo một bộ giá trị gồm ba thành phần.Vì một nhân viên có thể có dữ liệu chấm công ở nhiều tháng khác nhau. Hệ thống cần xác định chính xác nhân viên nào, tháng nào và năm nào.

//             if (!danhSachChamCong.TryGetValue(khoa, out ChamCong chamCong))
//                 Console.WriteLine(
//                     $"Chưa có chấm công của {maNhanVien} " +
//                     $"trong tháng {thang:D2}/{nam}.");      // D2 là định dạng số nguyên với tối thiểu hai chữ số.

//             return nhanVien.TinhLuong(chamCong);
//         }

//         // Overload: tính lương danh sách nhân viên trong một kỳ.
//         public List<BangLuong> TinhLuong(int thang, int nam)
//         {
//             var ketQua = new List<BangLuong>();

//             foreach (var chamCong in danhSachChamCong.Values)
//             {
//                 if (chamCong.Thang != thang || chamCong.Nam != nam)
//                     continue;

//                 try
//                 {
//                     ketQua.Add(
//                         TinhLuong(
//                             chamCong.MaNhanVien,
//                             thang,
//                             nam));
//                 }
//                 catch (Exception ex)
//                 {
//                     Console.WriteLine(
//                         $"LỖI {chamCong.MaNhanVien}: {ex.Message}");
//                 }
//             }

//             return ketQua;
//         }

//         public void HienThiBaoCao(List<BangLuong> bangLuong)
//         {
//             Console.WriteLine();
//             Console.WriteLine("BÁO CÁO CHI TIẾT LƯƠNG NHÂN VIÊN");
//             Console.WriteLine(new string('-', 140));

//             Console.WriteLine(
//                 $"{"Mã NV",-6} | {"Họ tên",-20} | {"Loại",-10} | " + 
//                 $"{"Công ca",10} | {"Công OT",10} | {"Công chuẩn",10} |" +
//                 $"{"Lương theo công",15} | {"Thưởng",12} | " +
//                 $"{"Tổng thu nhập",15} | {"Kỳ lương"}");

//             Console.WriteLine(new string('-', 140));

//             foreach (BangLuong luong in bangLuong)
//             {
//                 luong.HienThi();
//             }

//             decimal tongLuongTheoCong =
//                 bangLuong.Sum(x => x.LuongTheoCong);

//             decimal tongThuong =
//                 bangLuong.Sum(x => x.Thuong);

//             decimal tongQuyLuong =
//                 bangLuong.Sum(x => x.TongThuNhap);

//             Console.WriteLine(new string('-', 140));

//             Console.WriteLine(
//                 $"Tổng lương theo công: {tongLuongTheoCong:N0}đ");

//             Console.WriteLine($"Tổng thưởng: {tongThuong:N0}đ");

//             Console.WriteLine($"TỔNG QUỸ LƯƠNG: {tongQuyLuong:N0}đ");

//             Console.WriteLine();
//             Console.WriteLine("TỔNG HỢP THEO LOẠI NHÂN VIÊN");

//             var thongKe = bangLuong
//                 .GroupBy(x => x.NhanVien.LoaiNhanVien);

//             foreach (var nhom in thongKe)
//             {
//                 Console.WriteLine(
//                     $"{nhom.Key}: " +
//                     $"{nhom.Count()} nhân viên, " +
//                     $"tổng thu nhập {nhom.Sum(x => x.TongThuNhap):N0}đ");
//             }
//         }
//     }
// }