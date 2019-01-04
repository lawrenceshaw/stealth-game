using System.Collections.Generic;
using UnityEngine;

public class NavAgent : MonoBehaviour
{
    public SquareGrid Graph;
    public float speed;

    private Queue<Vector2> steps;
    private Vector2? currentTarget;

    // Start is called before the first frame update
    private void Awake()
    {
        steps = new Queue<Vector2>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentTarget != null)
        {
            var maxDistanceDelta = speed * Time.deltaTime;

            var target = (Vector2)currentTarget;

            if (steps.Count > 0 && Vector2.Distance(transform.position, target) < maxDistanceDelta)
            {
                currentTarget = steps.Dequeue();
            }
            else if (Vector2.Distance(transform.position, target) > float.Epsilon)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, maxDistanceDelta);
            }
            else
            {
                currentTarget = null;
            }
        }
        else if (steps.Count > 0)
        {
            currentTarget = steps.Dequeue();
        }
    }

    public void SetTarget(Transform target)
    {
        SetTarget(target.position);
    }

    public void SetTarget(Vector2 target)
    {
        var astar = new AStarSearch(Graph, transform.position, target);

        var step = target;

        var reversedSteps = new List<Vector2>();

        while (step != null)
        {
            var cameFrom = astar.cameFrom[step];

            if (cameFrom == step)
            {
                break;
            }

            reversedSteps.Add(step);
            step = cameFrom;
        }

        reversedSteps.Reverse();
        steps = new Queue<Vector2>(reversedSteps);
    }
}