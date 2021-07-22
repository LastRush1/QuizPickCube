using UnityEngine;
using DG.Tweening;
using TMPro;

public class DoTweenTextController : MonoBehaviour
{
    TextMeshProUGUI text;

    [SerializeField]
    float colorDuration = 0.5f;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        if (text != null)
        {
            FadeTextIn();
        }
    }

    private void OnEnable()
    {
        Color color = new Color(1, 1, 1, 0);
        text.color = color;
        FadeTextIn();
    }


    public void FadeTextIn()
    {

        Color color = new Color(1, 1, 1, 0);
        text.color = color;
        Sequence Seq = DOTween.Sequence();

        Seq.Append(text.DOColor(color, colorDuration));
        Seq.AppendInterval(1);
        color = new Color(1, 1, 1, 1);
        Seq.Append(text.DOColor(color, colorDuration));
    }

    public void FadeOut()
    {
        Color color = new Color(1, 1, 1, 1);

        Sequence Seq = DOTween.Sequence();

        Seq.Append(text.DOColor(color, colorDuration));
        Seq.AppendInterval(1);
        color = new Color(1, 1, 1, 0);
        Seq.Append(text.DOColor(color, colorDuration));
    }
}
