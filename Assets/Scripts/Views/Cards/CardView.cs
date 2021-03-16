using Arkham.Presenters;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class CardView : MonoBehaviour, ICardVisualizable, IPointerEnterHandler, IPointerExitHandler
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] protected CardEffects effects;
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;

        public string Id { get; private set; }
        public Sprite GetCardImage => imageConfigurator.GetSprite;
        public Vector3 Position => transform.position;
        public bool IsInactive { get; set; }

        /*******************************************************************/
        [Inject]
        private void Init(string id, Sprite sprite)
        {
            name = Id = id;
            imageConfigurator.ChangeImage(sprite);
        }

        /*******************************************************************/
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            effects.HoverOnEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            effects.HoverOffEffect();
        }

        public void Activate(bool isEnable)
        {
            IsInactive = !isEnable;
            imageConfigurator.ChangeColor(isEnable ? Color.white : Color.gray);
        }
    }
}
