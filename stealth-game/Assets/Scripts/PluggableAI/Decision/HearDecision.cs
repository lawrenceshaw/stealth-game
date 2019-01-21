using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Hear")]
public class HearDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool targetVisable = Hear(controller);
        return targetVisable;
    }

    private bool Hear(StateController controller)
    {
        Collider[] colliders = Physics.OverlapSphere(controller.transform.position, controller.EnemyStats.HearRange);

        Debug.DrawRay(controller.transform.position, controller.transform.forward.normalized * controller.EnemyStats.HearRange, Color.green);

        if (colliders.Length > 0)
        {
            foreach (var collider in colliders)
            {
                if (collider.GetComponent<Sound>() != null)
                {
                    controller.ChaseTarget = collider.transform;
                    return true;
                }
            }

            return false;
        }
        else
        {
            return false;
        }
    }
}