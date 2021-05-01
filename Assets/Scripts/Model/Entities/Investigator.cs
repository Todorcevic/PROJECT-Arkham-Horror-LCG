using System;
using System.Collections.Generic;
using System.Linq;
using Arkham.Model;

namespace Arkham.Model
{
    public class Investigator
    {
        private readonly List<Card> deck = new List<Card>();
        private readonly List<Card> mandatoryCards = new List<Card>();

        public string Id => Info.Code;
        public Card Info { get; set; }
        public DeckBuildingRules DeckBuilder { get; set; }
        public int PhysicTrauma { get; set; }
        public int MentalTrauma { get; set; }
        public int Xp { get; set; }
        public bool IsPlaying { get; set; }
        public bool IsRetired { get; set; }
        public List<Card> FullDeck => deck.Concat(mandatoryCards).ToList();
        public bool SelectionIsFull => AmountCardsSelected >= DeckBuilder.DeckSize;
        public int AmountCardsSelected => deck.Count;
        public bool ISKilled => PhysicTrauma >= (Info.Health ?? 0);
        public bool ISInsane => MentalTrauma >= (Info.Sanity ?? 0);
        public bool IsEliminated => ISKilled || ISInsane || IsRetired;
        public List<string> CardsInDeckIds => deck.ConvertAll(card => card.Code);
        public List<string> MandatoryCardsIds => mandatoryCards.ConvertAll(card => card.Code);

        public bool IsMandatoryCard(Card card) => mandatoryCards.Contains(card);

        public int GetAmountOfThisCardInDeck(string cardId) => FullDeck.FindAll(c => c.Code == cardId).Count;

        public void AddToDeck(Card card) => deck.Add(card);

        public void RemoveToDeck(Card card) => deck.Remove(card);

        public void AddToMandatory(Card card) => mandatoryCards.Add(card);

        public List<Card> FindInDeck(Predicate<Card> filter) => deck.FindAll(filter);

        public int AmountInDeck(Card card) => deck.FindAll(c => c == card).Count;
    }
}
