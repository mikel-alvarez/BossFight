using System;
using System.Collections.Generic;
using UnityEngine;

namespace IA.EstateMachine
{
    public class StateMachine
    {
        private State startState;
        private State currentState;

        public StateMachine()
        {
            currentState = startState;
        }


        public List<Action> Update()
        {
            if (currentState == null)
            {
                return null;
            }

            List<State> hierarchy = currentState.GetHierarchy();
            Transition bestTransition = null;
            int bestLevel = int.MaxValue;

            foreach (State state in hierarchy)
            {
                foreach (Transition transition in state.GetTransitions())
                {
                    if (transition.IsTriggered())
                    {
                        int transitionLevel = state.GetLevel();
                        if (transitionLevel < bestLevel)
                        {
                            bestTransition = transition;
                            bestLevel = transitionLevel;
                        }
                    }
                }
            }

            if (bestTransition != null)
            {
                return ApplyTransition(bestTransition);
            }
            return null;
        }

        private List<Action> ApplyTransition(Transition bestTransition)
        {
            List<State> currentHierarchy = currentState.GetHierarchy();
            List<State> targetHierarchy = bestTransition.GetTargetState().GetHierarchy();

            int commonLevel = 0;
            while (commonLevel < currentHierarchy.Count && commonLevel < targetHierarchy.Count && currentHierarchy[commonLevel] == targetHierarchy[commonLevel])
            {
                commonLevel++;
            }

            List<Action> actionsToExecute = new List<Action>();

            for (int i = currentHierarchy.Count - 1; i >= commonLevel; i--)
            {
                if (currentHierarchy[i].GetExitActions() != null)
                {
                    actionsToExecute.AddRange(currentHierarchy[i].GetExitActions());
                }
            }
            actionsToExecute.AddRange(bestTransition.GetActions());

            for (int i = commonLevel; i < targetHierarchy.Count; i++)
            {
                if (targetHierarchy[i].GetStartActions() != null)
                {
                    actionsToExecute.AddRange(targetHierarchy[i].GetStartActions());
                }
            }

            return actionsToExecute;
        }

    }
}