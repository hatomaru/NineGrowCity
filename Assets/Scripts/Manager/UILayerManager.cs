using UnityEngine;

/// <summary>
/// UIレイヤーの定義
/// </summary>
public enum UILayer
{
    Title,
    Ask,
    Generate,
    HUD,
    Result
}

public class UILayerManager : MonoBehaviour
{
    [SerializeField] GameObject[] uiLayers;

    private void Awake()
    {
        // 全てのUIレイヤーを非表示にする
        foreach (var layer in uiLayers)
        {
            layer.SetActive(false);
        }
        OnUILayer(UILayer.Title);
    }

    /// <summary>
    /// UIを有効化する
    /// </summary>
    /// <param name="layer">対象のレイヤー</param>
    public void OnUILayer(UILayer layer)
    {
       uiLayers[(int)layer].SetActive(true);
    }

    /// <summary>
    /// UIを無効化する
    /// </summary>
    /// <param name="layer">対象のレイヤー</param>
    public void OffUILayer(UILayer layer)
    {
        uiLayers[(int)layer].SetActive(true);
    }
}
