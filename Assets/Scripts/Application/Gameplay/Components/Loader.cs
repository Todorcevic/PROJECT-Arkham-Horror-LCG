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
        [Inject] private readonly ZonesManager zonesManager;

        /*******************************************************************/
        private void Awake()
        {
            mapper.MapZones(zonesManager.AllZones);
            dataContext.LoadGameCards();
            cardFactory.BuildCards();
        }

        private void OnDestroy() => DOTween.KillAll();
    }
}
