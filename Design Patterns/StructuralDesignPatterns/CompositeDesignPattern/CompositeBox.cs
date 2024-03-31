namespace CompositeDesignPattern;

using Contracts;

public class CompositeBox : IBox
{
    private readonly List<IBox> _children;

    public CompositeBox(List<IBox> boxes)
    {
        this._children = boxes;
    }

    public double CalculatePrice()
    {
        return this._children.Sum(b => b.CalculatePrice());
    }
}