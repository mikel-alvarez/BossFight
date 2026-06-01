using System;
using System.Collections.Generic;
using UnityEngine;

namespace IA.EstateMachine
{
    public class State
    {
        private List<Action> stateActions;
        private List<Action> startActions;
        private List<Action> exitActions;
        private List<Transition> transitions;

        private State parentState;

        public List<Action> GetStateteActions()
        {
            return stateActions;
        }
        public List<Action> GetStartActions()
        {
            return startActions;
        }
        public List<Action> GetExitActions()
        {
            return exitActions;
        }
        public List<Transition> GetTransitions()
        {
            return transitions;
        }

        public List<State> GetHierarchy()
        {
            List<State> hierarchy = new List<State>();
            State currentState = this;
            while (currentState != null)
            {
                hierarchy.Add(currentState);
                currentState = currentState.parentState;
            }
            hierarchy.Reverse();
            return hierarchy;
        }

        public int GetLevel()
        {
            int level = 0;
            State currentState = this;
            while (currentState.parentState != null)
            {
                level++;
                currentState = currentState.parentState;
            }
            return level;
        }

    }
}
