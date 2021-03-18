using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;
using Arkham.Views;
using DG.Tweening;

namespace Arkham.View
{
    public class SwitchView : MonoBehaviour, IPointerClickHandler
    {
        private bool isOn;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio interactableAudio;
        [SerializeField, Required] private Transform positionOn;
        [SerializeField, Required] private Transform positionOff;
        [SerializeField, Required] private Image button;
        [SerializeField, Required] private Image background;
        [SerializeField, Required] private Image border;
        [Title("SETTINGS")]
        [SerializeField, Required, PropertyTooltip("TAG is required to save")] private string switchTag;
        [SerializeField] private bool saveValue;
        [SerializeField, Range(0f, 1f)] private float timeMoveAnimation;
        [SerializeField] private Color colorOn;
        [SerializeField] private Color colorOff;
        [Title("SWITCH EVENTS")]
        [SerializeField] private UnityEvent OnEvents;
        [SerializeField] private UnityEvent OffEvents;

        /*******************************************************************/
        private void Start()
        {
            if (PlayerPrefs.GetString(switchTag)?.Length == 0 || !saveValue) return;
            isOn = bool.Parse(PlayerPrefs.GetString(switchTag));
            AnimateSwitch();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            isOn = !isOn;
            if (isOn) OnEvents?.Invoke();
            else OffEvents?.Invoke();
            AnimateSwitch();
            if (saveValue) PlayerPrefs.SetString(switchTag, isOn.ToString());
        }

        public void AnimateSwitch()
        {
            interactableAudio.ClickSound();
            button.transform.DOMove(isOn ? positionOn.position : positionOff.position, timeMoveAnimation);
            button.DOColor(isOn ? colorOff : colorOn, timeMoveAnimation);
            border.DOColor(isOn ? colorOff : colorOn, timeMoveAnimation);
            background.DOColor(isOn ? colorOn : colorOff, timeMoveAnimation);
        }
    }
}