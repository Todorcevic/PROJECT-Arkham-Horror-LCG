using Arkham.Controllers;
using Arkham.Presenters;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class CardView : MonoBehaviour, IViewInteractable, ICardVisualizable
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactableComponent;
        [SerializeField, Required, ChildGameObjectsOnly] private CardEffects cardEffects;
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;


        public string Id { get; private set; }
        public Sprite GetCardImage => imageConfigurator.GetSprite;
        public Transform Transform => transform;
        public IInteractableEffects InteractableEffects => cardEffects;

        /*******************************************************************/
        [Inject]
        private void Init(string id, Sprite sprite, IController controller)
        {
            name = Id = id;
            imageConfigurator.ChangeImage(sprite);
            interactableComponent.Init(this, controller);
        }

        /*******************************************************************/
        public void Activate(bool isEnable) => imageConfigurator.Activate(isEnable);

        public void Show(bool isShow) => imageConfigurator.Show(isShow);
    }
}
