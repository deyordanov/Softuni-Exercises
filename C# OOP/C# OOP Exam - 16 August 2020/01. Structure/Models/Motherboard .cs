namespace OnlineShop.Models
{
    public class Motherboard : Component
    {
        private const double OverallPerformance = 1.25;
        public Motherboard(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance * OverallPerformance, generation)
        {
        }
    }
}