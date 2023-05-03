namespace WildFarm.Models.Foods
{
    using WildFarm.Models.Interfaces;
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; private set; }
    }
}
