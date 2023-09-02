using System;
using System.Collections.Generic;

namespace Tree
{
    public interface IIntegerTree: IAbstractTree<int>
    {
        List<List<int>> PathsWithGivenSum(int sum);

        List<Tree<int>> GetSubtreesWithGivenSum(int sum);
    }
}
