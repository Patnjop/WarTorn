using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandofCards : MonoBehaviour
{
    public List<GameObject> newDeck = new List<GameObject>();
    CardPick cardPick;
    int handSize;
    bool added, handmade;
    // Start is called before the first frame update
    void Start()
    {
        cardPick = GameObject.Find("CardManager").GetComponent<CardPick>();
        handSize = cardPick.choiceCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (cardPick.choiceCount <= 0 && added == false)
        {
            foreach (int i in cardPick.deck)
            {
                if (i == 0)
                {
                    newDeck.Add(cardPick.cards[i]);
                }
                else if (i == 1)
                {
                    newDeck.Add(cardPick.cards[i]);
                }
                else if (i == 2)
                {
                    newDeck.Add(cardPick.cards[i]);
                }
            }
            added = true;
        }
        if (added == true && handmade == false)
        {
            StartCoroutine("InstantiateHand");
        }
    }

    IEnumerator InstantiateHand()
    {
        for (int i = 0; i < newDeck.Count; i++)
        {
            newDeck[i].GetComponent<RectTransform>().sizeDelta = new Vector2(100, 150);
            GameObject card = Instantiate(newDeck[i], new Vector3(75 + (i * 100), 80, 0), Quaternion.identity);
            card.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
            yield return new WaitForSeconds(0.3f);
        }
        handmade = true;
    }
}
