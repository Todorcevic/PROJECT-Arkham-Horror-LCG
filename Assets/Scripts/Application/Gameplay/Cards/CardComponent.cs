using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Gameplay
{
    public class CardComponent : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;

        private void Start()
        {
            meshRenderer.material.SetTextureScale("_MainTex2", new Vector2(-1, 1));
        }
    }
}
