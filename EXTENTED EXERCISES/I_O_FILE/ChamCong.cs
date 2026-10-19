namespace ChamCongTinhLuong
{
    // Một bản ghi chấm công của 1 nhân viên trong 1 tháng/năm
    public class ChamCong
    {
        private string maNV;
        private int thang;
        private int nam;
        private decimal congChuan;
        private decimal congCa;
        private decimal congOT;

        public ChamCong(string maNV, int thang, int nam, decimal congChuan, decimal congCa, decimal congOT)
        {
            this.maNV = maNV;
            this.thang = thang;
            this.nam = nam;
            this.congChuan = congChuan;
            this.congCa = congCa;
            this.congOT = congOT;
        }

        // Chỉ cho đọc (đóng gói): tạo xong thì không ai sửa được
        public string MaNV { get { return maNV; } }
        public int Thang { get { return thang; } }
        public int Nam { get { return nam; } }
        public decimal CongChuan { get { return congChuan; } }
        public decimal CongCa { get { return congCa; } }
        public decimal CongOT { get { return congOT; } }
    }
}
