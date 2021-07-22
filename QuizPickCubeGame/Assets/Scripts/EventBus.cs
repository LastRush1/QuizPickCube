using UnityEngine;
using System.Collections;

public class EventBus : MonoBehaviour
{
    #region Singleton

    public static EventBus Instance;

    #endregion

    private void Awake()
    {
        Instance = this;
    }

    string rightItem = "";

    public bool PickItem(string itemName)
    {
        if (itemName == rightItem)
        {
            rightItem = "";
            StartCoroutine(wait());
            return true;
        }
        return false;
    }

    public void GetRightItem(string rightItem)
    {
        this.rightItem = rightItem;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        BoardController.Instance.NewRound();
    }
}
