using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Components
{
    public interface IInteractable
    {
        void AddClickAction(Action action);
        void AddDoubleClickAction(Action action);
        void AddHoverOnAction(Action action);
        void AddHoverOffAction(Action action);
    }
}
