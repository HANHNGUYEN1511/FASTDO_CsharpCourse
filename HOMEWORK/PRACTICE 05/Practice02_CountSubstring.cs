// /* Bài 2.6.4 — Đếm số lần xuất hiện của chuỗi con (không chồng lấp)
// (Khó)
// Đề bài: Viết phương thức DemXuatHien(string chuoiLon, string chuoiCon) đếm số
// lần xuất hiện không chồng lấp (non-overlapping) của chuoiCon bên trong
// chuoiLon, sử dụng phương thức IndexOf(string, int) của lớp String để tìm kiếm
// tuần tự. Kiểm thử với ("abcabcabcabc", "abc") và ("aaaa", "aa").*/
// public class Practice02_CountSubstring
// {
//     public static int DemXuatHien(string chuoiLon, string chuoiCon)
//     {
//         int dem = 0;
//         int viTri = 0;

//         while ((viTri = chuoiLon.IndexOf(chuoiCon, viTri)) != -1)
//         {
//             dem++;
//             viTri += chuoiCon.Length; // Di chuyển vị trí tìm kiếm để tránh chồng lấp
//         }

//         return dem;
//     }

//     public static void Main(string[] args)
//     {
//         string chuoiLon1 = "abc ab cabca bc";
//         string chuoiCon1 = "abc";
//         int ketQua1 = DemXuatHien(chuoiLon1, chuoiCon1);
//         Console.WriteLine($"Số lần xuất hiện của '{chuoiCon1}' trong '{chuoiLon1}': {ketQua1}");

//         string chuoiLon2 = "a aaa";
//         string chuoiCon2 = "aa";
//         int ketQua2 = DemXuatHien(chuoiLon2, chuoiCon2);
//         Console.WriteLine($"Số lần xuất hiện của '{chuoiCon2}' trong '{chuoiLon2}': {ketQua2}");
//     }
// }