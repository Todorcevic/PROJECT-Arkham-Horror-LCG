using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Arkham.Application.MainMenu
{
    public class ButtonIconView : MonoBehaviour
    {
        private const float SCALE = 1.1f;
        [Title("RESOURCES")]
        [SerializeField] private Image glow;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private CanvasGroup canvas;
        [Title("SETTINGS")]
        [SerializeField] private string textToShow;
        [SerializeField] private bool clickSound;

        public bool IsInactive { get; private set; }
        public bool IsClickSound => clickSound;
        public event Action ClickAction;

        /*******************************************************************/
        public void Activate(bool isActive)
        {
            canvas.alpha = isActive ? 1 : 0;
            canvas.interactable = isActive;
            canvas.blocksRaycasts = isActive;
        }

        public void Desactive(bool isInactive)
        {
            IsInactive = isInactive;
            glow.color = isInactive ? ViewValues.DISABLE_COLOR : ViewValues.ENABLE_COLOR;
        }

        public void PointerClick() => ClickAction?.Invoke();

        public void HoverOnEffect()
        {
            if (!string.IsNullOrEmpty(textToShow))
            {
                glow.DOFillAmount(1, ViewValues.FAST_TIME);
                text.DOText(textToShow, ViewValues.FAST_TIME);
            }
            transform.DOScale(SCALE, ViewValues.FAST_TIME);
        }

        public void HoverOffEffect()
        {
            glow.DOFillAmount(0, ViewValues.FAST_TIME);
            text.DOText(string.Empty, ViewValues.FAST_TIME);
            transform.DOScale(1f, ViewValues.FAST_TIME);
        }

        public void CantAdd()
        {
            DOTween.Complete(gameObject.GetInstanceID());
            transform.DOPunchPosition(Vector3.right * 20, ViewValues.FAST_TIME, 40, 5).SetId(gameObject.GetInstanceID());
        }
    }
}
