﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Views
{
    public class CardDeckController : CardController
    {
        public override void DoubleClick()
        {
        }

        protected override int AmountSelected()
        {
            return 0;
        }
    }
}
