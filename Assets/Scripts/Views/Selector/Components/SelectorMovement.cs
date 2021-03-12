using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using UnityEngine;

namespace Arkham.Views
{
    public class SelectorMovement : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required] private Transform cardImage;
        [SerializeField, Required] private Transform placeHolder;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeMoveAnimation;

        public Transform PlaceHolder => placeHolder;

        /*******************************************************************/
        public void MoveImageTo(Transform transform) => cardImage.position = transform.position;

        public void SetTransform(Transform transform) => placeHolder.SetParent(transform, worldPositionStays: false);

        public IEnumerator ArrangeTo()
        {
            yield return null;
            cardImage.DOMove(placeHolder.position, timeMoveAnimation);
        }

        public void SwapPlaceHolder(Transform selectorDragging)
        {
            int indexToSwap = selectorDragging.GetSiblingIndex();
            selectorDragging.SetSiblingIndex(placeHolder.GetSiblingIndex());
            placeHolder.SetSiblingIndex(indexToSwap);
        }
    }
}
