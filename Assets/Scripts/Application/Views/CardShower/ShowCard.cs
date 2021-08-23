using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowCard : MonoBehaviour
{
    private string id;

    [Title("RESOURCES")]
    [SerializeField, Required, ChildGameObjectsOnly] private Image frontImage;
    [SerializeField, Required, ChildGameObjectsOnly] private Image backImage;
    [Title("SETTINGS")]
    [SerializeField, Range(0f, 1f)] private float timeAnimation;
    [SerializeField, Range(0f, 1f)] private float delay;
    [SerializeField, Range(1f, 2f)] private float scale;

    public string Id => id;


    /*******************************************************************/
    public void Active(string cardId, Sprite frontCardSprite, Sprite backCardSprite)
    {
        id = cardId;
        ActiveFrontImage();
        ActiveBackImage();

        void ActiveFrontImage()
        {
            frontImage.gameObject.SetActive(true);
            frontImage.sprite = frontCardSprite;
        }

        void ActiveBackImage()
        {
            if (backCardSprite == null) return;
            backImage.gameObject.SetActive(true);
            backImage.sprite = backCardSprite;
        }
    }

    public void Hide()
    {
        DOTween.Kill(name);
        frontImage.gameObject.SetActive(false);
        backImage.gameObject.SetActive(false);
        gameObject.SetActive(false);
        id = string.Empty;
        transform.localScale = Vector2.zero;
    }

    public void ShowAnimation(Vector2 positionToMove) => DOTween.Sequence()
        .Append(transform.DOMove(positionToMove, timeAnimation).SetDelay(delay))
        .Join(transform.DOScale(scale, timeAnimation)
        .SetDelay(delay)).SetId(name);


    public Tween MoveAnimation(Vector2 positionToMove) => DOTween.Sequence()
        .Append(transform.DOMove(positionToMove, timeAnimation))
        .Join(transform.DOScale(0, timeAnimation))
        .AppendCallback(Hide);
}
