using MediatR;
using Microsoft.Extensions.Caching.Memory;


namespace GnerateFibonacci_Core.Handler
{
    public class CalculateFibonacciHandler : IRequestHandler<CalculateFibonacciCommand, FibonacciResult>
    {
        private readonly IMemoryCache _cache;
        private readonly IFibonacciService _fibonacciService;

        public CalculateFibonacciHandler(IMemoryCache cache, IFibonacciService fibonacciService)
        {
            _cache = cache;
            _fibonacciService = fibonacciService;
        }

        public Task<FibonacciResult> Handle(CalculateFibonacciCommand request, CancellationToken cancellationToken)
        {
            if (_cache.TryGetValue(request.Number, out long cachedResult))
            {
                return Task.FromResult(new FibonacciResult { Input = request.Number, Result = cachedResult });
            }

            var result = _fibonacciService.Calculate(request.Number);
            _cache.Set(request.Number, result, TimeSpan.FromMinutes(5)); // Cache the result for 5 minutes

            return Task.FromResult(new FibonacciResult { Input = request.Number, Result = result });
        }
    }

}
