using Arkham.Components;
using Arkham.ScriptableObjects;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class CardView : MonoBehaviour, ICardView
    {
        private const float ORIGINAL_SCALE = 1.0f;
        private string id;

        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private CardEffects cardEffects;
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        [SerializeField, Required, ChildGameObjectsOnly] private CardActivator cardActivator;

        public string Id => id;
        public Sprite GetCardImage => cardActivator.GetCardImage;
        public Transform Transform => transform;
        public InteractableComponent Interactable => interactable;

        /*******************************************************************/
        public void Init(string id, Sprite sprite)
        {
            name = this.id = id;
            cardActivator.SetCardImage(sprite);
            interactable.DoubleClicked += cardEffects.DoubleClickEffect;
            interactable.HoverOn += cardEffects.HoverOnEffect;
            interactable.HoverOff += cardEffects.HoverOffEffect;
        }

        public void Enable(bool isEnable) => cardActivator.Enable(isEnable);

        public void Show(bool isShow) => cardActivator.Show(isShow);
    }
}
