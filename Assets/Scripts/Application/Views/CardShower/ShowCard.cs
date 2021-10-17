using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class ShowCard : MonoBehaviour
{
    [Title("RESOURCES")]
    [SerializeField, Required, ChildGameObjectsOnly] private Image frontImage;
    [SerializeField, Required, ChildGameObjectsOnly] private Image backImage;
    [Title("SETTINGS")]
    [SerializeField, Range(0f, 1f)] private float timeAnimation;
    [SerializeField, Range(0f, 1f)] private float delay;
    [SerializeField, Range(1f, 2f)] private float scale;
    [SerializeField, Range(0f, 1f)] private float dragScale;

    public string Id { get; private set; }
    public bool IsActive => Id != string.Empty;
    public bool IsMoving => DOTween.IsTweening(MoveTweenId);
    public bool IsShowing => DOTween.IsTweening(ShowTweenId);

    private string ShowTweenId => "Show" + transform.name;
    private string MoveTweenId => "Move" + transform.name;

    /*******************************************************************/
    public void Active(string cardId, Sprite frontCardSprite, Sprite backCardSprite)
    {
        Id = cardId;
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
        Id = string.Empty;
        DOTween.Kill(ShowTweenId);
        frontImage.gameObject.SetActive(false);
        backImage.gameObject.SetActive(false);
        gameObject.SetActive(false);
        transform.localScale = Vector2.zero;
    }

    public void ShowAnimation(Vector2 positionToMove) => DOTween.Sequence()
        .Append(transform.DOMove(positionToMove, timeAnimation).SetDelay(delay))
        .Join(transform.DOScale(scale, timeAnimation)
        .SetDelay(delay)).SetId(ShowTweenId);


    public Tween MoveAnimation(Vector2 positionToMove) => DOTween.Sequence()
        .Append(transform.DOMove(positionToMove, timeAnimation))
        .Join(transform.DOScale(0, timeAnimation))
        .AppendCallback(Hide).SetId(MoveTweenId);

    public void Dragging()
    {
        DOTween.Kill(ShowTweenId);
        DesactiveBackImage();
        transform.DOScale(dragScale, timeAnimation);

        void DesactiveBackImage()
        {
            backImage.gameObject.SetActive(false);
            backImage.sprite = null;
        }
    }
}
