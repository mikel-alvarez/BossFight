using UnityEngine;

namespace IA.Decision.BehaviourTree.Samples
{
    [CreateAssetMenu(fileName = "DebugAction", menuName = "Decision/BehaviourTree/Debug/DebugAction")]
    public class DebugAction : Task
    {
        [SerializeField]
        private string message;

        public DebugAction(string message)
        {
            this.message = message;
        }
        public override bool Execute()
        {
            Debug.Log(message);
            return true;
        }
    }
}