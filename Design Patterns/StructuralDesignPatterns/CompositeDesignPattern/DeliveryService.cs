namespace CompositeDesignPattern;

using Contracts;

public class DeliveryService
{
    private IBox box;

    public void SetupOrder(List<IBox> boxes)
    {
        this.box = new CompositeBox(boxes);
    }

    public double CalculateOrderPrice()
    {
        return this.box.CalculatePrice();
    }
}