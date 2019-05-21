using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelected : MonoBehaviour
{
    public int index;
    CardPick cardPick;
    // Start is called before the first frame update
    void Start()
    {
        cardPick = GameObject.Find("CardManager").GetComponent<CardPick>();
        this.GetComponent<Button>().onClick.AddListener(PickCard);
    }
    void PickCard()
    {
        cardPick.CardPicked(index);
    }
}
