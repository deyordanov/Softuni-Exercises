namespace IteratorDesignPattern.Iterators.Contracts;

using Enums;

public interface IRouteCollection
{
    IIterator CreateIterator(IteratorType iteratorType);
}