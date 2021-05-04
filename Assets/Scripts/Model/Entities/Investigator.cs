using System;
using System.Collections.Generic;
using System.Linq;

namespace Arkham.Model
{
    public enum InvestigatorState { None, Killed, Insane, Retired }

    public class Investigator
    {
        private bool isRetired;
        private readonly List<Card> deck = new List<Card>();
        private readonly List<Card> mandatoryCards = new List<Card>();

        public string Id => Info.Code;
        public Card Info { get; }
        public DeckBuildingRules DeckBuilding { get; }
        public int PhysicTrauma { get; set; }
        public int MentalTrauma { get; set; }
        public int Xp { get; set; }
        public bool IsPlaying { get; set; }
        public List<Card> FullDeck => deck.Concat(mandatoryCards).ToList();
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
        public List<string> CardsInDeckIds => deck.ConvertAll(card => card.Code);
        public List<string> MandatoryCardsIds => mandatoryCards.ConvertAll(card => card.Code);

        /*******************************************************************/
        public Investigator(int physicTrauma, int mentalTrauma, int xp, bool isPlaying, bool isRetired, Card info, DeckBuildingRules deckBuilding)
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
        public bool IsMandatoryCard(Card card) => mandatoryCards.Contains(card);

        public int GetAmountOfThisCardInDeck(Card card) => FullDeck.Count(c => c == card);

        public void AddToDeck(Card card) => deck.Add(card);

        public void RemoveToDeck(Card card) => deck.Remove(card);

        public void AddToMandatory(Card card) => mandatoryCards.Add(card);

        public List<Card> FindInDeck(Predicate<Card> filter) => deck.FindAll(filter);

        public int AmountInDeck(Card card) => deck.FindAll(c => c == card).Count;

        public void Retire() => isRetired = true;
    }
}
