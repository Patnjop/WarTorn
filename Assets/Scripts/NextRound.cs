using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextRound : MonoBehaviour
{
    CardPick cardPick;
    HandofCards handofCards;
    Mana mana;
    UnitCount unitCount;
    public int roundAmount;
    int deckSize;
    public bool added;
    public bool switched;
    public bool newRound;
    bool deckUpdated;
    // Start is called before the first frame update
    void Start()
    {
        unitCount = GameObject.Find("MapManager").GetComponent<UnitCount>();
        mana = GameObject.Find("MapManager").GetComponent<Mana>();
        cardPick = GameObject.Find("CardManager").GetComponent<CardPick>();
        handofCards = GameObject.Find("CardManager").GetComponent<HandofCards>();
        this.GetComponent<Button>().onClick.AddListener(SetNextRound);
    }

    // Update is called once per frame
    void Update()
    {
        if (handofCards.savedDeck.Count >= deckSize + roundAmount && added == true)
        {
            if (deckUpdated == false)
            {
                handofCards.newDeck = new List<GameObject>();
                foreach (GameObject s in handofCards.savedDeck)
                {
                    handofCards.newDeck.Add(s);
                }
                deckUpdated = true;
            }
            handofCards.handmade = false;
            added = false;
            mana.reset = false;
        }
    }

    void SetNextRound()
    {
        mana.ManaReset();
        foreach (GameObject u in unitCount.totalUnitCount)
        {
            Destroy(u);
        }
        unitCount.totalUnitCount.Clear();
        deckSize = handofCards.savedDeck.Count;
        deckUpdated = false;
        cardPick.toAdd = true;
        newRound = true;
        switched = true;
        handofCards.currentHandSize = 0;
        cardPick.choiceCount = roundAmount;
        foreach (GameObject g in handofCards.hand)
        {
            Destroy(g);
        }
        handofCards.hand.Clear();
        added = true;
    }
}
