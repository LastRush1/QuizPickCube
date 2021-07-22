using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class DoTweenAnimationController : MonoBehaviour
{
    [SerializeField]
    float scaleDuration = 0.5f;

    [SerializeField]
    AnimationCurve animationCurve = default;

    GameObject obj;

    RectTransform trans;




    private void Awake()
    {
        obj = gameObject;
        trans = GetComponent<RectTransform>();
    }

    public void BounceAnimation()
    {
        Sequence Seq = DOTween.Sequence();

        Vector3 vector3 = new Vector3(0, 0, 0);

        Seq.Append(trans.DOScale(vector3, scaleDuration));
        Seq.AppendInterval(0.03f);
        vector3 = new Vector3(1.2f, 1.2f);
        Seq.Append(trans.DOScale(vector3, scaleDuration));
        Seq.AppendInterval(0.03f);
        vector3 = new Vector3(0.95f, 0.95f);
        Seq.Append(trans.DOScale(vector3, scaleDuration));
        Seq.AppendInterval(0.03f);
        vector3 = new Vector3(1, 1);
        Seq.Append(trans.DOScale(vector3, scaleDuration));
    }

    public void EaseInBounce()
    {

        Sequence Seq = DOTween.Sequence();

        float sec = 0.1f;

        Vector3 vector3 = new Vector3(animationCurve.Evaluate(sec), animationCurve.Evaluate(sec), 0);

        Seq.Append(trans.DOScale(animationCurve.Evaluate(sec), scaleDuration));
        //Seq.Join(trans.DOMove(vector3, scaleDuration));
        Seq.AppendInterval(sec);
        vector3 = new Vector3(animationCurve.Evaluate(sec), animationCurve.Evaluate(sec), 0);
        sec = 0.3f;
        Seq.Append(trans.DOScale(animationCurve.Evaluate(sec), scaleDuration));
        //Seq.Join(trans.DOMove(vector3, scaleDuration));
        Seq.AppendInterval(sec);
        vector3 = new Vector3(animationCurve.Evaluate(sec), animationCurve.Evaluate(sec), 0);
        sec = 0.7f;
        Seq.Append(trans.DOScale(animationCurve.Evaluate(sec), scaleDuration));
        //Seq.Join(trans.DOMove(vector3, scaleDuration));
        Seq.AppendInterval(sec);
        vector3 = new Vector3(animationCurve.Evaluate(sec), animationCurve.Evaluate(sec), 0);
        sec = 1;
        Seq.Append(trans.DOScale(new Vector3(1,1,0), scaleDuration));
        //Seq.Join(trans.DOMove(new Vector3(0, 0, 0), scaleDuration));


    }
}
