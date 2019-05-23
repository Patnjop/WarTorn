using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextRound : MonoBehaviour
{
    CardPick cardPick;
    HandofCards handofCards;
    Mana mana;
    public int roundAmount;
    int deckSize;
    bool added;
    public bool newRound;
    // Start is called before the first frame update
    void Start()
    {
        mana = GameObject.Find("MapManager").GetComponent<Mana>();
        cardPick = GameObject.Find("CardManager").GetComponent<CardPick>();
        handofCards = GameObject.Find("CardManager").GetComponent<HandofCards>();
        this.GetComponent<Button>().onClick.AddListener(SetNextRound);
    }

    // Update is called once per frame
    void Update()
    {
        if (handofCards.newDeck.Count >= deckSize + roundAmount && added == true)
        {
            handofCards.handmade = false;
            added = false;
            mana.reset = false;
        }
    }

    void SetNextRound()
    {
        mana.ManaReset();
        deckSize = handofCards.newDeck.Count;
        cardPick.toAdd = true;
        newRound = true;
        cardPick.choiceCount = roundAmount;
        foreach (GameObject g in handofCards.hand)
        {
            Destroy(g);
        }
        handofCards.hand.Clear();
        added = true;
    }
}
