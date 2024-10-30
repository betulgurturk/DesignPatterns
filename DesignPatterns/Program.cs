internal class Program
{
    private static void Main(string[] args)
    {
        var productManager = ProductManager.GetProductManagerSingleton();
        productManager.Save();

        //test
        var productManager1 = ProductManager.GetProductManagerSingleton();
        var productManager2 = ProductManager.GetProductManagerSingleton();


    }


    public class ProductManager
    {
        private static ProductManager? _productManager;
        private static object _lock = new object();
        private ProductManager()
        {
            
        }

        public static ProductManager GetProductManagerSingleton()
        {
            lock (_lock)//thread safe
            {
                if (_productManager == null)
                    _productManager = new ProductManager();               
            }
            return _productManager;
        }

        public void Save()
        {
            Console.WriteLine("Kaydedildi");
        }
    }
}

