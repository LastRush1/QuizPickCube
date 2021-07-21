using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private void OnEnable()
    {
        //EventBus.Subscribe(EventTypes.EventTyper.PickCube,PickCube);
    }

    private void OnDisable()
    {
        
    }
    public void StartGame()
    {
        // to do начать игру и сгенерировать
    }

    public void PickItem()
    {
        //вызываем при тапе по купибку и делаем все с этим связанное
    }

    public void ResetGame()
    {
        //TO do Перезапустить игру
    }
}
