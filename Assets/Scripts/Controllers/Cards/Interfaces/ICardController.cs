using Arkham.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Controllers
{
    public interface ICardController
    {
        void Init(ICardView cardView);
    }
}
