using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
    public override void Act(StateController controller)
    {
        Chase(controller);
    }

    public void Chase(StateController controller)
    {
        if (controller.ChaseTarget != null)
        {
            controller.NavMeshAgent.destination = controller.ChaseTarget.position;
        }
    }
}