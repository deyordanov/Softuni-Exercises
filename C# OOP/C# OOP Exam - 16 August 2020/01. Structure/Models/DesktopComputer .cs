namespace OnlineShop.Models
{
    public class DesktopComputer : Computer
    {
        private const double OverallPerformance = 15;
        public DesktopComputer(int id, string manufacturer, string model, decimal price) : base(id, manufacturer, model, price, OverallPerformance)
        {
        }
    }
}