using Arkham.Model;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using DG.Tweening;
using System.Linq;

namespace Arkham.Application
{
    public class InvestigatorCardView : CardView
    {
        private InvestigatorStateView currentState;
        [Inject] private readonly AddInvestigatorUseCase addInvestigatorUseCase;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;
        [Inject(Id = "InvestigatorsSelector")] private readonly PlaceHoldersZone dropZone;
        [Title("INVESTIGATOR RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private List<InvestigatorStateView> states;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorToken physicTrauma;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorToken mentalTrauma;
        [SerializeField, Required, ChildGameObjectsOnly] private InvestigatorToken xp;

        /*******************************************************************/
        private void Start()
        {
            Clicked += () => AddCard(dropZone);
            BeginDragged += () => dropZone.Activate(!IsInactive);
            EndDragged += EndDrag;

            void EndDrag(PointerEventData eventData)
            {
                dropZone.Activate(false);
                Debug.Log(eventData.hovered.Count);
                foreach (var das in eventData.hovered)
                    Debug.Log(das);
                PlaceHoldersZone placeHolderZone = eventData.hovered.Select(c => c.GetComponent<PlaceHoldersZone>()).FirstOrDefault();
                if (!showCard.IsShowing)
                    showCard?.MoveAnimation(placeHolderZone?.IsAtive ?? false ? placeHolderZone.transform.position : transform.position);
                AddCard(placeHolderZone);
            }

            void AddCard(PlaceHoldersZone placeHolderZone)
            {
                Debug.Log(placeHolderZone);

                if (IsInactive || placeHolderZone != dropZone)
                {
                    CantAddAnimation();
                    cardShowerPresenter.HideAllShowCards();
                }
                else addInvestigatorUseCase.Add(Id);
                selectInvestigatorUseCase.Select(Id);
            }
        }

        //public void AddCard()
        //{
        //    if (IsInactive)
        //    {
        //        CantAddAnimation();
        //        cardShowerPresenter.HideAllShowCards();
        //    }
        //    else addInvestigatorUseCase.Add(Id);
        //    selectInvestigatorUseCase.Select(Id);
        //}

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
