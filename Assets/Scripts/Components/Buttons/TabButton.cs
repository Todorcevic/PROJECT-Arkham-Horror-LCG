using UnityEngine;
using UnityEngine.EventSystems;
using Arkham.Manager;

namespace Arkham.UI
{
    public class TabButton : ButtonComponent, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("TAB MANAGER")]
        [SerializeField] private TabController tabManager;

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (tabManager.IsCurrentTab(this)) return;
            tabManager.SelectTab(this);
            PlaySound(ClickSound);
            ClickAction?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (tabManager.IsCurrentTab(this)) return;
            PlaySound(HoverEnterSound);
            HoverActivate();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (tabManager.IsCurrentTab(this)) return;
            PlaySound(HoverExitSound);
            HoverDesactivate();
        }
    }
}