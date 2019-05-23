using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCard : MonoBehaviour
{
    HandofCards handofCards;
    // Start is called before the first frame update
    void Start()
    {
        handofCards = GameObject.Find("CardManager").GetComponent<HandofCards>();
        this.GetComponent<Button>().onClick.AddListener(CardDraw);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CardDraw()
    {
        if (handofCards.currentHandSize < handofCards.handSize)
        {
            handofCards.DrawCard();
        }
    }
}
