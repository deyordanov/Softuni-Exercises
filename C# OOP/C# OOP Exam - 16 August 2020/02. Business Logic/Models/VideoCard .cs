namespace OnlineShop.Models
{
    public class VideoCard : Component
    {
        private const double OverallPerformance = 1.15;
        public VideoCard(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance * OverallPerformance, generation)
        {
        }
    }
}