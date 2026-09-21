/* Bài 1.10.4 — Máy tính đơn giản bằng switch (Khó)
Đề bài: Viết chương trình mô phỏng một máy tính đơn giản: nhận vào số thứ nhất,
một ký tự phép toán (+, -, *, /), và số thứ hai; dùng lệnh switch để chọn phép
toán tương ứng và in ra kết quả. Chương trình phải xử lý được 2 trường hợp đặc
biệt: chia cho 0 (in thông báo lỗi, không thực hiện phép chia, người dùng nhập lại số thứ 2) và ký tự phép toán
không hợp lệ (dùng nhánh default).
*/
public class Practice02_SimpleCalculatorSwitch
{
    public static void Main(string[] args)
    {
        // Step 1: Read input from the user
        Console.Write("Enter the first number: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("Enter an operator (+, -, *, /): ");
        char op = Console.ReadLine()[0];

        double num2;
        while (true)
        {
            Console.Write("Enter the second number: ");
            num2 = double.Parse(Console.ReadLine());

            if (op == '/' && num2 == 0)
            {
                Console.WriteLine("Error: Division by zero is not allowed! Please enter a valid second number.");
            }
            else
            {
                break; // Valid input, exit the loop
            }
        }

        // Step 2: Perform calculation based on the operator
        switch (op)
        {
            case '+':
                Console.WriteLine($"Result: {num1 + num2}");
                break;
            case '-':
                Console.WriteLine($"Result: {num1 - num2}");
                break;
            case '*':
                Console.WriteLine($"Result: {num1 * num2}");
                break;
            case '/':
                Console.WriteLine($"Result: {num1 / num2}");
                break;
            default:
                Console.WriteLine("Error: Invalid operator.");
                break;
        }
    }
}