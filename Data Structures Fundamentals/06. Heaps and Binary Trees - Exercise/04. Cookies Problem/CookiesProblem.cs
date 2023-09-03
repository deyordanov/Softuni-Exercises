using System;
using System.Linq;
using _03.MinHeap;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int minSweetness, int[] cookies)
        {
            OrderedBag<int> queue = new OrderedBag<int>();
            queue.AddMany(cookies);

            int currentMinSweetness = queue.GetFirst();
            int operations = 0;
            while (currentMinSweetness < minSweetness && queue.Count > 1)
            {
                int newCookie = queue.RemoveFirst() + 2 * queue.RemoveFirst();

                queue.Add(newCookie);
                queue = new OrderedBag<int>(queue);
                currentMinSweetness = queue.GetFirst();
                operations++;
            }

            return currentMinSweetness < minSweetness ? -1 : operations;
        }
    }
}
