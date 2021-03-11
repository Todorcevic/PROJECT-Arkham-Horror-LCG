﻿using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace Arkham.Views
{
    public class SelectorMovement : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, ChildGameObjectsOnly, Required] private Transform selector;
        [SerializeField, ChildGameObjectsOnly, Required] private Transform placeHolder;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeMoveAnimation;

        /*******************************************************************/
        public void MoveImageTo(Transform transform) => selector.position = transform.position;

        public void ArrangeTo(Transform transform)
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
