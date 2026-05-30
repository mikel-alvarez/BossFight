using UnityEngine;
namespace IA.Decision.BehaviourTree
{
    [CreateAssetMenu(fileName = "MasMitadVida", menuName = "Decision/BehaviourTree/Condiciones/MasMitadVida")]

    public class MasMitadVida : Task
    {
        public override bool Execute()
        {
           int vidaActual = blackBoard.GetDataByKey<int>("VidaActual");
              int vidaMaxima = blackBoard.GetDataByKey<int>("VidaMaxima");
            return vidaActual <= vidaMaxima / 2;
        }
    }
}
