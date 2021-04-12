using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Presenters
{
    public interface ISwitchView
    {
        bool SaveValue { get; }
        void ClickSound();
        void SwitchAnimation(bool isOn);
    }
}
