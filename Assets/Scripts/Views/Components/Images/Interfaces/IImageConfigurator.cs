﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Views
{
    public interface IImageConfigurator
    {
        Sprite GetSprite { get; }
        void Activate(bool isEnable);
        void ChangeImage(Sprite sprite);
        void Show(bool isShow);
    }
}
