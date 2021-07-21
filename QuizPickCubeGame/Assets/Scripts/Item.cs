using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    string itemName = default;

    [SerializeField]
    Image itemIcone = default;

    /// <summary>
    /// Заполняем префаб
    /// </summary>
    /// <param name="sprite"></param>
    /// <param name="name"></param>
    public void Inizialization(Sprite sprite, string name)
    {
        itemName = name;
        itemIcone.overrideSprite = sprite;
    }
}
