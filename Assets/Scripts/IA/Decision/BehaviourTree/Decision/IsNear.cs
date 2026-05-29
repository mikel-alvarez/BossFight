using UnityEngine;

namespace IA.Decision.BehaviourTree
{
    [CreateAssetMenu(fileName = "IsNear", menuName = "Decision/BehaviourTree/IsNear")]
    public class IsNear : Task
    {
        [SerializeField] private float distance = 1f;

        public override bool Execute()
        {
            //Vector3 playerPosition = BlackBoard.BlackBoard.Instance.GetDataByKey<Transform>("playerTransform").position;
            //if (playerPosition.)
            //{

            //}
            return true;
        }
    }
}
