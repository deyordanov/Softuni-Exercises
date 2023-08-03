namespace OnlineShop.Models
{
    using Products.Components;

    public abstract class Component : Product, IComponent
    {
        private int generation;
        public Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.Generation = generation;
        }

        public int Generation
        {
            get => this.generation;
            private set => this.generation = value;
        }

        public override string ToString()
            => base.ToString() + $" Generation: {this.Generation}";
    }
}