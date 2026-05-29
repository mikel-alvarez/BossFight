using UnityEngine;

namespace IA.Decision.BehaviourTree
{
    [CreateAssetMenu(fileName = "DebugIf", menuName = "Decision/BehaviourTree/Debug/DebugIf")]
    public class DebugIf : Task
    {
        [SerializeField] private bool condition;
        public override bool Execute()
        {
            return condition;
        }
    }
}
