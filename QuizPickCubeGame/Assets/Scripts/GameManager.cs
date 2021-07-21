using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<Color> colorsFromCubes = new List<Color>();

    [SerializeField]
    GameObject gridPanel = default;

    [SerializeField]
    TextMeshProUGUI infoText = default;

    [SerializeField]
    GroupManagerSO groupManager = default;

    GroupItemsSO groupItems;

    List<ItemSO> groupItemsList = new List<ItemSO>();

    [SerializeField]
    int whatGropuNumber = 0;

    [SerializeField]
    Difficulty difficulty = Difficulty.eazy;

    [SerializeField]
    Item itemPrefab = default;

    [SerializeField]
    List<Item> items = new List<Item>();

    public enum Difficulty
    {
        eazy,medium,hard
    }

    private void Start()
    {
        PickgroupNumber();
    }


    /// <summary>
    /// Вызываем, чтобы начать игру
    /// </summary>
    public void StartGame()
    {
        //to do сгеерировать раунд
        //to do переключить, чтобы следющий был сложнее уровнем
        NewRound();
        ChangeDifficulty();
    }

    /// <summary>
    /// Меняем сложность на следующую
    /// </summary>
    void ChangeDifficulty()
    {
        if (difficulty == Difficulty.eazy)
        {
            difficulty = Difficulty.medium;
        } else if (difficulty == Difficulty.medium)
        {
            difficulty = Difficulty.hard;
        } else if (difficulty == Difficulty.hard)
        {
            difficulty = Difficulty.eazy;
            StopGame();
        }
    }

    void StopGame()
    {
        //to do показать кнопку ресет, чтобы начать заново

    }

    /// <summary>
    /// Новый раунд, выбрали верную букву
    /// </summary>
    void NewRound()
    {
        //to do Выбрать задание и добавить неправильные ответы, перемешать
        
        // to do создать все что мы выбрали

        CreateBoard(GenerateBoard());
    }

    /// <summary>
    /// Выбираем набро для поля
    /// </summary>
    /// <returns></returns>
    List<ItemSO> GenerateBoard()
    {
        List<ItemSO> returnList = new List<ItemSO>();

        List<int> numberList = new List<int>();

        List<ItemSO> pullItems = new List<ItemSO>();

        int numberQuest = RandomizerItemNumbers();

        for (int i = 0; i < groupItemsList.Count; i++)
        {
            pullItems.Add(groupItemsList[i]);
            numberList.Add(i);
        }

        //Пока так потом тоже рандом нужен
        Debug.Log($"Верный ответ {groupItemsList[numberQuest].NameItem}");

        returnList.Add(groupItemsList[numberQuest]);
        infoText.text = returnList[0].NameItem;
        numberList.Remove(numberQuest);

        int countBoard = 0;

        if (difficulty == Difficulty.eazy)
        {
            countBoard = 2;
        }
        else if (difficulty == Difficulty.medium)
        {
            countBoard = 5;
        }
        else
        {
            countBoard = 8;
        }

        for (int i = 0; i < countBoard; i++)
        {
            int numberFromList = GetRandomValue(0, numberList.Count);
            int number = numberList[numberFromList];
            returnList.Add(groupItemsList[number]);
            numberList.RemoveAt(numberFromList);

        }

        List<ItemSO> randomReturnList = new List<ItemSO>();

        numberList.Clear();


        for (int i = 0; i < returnList.Count; i++)
        {
            numberList.Add(i);
        }

        for (int i = 0; i < returnList.Count; i++)
        {
            int numberFromList = GetRandomValue(0, numberList.Count);
            int number = numberList[numberFromList];
            randomReturnList.Add(groupItemsList[number]);
            numberList.RemoveAt(numberFromList);

        }

        returnList.Clear();
        returnList = randomReturnList;

        return returnList;
    }

    int GetRandomValue(int min, int max)
    {
        return Random.Range(min,max);
    }

    Item CreateItem()
    {
        Item newItem = Instantiate(itemPrefab, gridPanel.transform);
        return newItem;
    }

    void InizializationItem()
    {

    }

    void CreateBoard(List<ItemSO> pullFromBoard)
    {
        for (int i = 0; i < pullFromBoard.Count; i++)
        {
            Item newItem = CreateItem();
            ItemSO itemSettings = pullFromBoard[i];
            newItem.Inizialization(itemSettings.Icone, itemSettings.NameItem);
            items.Add(newItem);
        }
    }

    /// <summary>
    /// Выбрать список итемов под номером, можно сделать enum, но, 
    /// тогда при добавлении других списков придется залазить в код и дописывать enum,
    /// так что пока числом
    /// </summary>
    void PickgroupNumber()
    {
        groupItems = groupManager.GroupItemsSOs[whatGropuNumber];
        groupItemsList = groupItems.ItemsPull;
    }

    /// <summary>
    /// Возвращает еще не предлагаемый для угадывания итем
    /// </summary>
    /// <returns></returns>
    int RandomizerItemNumbers()
    {
        int randomeNumber = 0;
        List<ItemSO> clearItems = new List<ItemSO>();
        //получить пул итемов, которые еще не предлагались в качестве ответа и выбрать из них
        for (int i = 0; i < groupItemsList.Count; i++)
        {
            if (groupItemsList[i].NewItem)
            {
                clearItems.Add(groupItemsList[i]);
            }
        }

        randomeNumber = Random.Range(0, clearItems.Count);

        //Если все предлагаемые, кончались начать заново
        if (clearItems.Count == 0)
        {
            ResetItems();
        }
        groupItemsList[randomeNumber].NewItem = false;
        return randomeNumber;
    }
    public void RestartGame()
    {

    }

    /// <summary>
    /// Обновить список итемов,чтобы можно было снова их предлагать
    /// </summary>
    void ResetItems()
    {
        Debug.Log("Перезапускаем список");
        for (int i = 0; i < groupItemsList.Count; i++)
        {
            groupItemsList[i].NewItem = true;
        }

        //To do Перезагрузить уровень
    }
}
