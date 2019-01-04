using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "SquareGrid")]
public class SquareGrid : ScriptableObject, IWeightedGraph
{
    // Implementation notes: I made the fields public for convenience, but in a real project you'll
    // probably want to follow standard style and make them private.

    public static readonly Vector2[] DIRS = new[]
        {
            new Vector2(1, 0),
            new Vector2(0, -1),
            new Vector2(-1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1),
            new Vector2(-1, -1),
            new Vector2(1, -1),
            new Vector2(-1, 1),
        };

    public int width, height;
    public HashSet<Vector2> walls;
    public HashSet<Vector2> forests;

    private void OnEnable()
    {
        walls = new HashSet<Vector2>();
        forests = new HashSet<Vector2>();
    }

    public bool InBounds(Vector2 id)
    {
        return 0 <= id.x && id.x < width
            && 0 <= id.y && id.y < height;
    }

    public bool Passable(Vector2 id)
    {
        return !walls.Contains(id);
    }

    public double Cost(Vector2 a, Vector2 b)
    {
        return forests.Contains(b) ? 5 : 1;
    }

    public IEnumerable<Vector2> Neighbors(Vector2 id)
    {
        foreach (var dir in DIRS)
        {
            Vector2 next = new Vector2(id.x + dir.x, id.y + dir.y);
            if (InBounds(next) && Passable(next))
            {
                yield return next;
            }
        }
    }
}