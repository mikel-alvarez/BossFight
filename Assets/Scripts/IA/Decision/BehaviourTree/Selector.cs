using System.Collections.Generic;
using UnityEngine;

namespace IA.Decision.BehaviourTree
{
    [CreateAssetMenu(fileName = "Selector", menuName = "Decision/BehaviourTree/Selector")]
    public class Selector : Task
    {
        [SerializeField]
        protected List<Task> children;

        public override bool Execute()
        {
            foreach (Task child in children)
            {
                if (child.Execute())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
