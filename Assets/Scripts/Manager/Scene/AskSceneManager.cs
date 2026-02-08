using TMPro;
using UnityEngine;

public class AskSceneManager : MonoBehaviour
{
    [SerializeField]TMP_InputField inputField;
    GameLoopManager manager;

    void Awake()
    {
        manager = GameObject.Find("GameLoop").GetComponent<GameLoopManager>();
    }


    public void Init()
    {
        inputField.text = "";    
    }

    public string GetInput()
    {
        return inputField.text;
    }

    public void OnClick()
    {
        manager.ToNextStatus();
    }
}
