using System;
using UnityEngine;

namespace Arkham.Application.GamePlay
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer mesh;

        public string Id { get; private set; }
        public ZoneView CardZoneView { get; set; }

        /*******************************************************************/
        public void Init(Material cardMaterial, string cardId)
        {
            mesh.material = cardMaterial;
            Id = name = cardId;
        }
    }
}
