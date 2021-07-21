using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    List<Menu> menus = new List<Menu>();

    #region Singlton

    public static MenuManager Instance;



    #endregion

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// ��������� ������ ������ �� �����
    /// </summary>
    /// <param name="name"></param>
    public void OpenMenu(string name)
    {
        for (int i = 0; i < menus.Count; i++)
        {
            if (menus[i].menuName == name)
            {
                OpenMenu(menus[i]);
            }
            else if (menus[i].IsOpen)
            {
                CloseMenu(menus[i]);
            }
        }
    }

    /// <summary>
    /// ��������� ������ ������ �� ������ �� ���
    /// </summary>
    /// <param name="menu"></param>
    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < menus.Count; i++)
        {
            if (menus[i].IsOpen)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.Open();
    }

    /// <summary>
    /// ��������� ������ ������ �� ������ �� ���
    /// </summary>
    /// <param name="menu"></param>
    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }
}
