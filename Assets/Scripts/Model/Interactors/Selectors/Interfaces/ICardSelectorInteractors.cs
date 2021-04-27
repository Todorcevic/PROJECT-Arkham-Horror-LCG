using Arkham.Entities;
using System;

namespace Arkham.Interactors
{
    public interface ICardSelectorInteractors
    {
        bool CanThisCardBeSelected(string cardId);
        bool CanThisCardBeShowed(string cardId);
    }
}
