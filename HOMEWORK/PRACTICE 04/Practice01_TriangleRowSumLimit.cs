// /* Bài 2.1.4 — Tam giác số có giới hạn tổng mỗi dòng (Khó)
// Đề bài: Viết chương trình in ra một tam giác số gồm 5 dòng, dòng thứ i in các số 
// từ 1 đến i. Tuy nhiên, ở mỗi dòng, nếu tổng các số đã in trong dòng đó vượt quá 7
// thì dừng in tiếp số của dòng này (dùng break) và chuyển sang dòng kế tiếp. Sau
// mỗi dòng in ra tổng của dòng đó, và cuối chương trình in tổng của tất cả các dòng.*/
// public class Practice01_TriangleRowSumLimit
// {
//     public static void Main(string[] args)
//     {
//         int totalSum = 0;

//         for (int i = 1; i <= 5; i++)
//         {
//             int rowSum = 0;             // Khai báo biến rowSum để tính tổng của dòng hiện tại

//             for (int j = 1; j <= i; j++)
//             {
//                 if (rowSum + j > 7)     // Nếu tổng của dòng vượt quá 7, dừng in tiếp số của dòng này
//                 {
//                     break;
//                 }

//                 Console.Write($"{j} ");
//                 rowSum += j;
//             }

//             Console.WriteLine();

//             totalSum += rowSum;
//         }

//         Console.WriteLine($"Total of all rows: {totalSum}");
//     }
// }