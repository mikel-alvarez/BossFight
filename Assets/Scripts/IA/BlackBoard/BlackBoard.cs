using System.Collections.Generic;
using UnityEngine;

namespace IA.BlackBoard
{
    public class BlackBoard : MonoBehaviour
    {

        public struct BlackBoardData
        {
            public string clave;
            public System.Type tipo;
            public object valor;

            public BlackBoardData(string clave, object valor)
            {
                this.clave = clave;
                this.valor = valor;
                this.tipo = valor.GetType();
            }

        }
        private List<BlackBoardData> estradas;

        private void Awake()
        {
            estradas = new List<BlackBoardData>();
        }

        public T GetDataByKey<T>(string clave)
        {
            foreach (BlackBoardData data in estradas)
            {
                if (data.clave.CompareTo(clave) == 0)
                {
                    return (T)data.valor;
                }
            }
            return default;
        }

        public void SetData(string clave, object valor)
        {
            for (int i = 0; i < estradas.Count; i++)
            {
                if (estradas[i].clave.CompareTo(clave) == 0)
                {
                    estradas[i] = new BlackBoardData(clave, valor);
                    return;
                }
            }
            estradas.Add(new BlackBoardData(clave, valor));
        }

    }
}