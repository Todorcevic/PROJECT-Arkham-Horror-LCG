using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.EventData
{
    public interface IUnlockCardEvent
    {
        event Action<string> CardUnlocked;
    }
}
