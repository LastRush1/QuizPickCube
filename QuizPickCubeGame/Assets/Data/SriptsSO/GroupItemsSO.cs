using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GroupItems", menuName = "Items/GroupItems")]
public class GroupItemsSO : ScriptableObject
{
    [SerializeField]
    List<ItemSO> itemsPull = new List<ItemSO>();
    public List<ItemSO> ItemsPull
    
    { 
        get { return itemsPull; }
    }

}
