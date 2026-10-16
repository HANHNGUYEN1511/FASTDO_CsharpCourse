// public class Exercise04_CheckPrimeNumber
// {
//     public static void Main(string[] args)
//     {
//         // Method 03: Kiểm tra đến √n
//         int n = 17;
//             bool isPrime = true;

//             if (n < 2)
//             {
//                 isPrime = false;
//             }
//             else
//             {
//                 for (int i = 2; i * i <= n; i++)
//                 {
//                     if (n % i == 0)
//                     {
//                         isPrime = false;
//                         break;
//                     }
//                 }
//             }

//             Console.WriteLine(isPrime ? "Prime" : "Not prime");
//     }
// }