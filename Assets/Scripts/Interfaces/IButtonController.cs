using Arkham.UI;

namespace Arkham.Controller
{
    public interface IButtonController
    {
        void Click(ButtonComponent button);
        void HoverEnter(ButtonComponent button);
        void HoverExit(ButtonComponent button);
    }
}
