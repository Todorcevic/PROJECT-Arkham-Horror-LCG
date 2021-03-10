using Arkham.Views;
using UnityEngine;

namespace Arkham.Presenters
{
    public interface IInvestigatorSelector : ISelector
    {
        SelectorMovement SelectorMovement { get; }
        LeadActivator LeadActivator { get; }
    }
}
