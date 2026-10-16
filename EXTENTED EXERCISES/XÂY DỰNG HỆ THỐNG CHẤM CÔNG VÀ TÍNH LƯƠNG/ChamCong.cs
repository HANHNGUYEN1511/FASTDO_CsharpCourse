namespace HeThongChamCongTinhLuong 
{
public class ChamCong
{
    public string MaNhanVien { get; private set; }
    public int Thang { get; private set; }
    public int Nam { get; private set; }
    public decimal CongChuan { get; private set; }
    public decimal CongCa { get; private set; }
    public decimal CongOT { get; private set; }

    public ChamCong(
        string maNhanVien,
        int thang,
        int nam,
        decimal congChuan,
        decimal congCa,
        decimal congOT)
    {
        if (maNhanVien == null || maNhanVien.Trim()=="")
            Console.WriteLine("Mã nhân viên không được để trống.");

        if (thang < 1 || thang > 12)
            Console.WriteLine("Tháng phải từ 1 đến 12.");

        if (nam < 1)
            Console.WriteLine("Năm không hợp lệ.");

        if (congChuan < 0 || congCa < 0 || congOT < 0)
            Console.WriteLine("Dữ liệu công không được âm.");

        MaNhanVien = maNhanVien;
        Thang = thang;
        Nam = nam;
        CongChuan = congChuan;
        CongCa = congCa;
        CongOT = congOT;
    }
}
}