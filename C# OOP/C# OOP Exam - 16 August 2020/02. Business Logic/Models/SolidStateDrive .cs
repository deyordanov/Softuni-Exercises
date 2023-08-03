namespace OnlineShop.Models
{
    public class SolidStateDrive : Component
    {
        private const double OverallPerformance = 1.20;
        public SolidStateDrive(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance * OverallPerformance, generation)
        {
        }
    }
}