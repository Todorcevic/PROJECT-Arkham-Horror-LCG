using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zenject;

namespace Arkham.Model
{
    public class Zone
    {
        private readonly List<Card> cards = new List<Card>();
        [Inject] private readonly ZonesRepository zonesRepository;

        public ReadOnlyCollection<Card> Cards => cards.AsReadOnly();

        /*******************************************************************/
        public Zone()
        {
            zonesRepository.AddNewZone(this);
        }

        /*******************************************************************/
        public void EnterThisCard(Card card) => cards.Add(card);

        public void ExitThisCard(Card card) => cards.Remove(card);

        public bool ContainThisCard(Card card) => cards.Contains(card);
    }
}
