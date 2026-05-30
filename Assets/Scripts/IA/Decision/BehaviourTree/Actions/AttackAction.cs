using UnityEngine;

namespace IA.Decision.BehaviourTree.Actions
{
    [CreateAssetMenu(fileName = "AttackAction", menuName = "Decision/BehaviourTree/Actions/AttackAction")]
    public class AttackAction : Task
    {
       [SerializeField] private AttackType attackType;
        public override bool Execute()
        {
            Boss boss = blackBoard.GetDataByKey<Boss>("boss");
            boss.Atack(attackType);
            return true;
        }
    }
}

public enum AttackType
{
    Melee,
    Ranged,
    Jump,
    Rayo,
    DoubleRanged,
    Area
}
