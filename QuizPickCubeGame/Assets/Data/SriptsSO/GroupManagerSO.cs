using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GroupManagerSO : ScriptableObject
{
    [SerializeField]
    List<GroupItemsSO> groupItemsSOs = new List<GroupItemsSO>();

    public List<GroupItemsSO> GroupItemsSOs
    { 
        get { return groupItemsSOs; }
    }
    
}
