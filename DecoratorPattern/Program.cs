internal class Program
{
    private static void Main(string[] args)
    {
        ProductBase siemensProduct = new SiemensProduct() { Name = "Siemens", Price = 100.95M, Stock = 1000 };
        siemensProduct = new SpecialOfferDecorator(siemensProduct) { CartDiscount = 10 };
        Console.WriteLine(siemensProduct);
        siemensProduct = new TaxDecorator(siemensProduct) { TaxPercentage = 1.2M };
        Console.WriteLine(siemensProduct);
    }

    public abstract class ProductBase
    {
        public abstract int Stock { get; set; }
        public abstract string Name { get; set; }
        public abstract decimal Price { get; set; }
    }

    public class SiemensProduct : ProductBase
    {
        public override int Stock { get; set; }
        public override string Name { get; set; }
        public override decimal Price { get; set; }

        public override string ToString()
        {
            return $"Ürün İsmi: {Name}, Stok Miktarı: {Stock}, Fiyat: {Price}";
        }
    }

    public class OsramProduct : ProductBase
    {
        public override int Stock { get; set; }
        public override string Name { get; set; }
        public override decimal Price { get; set; }
    }

    public abstract class ProductDecoratorBase : ProductBase
    {
        private ProductBase _productBase;

        protected ProductDecoratorBase(ProductBase productBase)
        {
            _productBase = productBase;
        }
    }


    public class SpecialOfferDecorator : ProductDecoratorBase
    {
        private ProductBase _productBase;
        public SpecialOfferDecorator(ProductBase productBase) : base(productBase)
        {
            _productBase = productBase;
        }
        public decimal CartDiscount { get; set; }
        public override int Stock { get => _productBase.Stock; set { } }
        public override string Name { get => _productBase.Name; set { } }
        public override decimal Price { get => _productBase.Price - CartDiscount; set { } }

        public override string ToString()
        {
            return $"Ürün İsmi: {Name}, Stok Miktarı: {Stock}, Fiyat: {Price}, Sepetteki İndiriminiz: {CartDiscount}";
        }
    }

    public class TaxDecorator : ProductDecoratorBase
    {
        private ProductBase _productBase;
        public TaxDecorator(ProductBase productBase) : base(productBase)
        {
            _productBase = productBase;
        }
        public decimal TaxPercentage { get; set; }
        public override int Stock { get => _productBase.Stock; set { } }
        public override string Name { get => _productBase.Name; set { } }
        public override decimal Price { get => _productBase.Price * TaxPercentage; set { } }

        public override string ToString()
        {
            return $"Ürün İsmi: {Name}, Stok Miktarı: {Stock}, Fiyat: {Price}, KDV: {TaxPercentage}";
        }
    }
}