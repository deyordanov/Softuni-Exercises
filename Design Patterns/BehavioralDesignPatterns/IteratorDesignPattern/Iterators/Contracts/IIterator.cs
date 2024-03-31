namespace IteratorDesignPattern.Iterators.Contracts;

using Models;

public interface IIterator
{
    bool HasNext();
    Route Next();
}