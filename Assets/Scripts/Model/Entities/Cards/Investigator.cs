using System;
using System.Collections.Generic;
using System.Linq;

namespace Arkham.Model
{
    public class Investigator : Card
    {
        private bool isRetired;
        private readonly List<CardInfo> deck = new List<CardInfo>();
        private readonly List<CardInfo> mandatoryCards = new List<CardInfo>();

        public DeckBuildingRules DeckBuilding { get; }
        public int PhysicTrauma { get; set; }
        public int MentalTrauma { get; set; }
        public int Xp { get; set; }
        public bool IsPlaying { get; set; }
        public List<CardInfo> FullDeck => mandatoryCards.Concat(deck).ToList();
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
        public List<string> CardsInDeckIds => deck.ConvertAll(card => card.Id);
        public List<string> MandatoryCardsIds => mandatoryCards.ConvertAll(card => card.Id);
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

        public List<CardInfo> FindInDeck(Predicate<CardInfo> filter) => deck.FindAll(filter);

        public void Retire()
        {
            isRetired = true;
            RemoveAllCards();
        }

        private void RemoveAllCards() => deck.Clear();
    }
}
