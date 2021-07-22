using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    #region Singleton

    public static UIController Instance;

    #endregion

    [SerializeField]
    TextMeshProUGUI infoText = default;


    void Awake()
    {
        Instance = this;
    }

    public void InfoText(string text)
    {
        infoText.text = text;
    }



}
