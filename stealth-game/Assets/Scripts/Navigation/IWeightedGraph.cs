using System.Collections.Generic;
using UnityEngine;

public interface IWeightedGraph
{
    double Cost(Vector2 a, Vector2 b);

    IEnumerable<Vector2> Neighbors(Vector2 id);
}