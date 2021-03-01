﻿using Arkham.Services;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public abstract class InteractableComponent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IInitializable
    {
        [Inject] private readonly IDoubleClickDetector clickDetector;
        public event Action Clicked;
        public event Action DoubleClicked;
        public event Action HoverOn;
        public event Action HoverOff;

        /*******************************************************************/
        public void Initialize()
        {
            Clicked += ClickEffect;
            DoubleClicked += DoubleClickEffect;
            HoverOn += HoverOnEffect;
            HoverOff += HoverOffEffect;
        }

        /*******************************************************************/
        public abstract void ClickEffect();
        public abstract void DoubleClickEffect();
        public abstract void HoverOnEffect();
        public abstract void HoverOffEffect();

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickDetector.CheckDoubleClick(eventData.clickTime, eventData.pointerPress))
                DoubleClicked?.Invoke();
            else Clicked?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => HoverOn?.Invoke();

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => HoverOff?.Invoke();
    }
}
