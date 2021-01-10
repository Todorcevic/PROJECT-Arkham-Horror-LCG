using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Arkham.Model;

namespace Arkham.UI
{
    public class CardComponent : MonoBehaviour
    {
        [SerializeField] private Image cardImage;
        public Card Info { get; set; }
        public Image CardImage => cardImage;
    }
}
