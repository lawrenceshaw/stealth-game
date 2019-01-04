using System.Collections.Generic;

public class PriorityQueue<T>
{
    // I'm using an unsorted array for this example, but ideally this would be a binary heap. There's
    // an open issue for adding a binary heap to the standard C# library: https://github.com/dotnet/corefx/issues/574
    //
    // Until then, find a binary heap class:
    // * https://github.com/BlueRaja/High-Speed-Priority-Queue-for-C-Sharp
    // * http://visualstudiomagazine.com/articles/2012/11/01/priority-queues-with-c.aspx
    // * http://xfleury.github.io/graphsearch.html
    // * http://stackoverflow.com/questions/102398/priority-queue-in-net

    private List<(T Item, double Cost)> elements = new List<(T, double)>();

    public int Count
    {
        get { return elements.Count; }
    }

    public void Enqueue(T item, double priority)
    {
        elements.Add((item, priority));
    }

    public T Dequeue()
    {
        int bestIndex = 0;

        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].Cost < elements[bestIndex].Cost)
            {
                bestIndex = i;
            }
        }

        T bestItem = elements[bestIndex].Item;
        elements.RemoveAt(bestIndex);
        return bestItem;
    }
}