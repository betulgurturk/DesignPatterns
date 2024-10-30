internal class Program
{
    private static void Main(string[] args)
    {
        ILoggerFactory logFactory = new LoggerFactory();
        CustomerManager customerManager = new CustomerManager(logFactory);
        customerManager.Save();
    }
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new SeriLogger();
        }
    }
    public class LoggerFactory1 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new NLogger();
        }
    }
    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }
    public interface ILogger
    {
        void Log();
    }
    public class NLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("NLogger ile loglandı");
        }
    }
    public class SeriLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("SeriLog ile loglandı");
        }
    }


    public class CustomerManager
    {
        private readonly ILoggerFactory loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }


        public void Save()
        {
            Console.WriteLine("Müşteri Kaydedildi");
            loggerFactory.CreateLogger().Log();

        }
    }

}