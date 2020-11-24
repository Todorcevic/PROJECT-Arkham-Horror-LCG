using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;

namespace Arkham.UI
{
    public class MainButtonComponent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private Color simpleColor = Color.black;
        private Color hoverColor = Color.white;

        [Header("RESOURCES")]
        [SerializeField] private Image background;
        [SerializeField] private TextMeshProUGUI text;

        [Header("SETTINGS")]
        [SerializeField] [Range(0f, 1f)] private float timeAnimation;

        [Header("AUDIO")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip clickSound;
        [SerializeField] private AudioClip hoverEnterSound;
        [SerializeField] private AudioClip hoverExitSound;

        private Tween ChangeTextColor(Color color, float time) => text.DOColor(color, time);
        private Tween FillBackground(bool toFill, float time) => background.DOFillAmount(toFill ? 1 : 0, time);
        private void PlaySound(AudioClip clip) => audioSource.PlayOneShot(clip);

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            PlaySound(clickSound);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            PlaySound(hoverEnterSound);
            ChangeTextColor(simpleColor, timeAnimation).Play();
            FillBackground(true, timeAnimation).Play();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            PlaySound(hoverExitSound);
            ChangeTextColor(hoverColor, timeAnimation).Play();
            FillBackground(false, timeAnimation).Play();
        }
    }
}
