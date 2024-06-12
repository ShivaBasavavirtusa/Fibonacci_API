using MediatR;

namespace GnerateFibonacci_Core
{
    public class CalculateFibonacciCommand : IRequest<FibonacciResult>
    {
        public int Number { get; set; }
    }
}