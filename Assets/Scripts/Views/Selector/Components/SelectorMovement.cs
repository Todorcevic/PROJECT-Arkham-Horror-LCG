using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace Arkham.Views
{
    public class SelectorMovement : MonoBehaviour
    {
        [SerializeField, Required] private Transform selector;
        [SerializeField, Required] private Transform placeHolder;
        [SerializeField, Range(0f, 1f)] private float timeMoveAnimation;

        /*******************************************************************/
        public void MoveImageTo(Transform transform) => selector.position = transform.position;

        public void SetPlaceHolderParentTo(Transform transform) => placeHolder.SetParent(transform);

        public void Arrange() => StartCoroutine(Reorder());

        private IEnumerator Reorder()
        {
            yield return null;
            selector.DOMove(placeHolder.position, timeMoveAnimation);
        }
    }
}
