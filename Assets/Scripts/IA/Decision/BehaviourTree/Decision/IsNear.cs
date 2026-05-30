using UnityEngine;

namespace IA.Decision.BehaviourTree
{
    [CreateAssetMenu(fileName = "IsNear", menuName = "Decision/BehaviourTree/Condiciones/IsNear")]
    public class IsNear : Task
    {
        [SerializeField] private float distance = 1f;

        public override bool Execute()
        {
            Vector3 playerPosition = blackBoard.GetDataByKey<Transform>("PlayerTransform").position;
            Vector3 bossPosition = blackBoard.GetDataByKey<Transform>("BossTransform").position;
            return Vector3.Distance(playerPosition, bossPosition) <= distance;
        }
    }
}
