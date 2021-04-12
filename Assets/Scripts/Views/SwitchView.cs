using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using DG.Tweening;
using Arkham.Presenters;

namespace Arkham.Views
{
    public class SwitchView : MonoBehaviour, ISwitchView
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio interactableAudio;
        [SerializeField, Required] private Transform positionOn;
        [SerializeField, Required] private Transform positionOff;
        [SerializeField, Required] private Image button;
        [SerializeField, Required] private Image background;
        [SerializeField, Required] private Image border;
        [Title("SETTINGS")]
        [SerializeField] private bool saveValue;
        [SerializeField, Range(0f, 1f)] private float timeMoveAnimation;
        [SerializeField] private Color colorOn;
        [SerializeField] private Color colorOff;

        public bool SaveValue => saveValue;

        /*******************************************************************/
        public void ClickSound() => interactableAudio.ClickSound();

        public void SwitchAnimation(bool isOn)
        {
            button.transform.DOMove(isOn ? positionOn.position : positionOff.position, timeMoveAnimation);
            button.DOColor(isOn ? colorOff : colorOn, timeMoveAnimation);
            border.DOColor(isOn ? colorOff : colorOn, timeMoveAnimation);
            background.DOColor(isOn ? colorOn : colorOff, timeMoveAnimation);
        }
    }
}