﻿using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State")]
public class State : ScriptableObject
{
    public Action[] Actions;
    public Transition[] Transitions;
    public Color SceneGizmoColor = Color.grey;

    public void UpdateState(StateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    private void DoActions(StateController controller)
    {
        for (int i = 0; i < Actions.Length; i++)
        {
            Actions[i].Act(controller);
        }
    }

    private void CheckTransitions(StateController controller)
    {
        for (int i = 0; i < Transitions.Length; i++)
        {
            bool decisionSucceeded = Transitions[i].Decision.Decide(controller);

            if (decisionSucceeded)
            {
                controller.TransitionToState(Transitions[i].TrueState);
            }
            else
            {
                controller.TransitionToState(Transitions[i].FalseState);
            }
        }
    }
}