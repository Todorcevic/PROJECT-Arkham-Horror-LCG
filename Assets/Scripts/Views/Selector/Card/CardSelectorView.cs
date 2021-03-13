using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class CardSelectorView : SelectorView
    {
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private CardSelectorEffects effects;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private TextRefresher textRefresher;

        public CardSelectorEffects Effects => effects;
        public TextRefresher TextRefresher => textRefresher;

        /*******************************************************************/
        public override void SetSelector(string cardId, Sprite cardImage = null)
        {
            Id = cardId;
            imageConfigurator.ChangeImage(cardImage);
            imageConfigurator.Activate(cardImage != null);
        }
    }
}
