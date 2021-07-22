using UnityEngine;

[CreateAssetMenu(fileName = "Item",menuName = "Items/Item")]
public class ItemSO : ScriptableObject
{
    [SerializeField]
    string nameItem = default;

    public string NameItem
    {
        get { return nameItem; }
    }

    [SerializeField]
    Sprite icone = default;

    public Sprite Icone
    {
        get { return icone; }
    }

    [SerializeField]
    bool newItem = true;

    public bool NewItem
    {
        get { return newItem; }
        set { newItem = value; }
    }
}
