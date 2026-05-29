using UnityEngine;

namespace IA.Decision.BehaviourTree.Decoration.Samples
{

    public class Inverter : Decorator
    {
        public Inverter(Task task) : base(task)
        {
        }
        public override bool Execute()
        {
            return !task.Execute();
        }
    }
}

