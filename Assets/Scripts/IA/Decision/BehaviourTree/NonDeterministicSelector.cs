using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IA.Decision.BehaviourTree
{
    [CreateAssetMenu(fileName = "NonDeterministicSelector", menuName = "Decision/BehaviourTree/NonDeterministicSelector")]
    public class NonDeterministicSelector : Selector
    {

        public override bool Execute()
        {
            ShuffleChildren();
            return base.Execute();
        }

        public void ShuffleChildren()
        {
            base.children.OrderBy(x => Random.value).ToList();
        }
    }
}
