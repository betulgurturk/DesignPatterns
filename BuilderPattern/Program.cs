internal class Program
{
    private static void Main(string[] args)
    {
        ProductDirector director = new ProductDirector();
        ProductBuilder builder = new NewCustomerProductBuilder();
        director.GenerateProduct(builder);
        ProductViewModel model = builder.GetModel();
        Console.WriteLine("Product Name: {0}, Price: {1}, Discounted Price: {2}", model.ProductName, model.Price, model.DiscountedPrice);
    }

    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
    }

    public abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    public class NewCustomerProductBuilder : ProductBuilder
    {
        private ProductViewModel _model = new ProductViewModel();
        public override void GetProductData()
        {
            _model.Id = 1;
            _model.ProductName = "Laptop";
            _model.Price = 100;
        }

        public override void ApplyDiscount()
        {
            _model.DiscountedPrice = _model.Price * (decimal)0.9;
        }

        public override ProductViewModel GetModel()
        {
            return _model;
        }
    }

    public class OldCustomerProductBuilder : ProductBuilder
    {
        private ProductViewModel _model = new ProductViewModel();
        public override void GetProductData()
        {
            _model.Id = 1;
            _model.ProductName = "Laptop";
            _model.Price = 100;
        }

        public override void ApplyDiscount()
        {
            _model.DiscountedPrice = _model.Price * (decimal)0.7;
        }

        public override ProductViewModel GetModel()
        {
            return _model;
        }
    }

    public class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}