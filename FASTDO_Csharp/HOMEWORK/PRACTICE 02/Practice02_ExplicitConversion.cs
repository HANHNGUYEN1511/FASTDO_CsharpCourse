// /* Bài 1.6.3 — Những cạm bẫy khi ép kiểu tường minh (Khó)
// Đề bài: Viết chương trình minh họa 2 điều dễ hiểu lầm khi ép kiểu: (1) Ép một số thực âm -5.9 sang int bằng (int)(-5.9) — kết quả có phải là -6 (làm tròn) hay
// không? (2) Ép giá trị 300 (kiểu int) sang byte bằng (byte)300 — vì sao kết quả không phải là lỗi mà lại ra một con số cụ thể? In kết quả và giải thích rõ trong code
// bằng comment.*/
// public class Practice02_ExplicitConversion
// {
//     public static void Main()
//     {
//         // Case 1: Explicit conversion of a negative floating-point number to int
//         double negativeFloat = -5.9;
//         int convertedInt = (int)negativeFloat;          // Explicit conversion from double to int
//         Console.WriteLine("Giá trị của convertedInt sau khi ép kiểu: " + convertedInt);
//         bool isRoundedDown = convertedInt == -6;        // Check if the result is -6
//         Console.WriteLine("Kết quả có phải là -6 (làm tròn lên) không? " + (isRoundedDown ? "Có" : "Không"));       // Formular of Ternary Operator (Toán tử 3 ngôi): điều_kiện ? giá_trị_nếu_đúng : giá_trị_nếu_sai


//         // Case 2: Explicit conversion of an int value to byte
//         int largeInt = 300;
//         byte convertedByte = (byte)largeInt;            // Explicit conversion from int to byte
//         Console.WriteLine("Giá trị của convertedByte sau khi ép kiểu: " + convertedByte);
//         // Explanation: Vì byte có: 2^8 = 256 (giá trị: 0 → 255) => 300 % 256 = 44
//         /* Hãy tưởng tượng byte giống một vòng tròn:
//             0 → 1 → 2 → ... → 254 → 255
//             ↑                         ↓
//             └─────────────────────────┘
//             Sau 255 thì quay lại 0.
//             Vậy: 255 + 1 = 0
//             Tiếp tục:
//             256 → 0
//             257 → 1
//             258 → 2
//             ...
//             300 → 44
//             */
//     }
// }