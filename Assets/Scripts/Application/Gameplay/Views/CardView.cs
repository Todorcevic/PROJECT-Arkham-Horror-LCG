using System;
using UnityEngine;

namespace Arkham.Application.GamePlay
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer mesh;

        public Guid Guid { get; private set; }

        /*******************************************************************/
        public void Init(Guid guid, Material cardMaterial, string name)
        {
            Guid = guid;
            mesh.material = cardMaterial;
            this.name = name;
        }
    }
}
