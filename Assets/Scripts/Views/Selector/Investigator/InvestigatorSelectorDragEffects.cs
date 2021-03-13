using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class InvestigatorSelectorDragEffects : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required] private Canvas canvas;
        [SerializeField, Required] private Transform view;
        [SerializeField, Required] private InteractableAudio audioInteractable;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;

        /*******************************************************************/
        public void BeginningDrag() => canvas.sortingOrder = 2;

        public void Dragging(Vector2 movePosition) => view.position = movePosition;

        public void EndingDrag()
        {
            canvas.sortingOrder = 1;
            audioInteractable.HoverOffSound();
            view.DOScale(1f, timeHoverAnimation);
        }
    }
}
