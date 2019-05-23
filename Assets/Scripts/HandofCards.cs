using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandofCards : MonoBehaviour
{
    public List<GameObject> newDeck = new List<GameObject>();
    public List<GameObject> savedDeck = new List<GameObject>();
    public List<GameObject> hand = new List<GameObject>();
    CardPick cardPick;
    Mana mana;
    public int handSize;
    public int currentHandSize;
    public bool added, handmade, manaAdded;
    // Start is called before the first frame update
    void Start()
    {
        cardPick = GameObject.Find("CardManager").GetComponent<CardPick>();
        mana = GameObject.Find("MapManager").GetComponent<Mana>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cardPick.choiceCount <= 0 && added == false)
        {
            foreach (int i in cardPick.deck)
            {
                newDeck.Add(cardPick.cards[i]);
                savedDeck.Add(cardPick.cards[i]);
            }
            for (int i = 0; i < 3; i++)
            {
                newDeck.Add(cardPick.cards[3]);
                savedDeck.Add(cardPick.cards[3]);
            }
            for (int i = 0; i < 5; i++)
            {
                newDeck.Add(cardPick.cards[0]);
                savedDeck.Add(cardPick.cards[0]);
            }
            added = true;
        }
        if (added == true && handmade == false)
        {
            StartCoroutine("InstantiateHand");
            if (manaAdded == false)
            {
                mana.StartCoroutine("InitialMana");
                manaAdded = true;
            }
        }
    }

    IEnumerator InstantiateHand()
    {
        handmade = true;
        for (int i = 0; i < handSize; i++)
        {
            int n = Random.Range(0, newDeck.Count);
            newDeck[n].GetComponent<RectTransform>().sizeDelta = new Vector2(100, 150);
            GameObject card = Instantiate(newDeck[n], new Vector3(75 + (i * 100), 80, 0), Quaternion.identity);
            card.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
            currentHandSize++;
            hand.Add(card);
            newDeck.Remove(newDeck[n]);
            yield return new WaitForSeconds(0.3f);
        }
    }

    public void DrawCard()
    {
        int rnd = Random.Range(0, newDeck.Count);
        newDeck[rnd].GetComponent<RectTransform>().sizeDelta = new Vector2(100, 150);
        GameObject card = Instantiate(newDeck[rnd], new Vector3(75 + (currentHandSize * 100), 80, 0), Quaternion.identity);
        card.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        hand.Add(card);
        currentHandSize++;
        newDeck.Remove(newDeck[rnd]);
    }

}
