using UnityEngine;

namespace IA.Decision.BehaviourTree
{

    public abstract class Task: ScriptableObject
    {
        public abstract bool Execute();
    }
}