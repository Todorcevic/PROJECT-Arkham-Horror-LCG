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
        [SerializeField, Required] private Transform objectToMove;
        [SerializeField, Required] private Transform placeHolder;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeMoveAnimation;

        public Transform PlaceHolder => placeHolder;

        /*******************************************************************/
        public void MoveImageTo(Transform transform) => objectToMove.position = transform.position;

        public void SetTransform(Transform transform = null)
        {
            placeHolder.SetParent(transform ? transform : this.transform, worldPositionStays: false);
            placeHolder.localPosition = Vector3.zero;
        }

        public void Arrange() => StartCoroutine(ArrangeTo());

        private IEnumerator ArrangeTo()
        {
            yield return null;
            yield return objectToMove.DOMove(placeHolder.position, timeMoveAnimation).WaitForCompletion();
        }

        public void SwapPlaceHolder(Transform selectorDragging)
        {
            int indexToSwap = selectorDragging.GetSiblingIndex();
            selectorDragging.SetSiblingIndex(placeHolder.GetSiblingIndex());
            placeHolder.SetSiblingIndex(indexToSwap);
        }
    }
}
