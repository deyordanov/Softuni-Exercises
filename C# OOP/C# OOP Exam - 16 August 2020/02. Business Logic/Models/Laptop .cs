namespace OnlineShop.Models
{
    public class Laptop : Computer
    {
        private const double OverallPerformance = 10;
        public Laptop(int id, string manufacturer, string model, decimal price) : base(id, manufacturer, model, price, OverallPerformance)
        {
        }
    }
}