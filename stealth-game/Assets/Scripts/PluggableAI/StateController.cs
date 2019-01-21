using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    public State CurrentState;
    public State RemainState;
    public EnemyStats EnemyStats;
    public List<Transform> WayPointList;

    [HideInInspector] public NavMeshAgent NavMeshAgent;
    [HideInInspector] public int NextWayPoint;
    [HideInInspector] public Transform ChaseTarget;
    [HideInInspector] public float StateTimeElapsed;

    public Vector3 NextWayPointPosition
    {
        get
        {
            return WayPointList[NextWayPoint].position;
        }
    }

    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        CurrentState.UpdateState(this);
    }

    private void OnDrawGizmos()
    {
        if (CurrentState != null)
        {
            Gizmos.color = CurrentState.SceneGizmoColor;
            Gizmos.DrawWireSphere(transform.position, EnemyStats.HearRange);
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != RemainState)
        {
            CurrentState = nextState;
            OnExitState();
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        StateTimeElapsed += Time.deltaTime;
        return (StateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        StateTimeElapsed = 0;
    }

    public void IterateWaypoint()
    {
        NextWayPoint = (NextWayPoint + 1) % WayPointList.Count;
    }
}