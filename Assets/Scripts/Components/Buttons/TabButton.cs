using UnityEngine;
using UnityEngine.EventSystems;
using Arkham.Controller;
using Sirenix.OdinInspector;

namespace Arkham.UI
{
    public class TabButton : ButtonComponent, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private TabController tabController;

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (tabController.IsCurrentTab(this)) return;
            tabController.SelectTab(this);
            PlaySound(clickSound);
            clickAction?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (tabController.IsCurrentTab(this)) return;
            PlaySound(hoverEnterSound);
            HoverActivate();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (tabController.IsCurrentTab(this)) return;
            PlaySound(hoverExitSound);
            HoverDesactivate();
        }
    }
}