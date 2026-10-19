namespace ChamCongTinhLuong
{
    // Interface: hợp đồng mà mọi loại nhân viên đều phải thực hiện
    public interface ITinhLuong
    {
        decimal TinhLuongTheoCong(ChamCong chamCong);
        decimal TinhThuong();
    }
}
