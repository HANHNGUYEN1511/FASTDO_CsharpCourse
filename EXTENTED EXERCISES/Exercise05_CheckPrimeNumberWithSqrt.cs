// public class Exercise05_CheckPrimeNumberWithSqrt
// {
//     // Method 04: Sử dụng Math.Sqrt (method tính căn bậc hai) để kiểm tra số nguyên tố
//     public static bool IsPrime(int number)
//     {
//         if (number <= 1)
//         {
//             return false; // Số nhỏ hơn hoặc bằng 1 không phải là số nguyên tố
//         }

//         for (int i = 2; i <= Math.Sqrt(number); i++)
//         {
//             if (number % i == 0)
//             {
//                 return false; // Nếu chia hết cho bất kỳ số nào từ 2 đến căn bậc hai của number, thì không phải là số nguyên tố
//             }
//         }

//         return true; // Nếu không chia hết cho bất kỳ số nào, thì là số nguyên tố
//     }

//     public static void Main(string[] args)
//     {
//         Console.Write("Enter a number to check if it is prime: ");
//         int number = Convert.ToInt32(Console.ReadLine());

//         if (IsPrime(number))
//         {
//             Console.WriteLine($"{number} is a prime number.");
//         }
//         else
//         {
//             Console.WriteLine($"{number} is not a prime number.");
//         }
//     }
// }