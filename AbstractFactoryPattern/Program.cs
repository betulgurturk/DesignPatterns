internal class Program
{
    private static void Main(string[] args)
    {
        GroupFactory factory= new Factory();
        CustomerService service = new CustomerService(factory);
        service.GetCustomers();
    }

    public abstract class Logger
    {
        public abstract void Log();
    }
    public class NLogger : Logger
    {
        public override void Log()
        {
            Console.WriteLine("NLog ile loglandı.");
        }
    }
    public class SeriLog : Logger
    {
        public override void Log()
        {
            Console.WriteLine("Seri Log ile loglandı.");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache();
    }

    public class RedisCache : Caching
    {
        public override void Cache()
        {
            Console.WriteLine("Redis ile cachlendi.");
        }
    }
    public class MemoryCache : Caching
    {
        public override void Cache()
        {
            Console.WriteLine("Memory cach ile cachlendi.");
        }
    }

    public abstract class GroupFactory
    {
        public abstract Logger CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory : GroupFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logger CreateLogger()
        {
            return new NLogger();
        }
    }

    public class Factory1 : GroupFactory
    {
        public override Caching CreateCaching()
        {
            return new MemoryCache();
        }

        public override Logger CreateLogger()
        {
            return new SeriLog();
        }
    }

    public class CustomerService
    {
        private readonly GroupFactory groupFactory;
        public CustomerService(GroupFactory groupFactory)
        {
            this.groupFactory = groupFactory;
        }

        public void GetCustomers()
        {
            Console.WriteLine("müşteriler listelendi.");
            groupFactory.CreateCaching().Cache();
            groupFactory.CreateLogger().Log();
        }
    }
}