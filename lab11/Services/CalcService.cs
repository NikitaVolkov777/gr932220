namespace CalcService.Services
{
    public class CalcService1
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public string Divide(int a, int b) => b == 0 ? "!!Error!! Division by zero. Be careful" : (a / b).ToString();

    }
}
