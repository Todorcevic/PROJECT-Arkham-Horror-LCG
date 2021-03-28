using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class CardSelectorView : SelectorView, ICardSelectorView
    {
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private CardSelectorEffects effects;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private TextRefresher textRefresher;

        /*******************************************************************/
        public void SetName(string cardName) => textRefresher.SetName(cardName);
        public void SetQuantity(int quantity) => textRefresher.SetQuantity(quantity);
        public void ClickEffect() => effects.ClickEffect();
        public void HoverOnEffect() => effects.HoverOnEffect();
        public void HoverOffEffect() => effects.HoverOffEffect();
    }
}
