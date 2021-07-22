using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DoTweenImageController : MonoBehaviour
{
    [SerializeField]
    float colorDuration = 0.5f;

    [SerializeField]
    Color endColor = default;

    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        if (image != null)
        {
            FadeTextIn();
        }
    }

    private void OnEnable()
    {
        Color color = new Color(1, 1, 1, 0);
        image.color = color;
        FadeTextIn();
    }

    public void FadeTextIn()
    {

        Color color = new Color(1, 1, 1, 0);
        image.color = color;
        Sequence Seq = DOTween.Sequence();

        Seq.Append(image.DOColor(color, colorDuration));
        Seq.AppendInterval(1);
        Seq.Append(image.DOColor(endColor, colorDuration));
    }

    public void FadeOut()
    {
        Color color = new Color(1, 1, 1, 1);

        Sequence Seq = DOTween.Sequence();

        Seq.Append(image.DOColor(color, colorDuration));
        Seq.AppendInterval(1);
        Seq.Append(image.DOColor(endColor, colorDuration));
    }
}
