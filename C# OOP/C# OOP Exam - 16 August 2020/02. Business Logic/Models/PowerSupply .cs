namespace OnlineShop.Models
{
    public class PowerSupply : Component
    {
        private const double OverallPerformance = 1.05;
        public PowerSupply(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance * OverallPerformance, generation)
        {
        }
    }
}