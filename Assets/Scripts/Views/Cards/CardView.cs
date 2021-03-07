using Arkham.Controllers;
using Arkham.Presenters;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class CardView : ViewInteractable, ICardVisualizable
    {
        private string id;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private CardInteractable cardInteractable;
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;

        public Sprite GetCardImage => imageConfigurator.GetSprite;
        public Transform Transform => transform;
        public override string Id => id;
        public override IInteractableEffects InteractableEffects => cardInteractable;

        /*******************************************************************/
        [Inject]
        private void Init(string id, Sprite sprite)
        {
            name = this.id = id;
            imageConfigurator.ChangeImage(sprite);
        }

        /*******************************************************************/
        public void Activate(bool isEnable) => imageConfigurator.Activate(isEnable);

        public void Show(bool isShow) => imageConfigurator.Show(isShow);
    }
}
