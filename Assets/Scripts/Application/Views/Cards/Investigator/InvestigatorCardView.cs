using Arkham.Model;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using DG.Tweening;

namespace Arkham.Application
{
    public class InvestigatorCardView : CardView
    {
        private InvestigatorStateView currentState;
        [Inject] private readonly AddInvestigatorUseCase addInvestigatorUseCase;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;
        //[Inject(Id = "InvestigatorSelector")] private readonly PlaceHoldersZone placeHoldersZone;
        [Title("INVESTIGATOR RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private List<InvestigatorStateView> states;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorToken physicTrauma;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorToken mentalTrauma;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorToken xp;

        /*******************************************************************/
        private void Start()
        {
            Clicked += AddCard;

            BeginDragged += () => dropZone.Activate(!IsInactive);


            EndDragged += () =>
            {
                if (IsInactive) showCard.MoveAnimation(transform.position);
                dropZone.Activate(false);
            };
        }

        public void AddCard()
        {
            if (IsInactive)
            {
                CantAddAnimation();
                cardShowerPresenter.HideAllShowCards(showCard);
            }
            else addInvestigatorUseCase.Add(Id);
            selectInvestigatorUseCase.Select(Id);
        }

        public void DropCard()
        {
            if (IsInactive) return;
            //showCard.MoveAnimation(dropZone.transform.position);
            addInvestigatorUseCase.Add(Id);
            selectInvestigatorUseCase.Select(Id);

        }

        public void ChangeState(InvestigatorState state)
        {
            currentState?.Activate(false);
            currentState = states.Find(invState => invState.State == state);
            currentState?.Activate(true);
        }

        public void UpdatePhysicTrauma(int amount) => physicTrauma.UpdateAmount(amount);

        public void UpdateMentalTrauma(int amount) => mentalTrauma.UpdateAmount(amount);

        public void UpdateXp(int amount) => xp.UpdateAmount(amount);
    }
}
