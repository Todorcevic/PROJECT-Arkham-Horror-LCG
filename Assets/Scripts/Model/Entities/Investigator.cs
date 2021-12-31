using System;
using System.Collections.Generic;
using System.Linq;

namespace Arkham.Model
{
    public class Investigator
    {
        private bool isRetired;
        private readonly List<CardInfo> deck = new List<CardInfo>();
        private readonly List<CardInfo> mandatoryCards = new List<CardInfo>();

        public string Id => Info.Id;
        public CardInfo Info { get; }
        public DeckBuildingRules DeckBuilding { get; }

        /*************************** Deck ***************************/
        public List<CardInfo> FullDeck => mandatoryCards.Concat(deck).ToList();
        public List<string> CardsInDeckIds => deck.ConvertAll(card => card.Id);
        public List<string> MandatoryCardsIds => mandatoryCards.ConvertAll(card => card.Id);
        public List<string> FullDeckId => CardsInDeckIds.Concat(MandatoryCardsIds).ToList();

        /************************************************************/
        public int PhysicTrauma { get; set; }
        public int MentalTrauma { get; set; }
        public int Xp { get; set; }
        public bool IsPlaying { get; set; }
        public bool SelectionIsFull => AmountCardsSelected >= DeckBuilding.DeckSize;
        public int AmountCardsSelected => deck.Count;
        public InvestigatorState State
        {
            get
            {
                if (isRetired) return InvestigatorState.Retired;
                if (PhysicTrauma >= (Info.Health ?? 0)) return InvestigatorState.Killed;
                if (MentalTrauma >= (Info.Sanity ?? 0)) return InvestigatorState.Insane;
                return InvestigatorState.None;
            }
        }
        public bool IsEliminated => State != InvestigatorState.None;

        public CardInfo LastCardRemoved { get; private set; }

        /*******************************************************************/
        public Investigator(int physicTrauma, int mentalTrauma, int xp, bool isPlaying, bool isRetired, CardInfo info, DeckBuildingRules deckBuilding)
        {
            PhysicTrauma = physicTrauma;
            MentalTrauma = mentalTrauma;
            Xp = xp;
            IsPlaying = isPlaying;
            this.isRetired = isRetired;
            Info = info;
            DeckBuilding = deckBuilding;
        }

        /*******************************************************************/
        public bool IsMandatoryCard(CardInfo card) => mandatoryCards.Contains(card);

        public int GetAmountOfThisCardInDeck(CardInfo card) => FullDeck.Count(cardInDeck => cardInDeck == card);

        public void AddToDeck(CardInfo card) => deck.Add(card);

        public void RemoveToDeck(CardInfo card)
        {
            deck.Remove(card);
            LastCardRemoved = card;
        }

        public void AddToMandatory(CardInfo card) => mandatoryCards.Add(card);

        public void Retire()
        {
            isRetired = true;
            RemoveAllCards();
        }

        private void RemoveAllCards() => deck.Clear();
    }
}
