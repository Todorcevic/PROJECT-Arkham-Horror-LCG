using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Views
{
    public interface ICardsManager
    {
        List<CardView> AllCards { get; }
        List<CardView> DeckList { get; }
        List<CardView> InvestigatorList { get; }
        CardView GetDeckCard(string cardId);
        CardView GetInvestigatorCard(string cardId);
        void AddDeckCard(string cardId, CardView cardView);
        void AddInvestigatorCard(string cardId, CardView cardView);
        Sprite GetSpriteCard(string id);
    }
}
