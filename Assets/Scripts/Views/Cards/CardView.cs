using Arkham.Controllers;
using Arkham.Presenters;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class CardView : MonoBehaviour, ICardVisualizable, IViewInteractable
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;

        public string Id { get; private set; }
        public Sprite GetCardImage => imageConfigurator.GetSprite;
        public Transform Transform => transform;
        public InteractableComponent Interactable => interactable;

        /*******************************************************************/
        [Inject]
        private void Init(string id, Sprite sprite)
        {
            name = Id = id;
            imageConfigurator.ChangeImage(sprite);
        }

        /*******************************************************************/
        public void Activate(bool isEnable) => imageConfigurator.Activate(isEnable);

        public void Show(bool isShow) => imageConfigurator.Show(isShow);
    }
}
