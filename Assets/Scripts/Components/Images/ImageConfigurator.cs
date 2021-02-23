using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Components
{
    public class ImageConfigurator : MonoBehaviour, IImagesConfigurator
    {
        [SerializeField] private CanvasGroup canvas;
        [SerializeField] private Image image;

        /*******************************************************************/
        public void Activate(bool isEnable)
        {
            canvas.interactable = isEnable;
            canvas.blocksRaycasts = isEnable;
        }

        public void ChangeImage(Sprite sprite)
        {
            canvas.alpha = sprite == null ? 0 : 1;
            image.sprite = sprite;
        }
    }
}
