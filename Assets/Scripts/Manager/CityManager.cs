using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    int selectCity = 0;
    public CityPlaceInstance[] cityPlaces;
    [SerializeField] PlaceData testCity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var cityPlace in cityPlaces)
        {
            if (Random.Range(0, 2) == 0)
            {
                cityPlace.GenCity(destroyCancellationToken, testCity).Forget();
            }
        }
    }

    public async UniTask AllHideCity(CancellationToken token)
    {
        foreach (var cityPlace in cityPlaces)
        {
            if(cityPlace.currentcityPrefab == null)
            {
                continue;
            }
            await cityPlace.HideCity(token);
            await UniTask.Delay(25, cancellationToken: token);
        }
    }

    /// <summary>
    /// 都市に建物を生成する
    /// </summary>
    /// <param name="data">建物のデータ</param>
    /// <returns></returns>
    public async UniTask GenCity(CancellationToken token, PlaceData data)
    {
        if (!isEnableArea(selectCity))
        {
            Debug.LogError($"指定された都市エリアのインデックスが不正です。：{selectCity}");
            return;
        }
        await cityPlaces[selectCity].GenCity(token, testCity);
    }

    /// <summary>
    /// 都市を成長させる
    /// </summary>
    /// <param name="target">成長させる建物</param>
    /// <param name="data">建物のデータ</param>
    /// <returns></returns>
    public async UniTask GrowCity(CancellationToken token, int target, PlaceData placeData)
    {
        if (!isEnableArea(target))
        {
            return;
        }
        await cityPlaces[target].GenCity(token, placeData);
    }

    /// <summary>
    /// 入力したインデックスが有効な都市エリアかどうかを確認する
    /// </summary>
    /// <param name="index">インデックス</param>
    /// <returns>有効なインデックスか</returns>
    public bool isEnableArea(int index)
    {
        return index < cityPlaces.Length && index >= 0;
    }
}
