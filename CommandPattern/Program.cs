internal class Program
{
    private static void Main(string[] args)
    {
        Stock stock = new Stock();
        BuyStockOrder buyStockOrder = new BuyStockOrder(stock);
        SellStockOrder sellStockOrder = new SellStockOrder(stock);

        OrderController orderController = new OrderController();
        orderController.AddOrder(buyStockOrder);
        orderController.AddOrder(sellStockOrder);
        orderController.AddOrder(buyStockOrder);
        orderController.AddOrder(sellStockOrder);
        orderController.AddOrder(buyStockOrder);
        orderController.ExecuteOrders();

    }

    public class Stock
    {
        public void SellStock()
        {
            Console.WriteLine("Stocks are cached");
        }
        public void BuyStock()
        {
            Console.WriteLine("Stocks are bought");
        }
        public void BuyStock2()
        {
            Console.WriteLine("Stocks are bought");
        }
    }

    public interface IOrder
    {
        void Execute();
    }

    public class BuyStockOrder : IOrder
    {
        private Stock _stock;
        public BuyStockOrder(Stock stock)
        {
            _stock = stock;
        }
        public void Execute()
        {
            _stock.BuyStock2();
        }
    }
    public class SellStockOrder : IOrder
    {
        private Stock _stock;
        public SellStockOrder(Stock stock)
        {
            _stock = stock;
        }
        public void Execute()
        {
            _stock.SellStock();
        }
    }

    public class OrderController
    {
        public List<IOrder> orders { get; set; }

        public OrderController()
        {
            orders = new List<IOrder>();
        }

        public void AddOrder(IOrder order)
        {
            orders.Add(order);
        }
        public void ExecuteOrders()
        {
            foreach (var order in orders)
            {
                order.Execute();
            }
            orders.Clear();
        }
    }
}