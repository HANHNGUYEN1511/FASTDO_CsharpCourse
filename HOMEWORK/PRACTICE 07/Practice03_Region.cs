/*Bài 3.6.2 — Kết hợp #define, #if/#elif/#else, #region và #warning
(Khó)
Đề bài: Mô phỏng việc phân phối 3 phiên bản phần mềm bằng chỉ thị tiền xử lý:
định nghĩa (hoặc không định nghĩa) hai biểu tượng BAN_PRO và BAN_DUNGTHU. Dùng
#if BAN_PRO ... #elif BAN_DUNGTHU ... #else ... #endif để in ra thông báo
tương ứng với phiên bản đang được biên dịch (PRO / dùng thử / miễn phí). Đặt
toàn bộ khối kiểm tra này bên trong một #region/#endregion để có thể thu gọn
trong IDE. Ở nhánh #else (phiên bản miễn phí), thêm chỉ thị #warning để nhắc lập
trình viên bổ sung tính năng còn thiếu.*/