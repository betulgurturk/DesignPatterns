internal class Program
{
    private static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager();

        //2024 öncesi ürünler için hesaplama yapılır.
        productManager.PriceCalculator = new Before2024ProductPriceCalculator();
        productManager.CalculatePrice();

        //2024 sonrası ürünler için hesaplama yapılır.
        productManager.PriceCalculator = new After2024ProductPriceCalculator();
        productManager.CalculatePrice();
    }

    abstract class ProductPriceCalcutatorBase
    {
        public abstract void Calculate();
    }

    class Before2024ProductPriceCalculator : ProductPriceCalcutatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Kdv %18 üzerinden hesaplanmıştır.");
        }
    }
    class After2024ProductPriceCalculator : ProductPriceCalcutatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Kdv %20 üzerinden hesaplanmıştır.");
        }
    }

    class ProductManager
    {
        public ProductPriceCalcutatorBase PriceCalculator { get; set; }
        public void CalculatePrice()
        {
            PriceCalculator.Calculate();
        }
    }

}