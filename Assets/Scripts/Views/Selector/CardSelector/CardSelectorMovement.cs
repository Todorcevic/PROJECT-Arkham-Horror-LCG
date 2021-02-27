using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Views
{
    public class CardSelectorMovement : MonoBehaviour
    {
        [SerializeField, Required] private Transform selector;
        [SerializeField, Required] private Transform placeHolder;
        [SerializeField, Range(0f, 1f)] private float timeMoveAnimation;

        /*******************************************************************/
        public void MoveTo(Transform transform) => selector.position = transform.position;

        public void Arrange(Transform transform)
        {
            placeHolder.SetParent(transform);
            StartCoroutine(Reorder());
        }

        private IEnumerator Reorder()
        {
            yield return null;
            selector.DOMove(placeHolder.position, timeMoveAnimation);
        }
    }
}
