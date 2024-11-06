internal class Program
{
    private static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager();
        var companyObserver = new CompanyObserver();
        productManager.Attach(new CustomerObserver());
        productManager.Attach(companyObserver);
        productManager.UpdatePrice();

        //Şirketlerin fiyat güncellemelerinden haberdar olmaması için listeden çıkarıldı.
        productManager.Detach(companyObserver);
        productManager.UpdatePrice();
    }

    public class ProductManager
    {
        List<Observer> priceObservers = new List<Observer>();

        public void UpdatePrice()
        {
            Console.WriteLine("Ürün fiyatı güncellendi.");
            //Observerlara haber ver.
            Notify();
        }


        public void Attach(Observer observer)
        {
            priceObservers.Add(observer);
        }
        public void Detach(Observer observer)
        {
            priceObservers.Remove(observer);
        }
        public void Notify()
        {
            foreach (var item in priceObservers)
            {
                item.Update();
            }
        }
    }

    public abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update()
        {
            //ürünün fiyatı güncellendiğinde çalışacak kodlar. Örneğin mail atılacak veya sms gönderilecek.
            Console.WriteLine("Müşteriler bilgilendirildi.");
        }
    }
    class CompanyObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Şirketler bilgilendirildi.");
        }
    }



}