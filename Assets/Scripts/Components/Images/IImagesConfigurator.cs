using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Components
{
    public interface IImagesConfigurator
    {
        void Activate(bool isEnable);
        void ChangeImage(Sprite sprite);
    }
}
