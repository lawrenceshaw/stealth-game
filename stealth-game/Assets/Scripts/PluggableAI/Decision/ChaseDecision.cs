using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Chase")]
public class ChaseDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool continueToChase = Chase(controller);
        return continueToChase;
    }

    private bool Chase(StateController controller)
    {
        // Half added to range to account for radius of sound colider (think about other ways around this)
        if (controller.ChaseTarget != null
            && Vector3.Distance(controller.ChaseTarget.position, controller.transform.position) <= controller.EnemyStats.HearRange + 0.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}