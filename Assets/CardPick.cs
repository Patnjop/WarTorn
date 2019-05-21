using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPick : MonoBehaviour
{
    public GameObject[] cards;
    public int choiceCount;
    public int cardAmount;
    public int xWidth;
    bool canChoose = true;
    List<GameObject> activeCards = new List<GameObject>();
    public List<int> deck = new List<int>();

    // Update is called once per frame
    void Update()
    {
        if (choiceCount > 0 && canChoose == true)
        {
            InitialCardChoice();
            canChoose = false;
        }
    }

    void InitialCardChoice()
    {
        for (int i = 0; i < cardAmount; i++)
        {
            int rnd = Random.Range(0, cards.Length);
            GameObject card = Instantiate(cards[rnd], new Vector3(xWidth - (i * xWidth), 0, 0), Quaternion.identity);
            card.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 650);
            card.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            activeCards.Add(card);
        }
    }

    public void CardPicked(int index)
    {
        Debug.Log("CardPicked");
        deck.Add(index);
        foreach (GameObject g in activeCards)
        {
            Destroy(g);
        }
        canChoose = true;
        choiceCount--;
    }
}
