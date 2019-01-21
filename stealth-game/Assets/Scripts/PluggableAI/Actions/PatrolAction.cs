using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(StateController controller)
    {
        Patrol(controller);
    }

    public void Patrol(StateController controller)
    {
        controller.NavMeshAgent.destination = controller.NextWayPointPosition;

        if (controller.NavMeshAgent.remainingDistance <= controller.NavMeshAgent.stoppingDistance && !controller.NavMeshAgent.pathPending)
        {
            controller.IterateWaypoint();
        }
    }
}