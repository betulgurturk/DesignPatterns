using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();
        services.AddScoped<ICache, RedisCache>();
        services.AddScoped<StockService>();
        var serviceProvider = services.BuildServiceProvider();
        var stockService = serviceProvider.GetRequiredService<StockService>();
        stockService.CacheStock();
    }
    public interface ICache
    {
        void Cache();
    }

    public class RedisCache : ICache
    {
        public void Cache()
        {
            Console.WriteLine("Redis Cache");
        }
    }

    public class MemoryCache : ICache
    {
        public void Cache()
        {
            Console.WriteLine("Memory Cache");
        }
    }

    public class StockService
    {
        private readonly ICache _cache;

        public StockService(ICache cache)
        {
            _cache = cache;
        }
        public void CacheStock()
        {
            _cache.Cache();
            Console.WriteLine("Stocks are cached");
        }
    }
}
