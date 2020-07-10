using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class Card : MonoBehaviour
{
    public CardState cardState;
    public CardPatten cardPatten;
    public GameController gameController;
    public Image backImage;
    // Start is called before the first frame update
    void Start()
    {
        cardState = CardState.UnOpen;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(ClickCard);
    }
 
    private void ClickCard()
    {
        if (cardState.Equals(CardState.HasOpen)) { return; }
        
        if (gameController.ReadyToCompareCards) { return; }

        OpenCard();
        gameController.AddCardInComparison(this);
        gameController.CampareCardsInList();
    }

    void OpenCard()
    {
        //transform.eulerAngles = new Vector3(0, 180, 0);
        backImage.color = new Color(255, 255, 255, 0);
        cardState = CardState.HasOpen;
    }
}


public enum CardState
{
    UnOpen, HasOpen, HasPair
}



public enum CardPatten
{
    none, red, orange, yellow, green, blue, purple, black, white
}

