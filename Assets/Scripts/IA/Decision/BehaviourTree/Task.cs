using IA.BlackBoard;
using UnityEngine;

namespace IA.Decision.BehaviourTree
{

    public abstract class Task: ScriptableObject
    {
        [SerializeField] protected BlackBoard.BlackBoard blackBoard;

        public virtual void SetBlackBoard(BlackBoard.BlackBoard blackBoard)
        {
            this.blackBoard = blackBoard;
        }
        public abstract bool Execute();
    }
}