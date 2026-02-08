using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    int selectCity = 0;
    [SerializeField] CityPlaceInstance[] cityPlaces;
    [SerializeField] GameObject testCity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var cityPlace in cityPlaces)
        {
            if (Random.Range(0, 2) == 0)
            {
                cityPlace.GenCity(destroyCancellationToken,testCity).Forget();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 都市に建物を生成する
    /// </summary>
    /// <param name="genre">建物のジャンル</param>
    /// <returns></returns>
    public async UniTask GenCity(CancellationToken token,string genre)
    {
       await cityPlaces[selectCity].GenCity(token,testCity);
    }

    /// <summary>
    /// 都市を成長させる
    /// </summary>
    /// <param name="tartget">成長させる建物</param>
    /// <param name="placeData">設置する建物</param>
    /// <returns></returns>
    public async UniTask GrowCity(CancellationToken token,int tartget, PlaceData placeData)
    {
        await cityPlaces[tartget].GenCity(token, placeData.obj);
    }
}
