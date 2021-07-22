using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    #region Singleton
    public static BoardController Instance;
    #endregion

    [SerializeField]
    Difficulty difficulty = Difficulty.eazy;

    [SerializeField]
    GroupManagerSO groupManager = default;

    [SerializeField]
    GameObject gridPanel = default;

    GroupItemsSO groupItems;

    List<ItemSO> groupItemsList = new List<ItemSO>();

    [SerializeField]
    Item itemPrefab = default;

    [SerializeField]
    List<Item> items = new List<Item>();

    [SerializeField]
    int whatGropuNumber = 0;


    public enum Difficulty
    {
        eazy, medium, hard, none
    }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PickgroupNumber();
    }

    public void StartGame()
    {
        for (int i = 0; i < groupItemsList.Count; i++)
        {
            groupItemsList[i].NewItem = true;
        }
        NewRound();
    }

    public void NewRound()
    {
        if (ChangeDifficulty())
        {
            //ClearBoard();
            CreateBoard(GenerateBoard());
        }


    }

    public void RestartGame()
    {
        difficulty = Difficulty.none;
        ClearBoard();
        StartGame();
    }


    void ClearBoard()
    {
        Debug.Log($"items.Count {items.Count}");
        for (int i = 0; i < items.Count; i++)
        {
            items[i].Destroy();
        }
        items.Clear();
    }

    void StopGame()
    {
        MenuManager.Instance.OpenMenu("restart");
    }

    /// <summary>
    /// Меняем сложность на следующую
    /// </summary>
    bool ChangeDifficulty()
    {
        if (difficulty == Difficulty.none)
        {
            difficulty = Difficulty.eazy;
        }
        else if (difficulty == Difficulty.eazy)
        {
            difficulty = Difficulty.medium;
        }
        else if (difficulty == Difficulty.medium)
        {
            difficulty = Difficulty.hard;
        }
        else if (difficulty == Difficulty.hard)
        {
            StopGame();
            return false;
        }
        return true;
    }


    #region CreateBoard

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

        EventBus.Instance.GetRightItem(groupItemsList[numberQuest].NameItem);



        for (int i = 0; i < groupItemsList.Count; i++)
        {
            pullItems.Add(groupItemsList[i]);
            numberList.Add(i);
        }

        //Пока так потом тоже рандом нужен
        Debug.Log($"Верный ответ {groupItemsList[numberQuest].NameItem}");

        returnList.Add(groupItemsList[numberQuest]);
        UIController.Instance.InfoText(returnList[0].NameItem);
        numberList.RemoveAt(numberQuest);

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

        while (returnList.Count > 0)
        {
            int number = Random.Range(0, returnList.Count);
            randomReturnList.Add(returnList[number]);
            returnList.RemoveAt(number);
        }

        return randomReturnList;
    }

    Item CreateItem()
    {
        Item newItem = Instantiate(itemPrefab, gridPanel.transform);
        return newItem;
    }

    void CreateBoard(List<ItemSO> pullFromBoard)
    {
        if (items.Count > 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
                ItemSO itemSettings = pullFromBoard[i];
                items[i].Inizialization(itemSettings.Icone, itemSettings.NameItem);
            }

            for (int i = items.Count; i < pullFromBoard.Count; i++)
            {
                Item newItem = CreateItem();
                ItemSO itemSettings = pullFromBoard[i];
                newItem.Inizialization(itemSettings.Icone, itemSettings.NameItem);
                items.Add(newItem);
            }
        }
        else
        {
            for (int i = 0; i < pullFromBoard.Count; i++)
            {
                Item newItem = CreateItem();
                ItemSO itemSettings = pullFromBoard[i];
                newItem.Inizialization(itemSettings.Icone, itemSettings.NameItem);
                items.Add(newItem);
            }
        }


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
            Debug.Log("Перезапуск");
            ResetItems();
        }
        groupItemsList[randomeNumber].NewItem = false;
        return randomeNumber;
    }

    int GetRandomValue(int min, int max)
    {
        return Random.Range(min, max);
    }

    #endregion


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
