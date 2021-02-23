using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class CardActivator : MonoBehaviour
    {
        [SerializeField, Required, ChildGameObjectsOnly] private Image cardImage;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvas;
        [SerializeField] private Color disableColor;
        public Sprite GetCardImage => cardImage.sprite;

        /*******************************************************************/
        public void Enable(bool isEnable)
        {
            cardImage.color = isEnable ? Color.white : disableColor;
            canvas.interactable = isEnable;
            canvas.blocksRaycasts = isEnable;
        }

        public void Show(bool isShow) => gameObject.SetActive(isShow);

        public void SetCardImage(Sprite image) => cardImage.sprite = image;

    }
}
