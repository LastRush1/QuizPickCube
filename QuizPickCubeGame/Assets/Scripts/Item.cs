using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour,IPickItem
{
    [SerializeField]
    string itemName = default;

    [SerializeField]
    Image itemIcone = default;

    RectTransform trans;

    DoTweenAnimationController doTween;

    DoTweenAnimationController iconTween;

    [SerializeField]
    ParticleSystem particle = default;

    /// <summary>
    /// Заполняем префаб
    /// </summary>
    /// <param name="sprite"></param>
    /// <param name="name"></param>
    public void Inizialization(Sprite sprite, string name)
    {
        itemIcone.transform.localScale = new Vector3(1, 1, 1);
        itemName = name;
        itemIcone.overrideSprite = sprite;
        itemIcone.transform.localPosition = new Vector3(0, 0, 0);
    }

    private void Start()
    {
        doTween = GetComponent<DoTweenAnimationController>();
        trans = GetComponent<RectTransform>();
        trans.localScale = new Vector3(0, 0, 0);
        iconTween = itemIcone.gameObject.GetComponent<DoTweenAnimationController>();

        doTween.BounceAnimation();
    }

    public void PickItem()
    {
        Debug.Log($"Я {itemName}");

        if (EventBus.Instance.PickItem(itemName))
        {
            Debug.Log($"Верно!");
            StarParticle.Instance.OnParticle(trans);
            itemIcone.transform.localScale = new Vector3(0,0,0); //Не совсем понял как должно, эта строчка чисто для того, чтобы анимации была как при вылете
            iconTween.BounceAnimation();
        }
        else
        {
            Debug.Log($"Ошибочка!");
            iconTween.EaseInBounce();
            //to do подергать букву
        }

    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
