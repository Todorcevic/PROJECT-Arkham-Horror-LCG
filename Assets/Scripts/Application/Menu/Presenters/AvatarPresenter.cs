﻿using Arkham.Model;
using UnityEngine;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class AvatarPresenter
    {
        [Inject] private readonly AvatarView avatartView;
        [Inject] private readonly CardsManager investigatorCardsManager;
        [Inject] private readonly DotweenService dotweenService;

        /*******************************************************************/
        public void SetAvatar(Investigator investigator) => dotweenService.SwapImage(avatartView.transform, () => UpdateAvatar(investigator));

        public void UpdateAvatar(Investigator investigator)
        {
            Sprite imageCard = investigatorCardsManager.GetSpriteCard(investigator?.Id);
            avatartView.SetAvatar(imageCard, investigator?.PhysicTrauma ?? 0, investigator?.MentalTrauma ?? 0, investigator?.Xp ?? 0);
        }
    }
}
