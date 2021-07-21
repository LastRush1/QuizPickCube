using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public string menuName;

    [SerializeField]
    bool open = false;

    public bool IsOpen
    {
        get { return open; }
    }

    public void Open()
    {

        gameObject.SetActive(true);
        open = true;
    }

    public void Close()
    {
        open = false;
        gameObject.SetActive(false);
    }
}
