using DG.Tweening;
using TMPro;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    RectTransform rect;
    [SerializeField]TextMeshProUGUI notificationText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.localPosition = new Vector3(0, -738, 90);
    }

    /// <summary>
    /// 通知を表示する
    /// </summary>
    /// <param name="message">通知文</param>
    public void Run(string message)
    {
        notificationText.text = message;
        rect.localPosition = new Vector3(0, -738, 90);
        rect.DOKill();
        rect.DOAnchorPosY(-446, 0.3f).SetEase(Ease.OutCubic)
            .OnComplete(() =>
            {
                rect.DOAnchorPosY(-738, 0.45f).SetEase(Ease.InCubic).SetDelay(4.0f);
            });
    }
}
