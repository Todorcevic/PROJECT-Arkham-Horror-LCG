using Arkham.Components;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class CardView : MonoBehaviour, ICardView
    {
        private string id;

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        [SerializeField, Required, ChildGameObjectsOnly] private ImageStateComponent imageState;

        public string Id => id;
        public Sprite GetCardImage => imageState.GetSprite;
        public Transform Transform => transform;
        public InteractableComponent Interactable => interactable;

        /*******************************************************************/
        public void Init(string id, Sprite sprite)
        {
            name = this.id = id;
            imageState.ChangeImage(sprite);
            interactable.Init();
        }

        public void Activate(bool isEnable) => imageState.Activate(isEnable);

        public void Show(bool isShow) => imageState.Show(isShow);
    }
}
