using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;
using Arkham.Controller;

namespace Arkham.UI
{
    public class TabComponent : ButtonComponent
    {
        private void Start()
        {
            controller = new TabController();
        }

        public void Activate()
        {
            ChangeTextColor(HoverColor);
            FillBackground(true);
        }

        public void Desactivate()
        {
            ChangeTextColor(SimpleColor);
            FillBackground(false);
        }
    }
}