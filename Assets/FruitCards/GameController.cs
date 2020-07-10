using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class GameController : MonoBehaviour
{
    [Header("比對卡牌得清單")]
    public List<Card> cardComparison;
    // Start is called before the first frame update

    [Header("卡牌種類清單")]
    public List<CardPatten> cardsToBePutIn;
    public GameObject cardPannel;
        
    void Start()
    {
        //AddNewCard(CardPatten.blue);
        //SetUpCardsToBEPutIn(); 
        GenerateRamdomCards();
    }

    void GenerateRamdomCards()
    {
        
        SetUpCardsToBEPutIn(); // 準備卡牌
        //Debug.Log("cardsToBePutIn.Count" + cardsToBePutIn.Count);
        int maxRandomNumber = cardsToBePutIn.Count;
        Debug.Log("maxRandomNumber11:" + maxRandomNumber);
        maxRandomNumber--;

        for (int i = 0; i <= maxRandomNumber; maxRandomNumber--)
        {
            Debug.Log("maxRandomNumber" + maxRandomNumber);
            int ramdomNumber = UnityEngine.Random.Range(0, maxRandomNumber);

            // 抽牌
            Debug.Log("ramdomNumber" + ramdomNumber);
            AddNewCard(cardsToBePutIn[ramdomNumber]);
            cardsToBePutIn.RemoveAt(ramdomNumber);
            Debug.Log("cardsToBePutIn.Count" + cardsToBePutIn.Count);
            Debug.Log("cardsToBePutIn[ramdomNumber]" + cardsToBePutIn[ramdomNumber]);
            
        }

    }

    void SetUpCardsToBEPutIn() // Enum轉List
    {
        Array array = Enum.GetValues(typeof(CardPatten));
        for (int i = 0; i < 2; i++)
        {
            foreach (var item in array)
            {
                cardsToBePutIn.Add((CardPatten)item);
            }
        }
        cardsToBePutIn.RemoveAt(9); // 把None刪掉
        cardsToBePutIn.RemoveAt(0); // 把None刪掉

    }

    void AddNewCard(CardPatten cardPatten)
    {
        GameObject card = Instantiate(Resources.Load<GameObject>("Prefabs/Card"));
        card.transform.SetParent(cardPannel.transform);
        card.GetComponent<Card>().cardPatten = cardPatten;
        card.name = "Card_" + cardPatten.ToString();

        GameObject image = Instantiate(Resources.Load<GameObject>("Prefabs/Image"));

        image.GetComponent<Image>().color = GetColor(cardPatten);

        card.transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        image.transform.SetParent(card.transform);
        image.transform.SetSiblingIndex(0);  // 將自己設為第0個子物件
        image.transform.localPosition = new Vector3(0, 0, 0);
    }


    Color GetColor(CardPatten cardPatten)
    {
        switch (cardPatten)
        {
            case CardPatten.red:
                return Color.red;
            case CardPatten.orange:
                return Color.gray;
            case CardPatten.yellow:
                return Color.yellow;
            case CardPatten.blue:
                return Color.blue;
            case CardPatten.green:
                return Color.green;
            case CardPatten.purple:
                return new Color(100, 0, 255);
            case CardPatten.black:
                return Color.black;
            case CardPatten.white:
                return Color.white;

            default:
                return Color.red;

        }
    }
    //none, red, orange, yellow, green, blue, purple, black, white
    public bool ReadyToCompareCards
    {
        get {
            if(cardComparison.Count == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public void AddCardInComparison(Card card)
    {
            cardComparison.Add(card);
        
    }

    public void CampareCardsInList()
    {
        if (!ReadyToCompareCards) { return; }
       
        Debug.Log("可以開始比對了");

        if(cardComparison[0].cardPatten == cardComparison[1].cardPatten)
        {
            Debug.Log("兩張卡相同");

            foreach(var card in cardComparison)
            {
                card.cardState = CardState.HasOpen;
            }
            cardComparison.Clear();
        }
        else
        {
            Debug.Log("兩張卡不相同");
            StartCoroutine(MissMatchCards());
            

        }
        
    }

    public void ClearCardComparison()
    {
        cardComparison.Clear();
    }

    void TurnBackCards()
    {
        foreach(var card in cardComparison)
        {
            card.backImage.color = new Color(255, 255, 255, 255);
            card.cardState = CardState.UnOpen;
        }
    }

    IEnumerator MissMatchCards()
    {
        yield return new WaitForSeconds(1.5f);
        TurnBackCards();
        ClearCardComparison();
    }


}
