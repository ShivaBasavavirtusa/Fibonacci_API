using GnerateFibonacci_Core;
namespace GenerateFibonacci_Infrastructure
{
    public class FibonacciService : IFibonacciService
    {
        public long Calculate(int number)
        {
            if (number <= 1) return number;
            long a = 0;
            long b = 1;
            for (int i = 2; i <= number; i++)
            {
                long temp = a;
                a = b;
                b = temp + b;
            }
            return b;
        }
    }

}