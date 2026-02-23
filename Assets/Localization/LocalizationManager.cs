using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocalizationManager : MonoBehaviour
{
    /// <summary>
    /// 現在の言語を取得
    /// </summary>
    /// <returns>現在の言語</returns>
    public static string GetCurrentLanguage()
    {
        // 現在のロケールを取得
        Locale currentLocale = LocalizationSettings.SelectedLocale;
        return currentLocale.Identifier.Code;
    }
}
