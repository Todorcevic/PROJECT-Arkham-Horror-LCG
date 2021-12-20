using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Gameplay
{
    public class ZoneComponent : MonoBehaviour
    {
        private List<CardComponent> cards;

        public void EnterHere(CardComponent card)
        {
            cards.Add(card);
        }

        public void ExitOut(CardComponent card)
        {
            cards.Remove(card);
        }
    }
}
