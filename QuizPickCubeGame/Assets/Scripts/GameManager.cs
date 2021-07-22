using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<Color> colorsFromCubes = new List<Color>();

    /// <summary>
    /// Вызываем, чтобы начать игру
    /// </summary>
    public void StartGame()
    {
        //to do сгеерировать раунд
        //to do переключить, чтобы следющий был сложнее уровнем
        BoardController.Instance.StartGame();
    }

    /// <summary>
    /// Новый раунд, выбрали верную букву
    /// </summary>
    void NewRound()
    {
        BoardController.Instance.NewRound();
    }

    


}
