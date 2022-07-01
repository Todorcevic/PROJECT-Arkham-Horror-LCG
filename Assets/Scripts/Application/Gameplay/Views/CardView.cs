using System;
using UnityEngine;

namespace Arkham.Application.GamePlay
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer mesh;

        /*******************************************************************/
        public void Init(Material cardMaterial, string name)
        {
            mesh.material = cardMaterial;
            this.name = name;
        }
    }
}
