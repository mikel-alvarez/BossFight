
using System.Collections.Generic;
using UnityEngine;

namespace IA.Decision.BehaviourTree
{
    [CreateAssetMenu(fileName = "Sequence", menuName = "Decision/BehaviourTree/Sequence")]
    public class Sequence : Task
    {
        [SerializeField]
        protected List<Task> children;

        public override bool Execute()
        {
            foreach (Task child in children)
            {
                if (!child.Execute())
                {
                    return false;
                }
            }
            return true;
        }

        public override void SetBlackBoard(BlackBoard.BlackBoard blackBoard)
        {
            base.SetBlackBoard(blackBoard);
            foreach (Task child in children)
            {
                child.SetBlackBoard(blackBoard);
            }
        }
    }

    
}
