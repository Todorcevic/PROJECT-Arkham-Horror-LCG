using System.Collections.Generic;
using UnityEngine;

namespace Arkham.View
{
    public interface ICardsManager
    {
        List<CardView> AllCards { get; }
        List<CardView> DeckList { get; }
        List<CardInvestigatorView> InvestigatorList { get; }
        CardView GetDeckCard(string cardId);
        CardView GetInvestigatorCard(string cardId);
        void AddDeckCard(string cardId, CardView cardView);
        void AddInvestigatorCard(string cardId, CardInvestigatorView cardView);
        Sprite GetSpriteCard(string id);
    }
}
