// /* Bài 2.5.4 — Ma trận hai chiều: tổng đường chéo và kiểm tra đối xứng
// (Khó)
// Đề bài: Cho ma trận vuông cấp 3: {{1,2,3},{4,5,6},{7,8,9}}. Viết chương trình:
// (a) tính tổng đường chéo chính (các phần tử a[i,i]) và tổng đường chéo phụ (các
// phần tử a[i, n-1-i]); (b) kiểm tra ma trận có đối xứng qua đường chéo chính hay
// không (tức là a[i,j] == a[j,i] với mọi i, j). */
// public class Practice01_Array
// {
//     public static void Main(string[] args)
//     {
//         /* Method 01: Khai báo mảng hai chiều với phương pháp mảng răng cưa (jagged array) */
//         // int[][] matrix = new int[3][];
//         // matrix[0] = new int[] { 1, 2, 3 };  
//         // matrix[1] = new int[] { 4, 5, 6 };
//         // matrix[2] = new int[] { 7, 8, 9 };

//         /* Method 02: Khai báo và khởi tạo mảng 2 chiều (2D array / multidimensional array với
//         Syntax: kiểu_dữ_liệu[,] tên_mảng = new kiểu_dữ_liệu[số_dòng, số_cột];*/
//         // int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

//         /* Method 03: Khai báo và khởi tạo mảng 2 chiều từ bàn phím */
//         Console.Write("Enter number of rows: ");
//         int rows = int.Parse(Console.ReadLine());

//         Console.Write("Enter number of columns: ");
//         int columns = int.Parse(Console.ReadLine());

//         int[,] matrix = new int[rows, columns];

//         for (int i = 0; i < rows; i++)
//         {
//             for (int j = 0; j < columns; j++)
//             {
//                 Console.Write($"matrix[{i},{j}] = ");
//                 matrix[i, j] = int.Parse(Console.ReadLine());
//             }
//         }

//         // Kích thước của ma trận vuông
//         int n = matrix.GetLength(0);

//         // Tính tổng đường chéo chính và đường chéo phụ
//         int duongCheo1 = 0;
//         int duongCheo2 = 0;

//         for (int i = 0; i < n; i++)
//         {
//             duongCheo1 += matrix[i, i]; // Tổng đường chéo 1
//             duongCheo2 += matrix[i, n - 1 - i]; // Tổng đường chéo 2
//         }

//         Console.WriteLine($"Tổng đường chéo 1: {duongCheo1}");
//         Console.WriteLine($"Tổng đường chéo 2: {duongCheo2}");

//         // Kiểm tra ma trận có đối xứng qua đường chéo chính hay không
//         bool isSymmetric = true;
//         for (int i = 0; i < n; i++)
//         {
//             for (int j = 0; j < n; j++)
//             {
//                 if (matrix[i, j] != matrix[j, i])
//                 {
//                     isSymmetric = false;
//                     break;
//                 }
//             }
//             if (!isSymmetric)
//             {
//                 break;
//             }
//         }

//         Console.WriteLine(isSymmetric ? "Ma trận đối xứng qua đường chéo chính." : "Ma trận không đối xứng qua đường chéo chính.");
//     }
// }