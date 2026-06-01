using System;
using System.Collections.Generic;
using UnityEngine;

namespace IA.EstateMachine
{
    public class Transition
    {
        private List<Action> actions;
        private State targetState;
        private Condition Condition;

        public bool IsTriggered()
        {
            return Condition.Test();
        }

        public State GetTargetState()
        {
            return targetState;
        }

        public List<Action> GetActions()
        {
            return actions;
        }
    }
}
