using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using DG.Tweening;
using System.Collections;

namespace Arkham.Application
{
    public class InvestigatorCardController : CardController
    {
        [Inject] private readonly AddInvestigatorUseCase addInvestigatorUseCase;
        [Inject(Id = "InvestigatorsSelector")] private readonly PlaceHoldersZone placeZone;

        /*******************************************************************/
        protected override void Clicked() => addInvestigatorUseCase.Add(cardView.Id);
    }
}
