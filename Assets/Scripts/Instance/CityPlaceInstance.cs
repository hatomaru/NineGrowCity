using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using UnityEngine;

public class CityPlaceInstance : MonoBehaviour
{
    readonly float delation = 0.4f;
    readonly Vector3 defaultScale = new Vector3(0.0521533787f, 1.50971627f, 0.0533473007f);
    public PlaceData placeData { private set; get; }
    public GameObject currentcityPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 変数を初期化
        placeData = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public async UniTask HideCity(CancellationToken token)
    {
        if (currentcityPrefab == null)
        {
            return;
        }
        currentcityPrefab.transform.DOKill();
        currentcityPrefab.transform.DOLocalMoveY(-1.5f, delation * 0.4f).SetEase(Ease.InOutBack);
        currentcityPrefab.transform.DOScale(Vector3.zero, delation * 0.5f).SetEase(Ease.InOutBack).SetDelay(delation * 0.2f)
            .OnComplete(() => { 
                Destroy(currentcityPrefab);
                currentcityPrefab = null;
            });
        placeData = null;
        await UniTask.Delay((int)(delation * 1000 * 0.4f), cancellationToken: token);
    }

    public async UniTask GenCity(CancellationToken token, PlaceData data)
    {
        if (currentcityPrefab != null)
        {
            await HideCity(token);
            currentcityPrefab = null;
        }
        placeData = data;
        GameObject city = Instantiate(data.obj, new Vector3(0, 0, 0), Quaternion.identity);
        city.transform.SetParent(gameObject.transform);
        long cityId = 0;
        foreach (Transform parent in city.transform.parent.gameObject.GetComponentsInChildren<Transform>())
        {
            if (parent != city.transform && !parent.gameObject.CompareTag("Plane"))
            {
                Vector3 scale = parent.transform.localScale;
                parent.transform.localScale = Vector3.zero;
                cityId++;
                parent.transform.DOScale(scale, (delation * 0.8f) * Random.Range(0.8f, 1.5f)).SetEase(Ease.InOutBack).SetDelay(delation * 0.6f + ((delation * 0.02f) * cityId));
            }
        }
        Vector3 localPos = new Vector3(-0.00941732153f, 6.91865826f, -0.00412968826f);
        localPos.y = -1.5f;
        city.transform.localPosition = localPos;
        city.transform.localScale = defaultScale * 0f;
        city.transform.DOLocalMoveY(6.918658f, delation * 1.2f).SetEase(Ease.InOutBack);
        city.transform.DOScale(defaultScale * 0.8f, delation * 0.2f).SetEase(Ease.InOutExpo);
        city.transform.DOScale(defaultScale, delation * 0.8f).SetEase(Ease.InOutBack).SetDelay(delation * 0.2f);
        currentcityPrefab = city;
        await UniTask.Delay((int)(delation * 1000), cancellationToken: token);
    }
}
