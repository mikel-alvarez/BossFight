using UnityEngine;
namespace IA.Decision.BehaviourTree.Decoration
{
    public abstract class Decorator : Task
    {
        protected Task task;

        protected Decorator(Task task)
        {
            this.task = task;
        }
    }
}
