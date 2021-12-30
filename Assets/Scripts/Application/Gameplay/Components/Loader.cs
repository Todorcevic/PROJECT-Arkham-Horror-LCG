using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Arkham.Application.GamePlay
{
    public class Loader : MonoBehaviour
    {
        [Inject] private readonly DataContextService dataContext;
        [Inject] private readonly DataMapperService mapper;
        [Inject] private readonly CardFactory cardFactory;

        /*******************************************************************/
        private void Awake()
        {
            dataContext.LoadGameCards();
            mapper.MapZones();
            cardFactory.BuildCards();
        }

        private void OnDestroy() => DOTween.Clear();
    }
}
