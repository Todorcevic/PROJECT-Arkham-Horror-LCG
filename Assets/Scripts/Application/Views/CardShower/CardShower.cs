using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arkham.Application
{
    public class CardShower : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private List<ShowCard> showCards;

        /*******************************************************************/
        public void AddShowableAndShow(IShowable showableCard)
        {
            ShowCard showCard = GetFreeShowCard();
            showCard.SetShowableCard(showableCard);
            showCard.ShowAnimation(showableCard.ShowPosition);
        }

        public void RemoveShowableAndHide(IShowable showableCar)
        {
            ShowCard showCard = GetThisShowCard(showableCar);
            showCard?.Clean();
            showCard?.Hide();
        }

        public void Move(IShowable showableCard, Vector2 positionToMove)
        {
            ShowCard showCard = GetThisShowCard(showableCard);
            if (showCard.IsShowing) AddShowableAndShow(showableCard);
            showCard.Clean();
            showCard.MoveAnimation(positionToMove);
        }

        private ShowCard GetFreeShowCard() => showCards.Last(showCard => !showCard.IsShowing && !showCard.IsMoving);
        private ShowCard GetThisShowCard(IShowable showable) => showCards.Find(showCard => showCard.ShowableCard == showable);
    }
}
