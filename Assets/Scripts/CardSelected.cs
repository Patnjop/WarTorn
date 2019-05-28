using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelected : MonoBehaviour
{
    public int index;
    public int cost;
    public GameObject unit;
    protected PlaceableUnit placeableUnit;
    protected bool clicked, unitPlaced, newRound;
    CardPick cardPick;
    Mana mana;
    HandofCards handofCards;
    public NextRound nextRound;
    protected GameObject setObject;
    protected Transform currentUnit;
    MoveUnits moveUnits;
    // Start is called before the first frame update
    void Start()
    {
        moveUnits = GameObject.Find("UnitManager").GetComponent<MoveUnits>();
        nextRound = GameObject.Find("Next Round").GetComponent<NextRound>();
        handofCards = GameObject.Find("CardManager").GetComponent<HandofCards>();
        mana = GameObject.Find("MapManager").GetComponent<Mana>();
        cardPick = GameObject.Find("CardManager").GetComponent<CardPick>();
        this.GetComponent<Button>().onClick.AddListener(PickCard);
    }
    private void Update()
    {
        if (cardPick.choiceCount <= 0 && clicked == false)
        {
            this.GetComponent<Button>().onClick.RemoveListener(PickCard);
            this.GetComponent<Button>().onClick.AddListener(SwitchCard);
            clicked = true;
        }
        if (nextRound.newRound == true)
        {
            this.GetComponent<Button>().onClick.RemoveListener(SwitchCard);
            this.GetComponent<Button>().onClick.AddListener(PickCard);
            nextRound.newRound = false;
        }
        if (currentUnit != null && !unitPlaced)
        {
            Vector3 m = Input.mousePosition;
            m = new Vector3(m.x, m.y, 9);
            Vector3 p = Camera.main.ScreenToWorldPoint(m);
            currentUnit.position = new Vector3(p.x, 0.1f, p.z);
            //Set Unit down
            if (Input.GetMouseButtonDown(1))
            {
                if (IsLegalPosition())
                {
                    unitPlaced = true;
                    moveUnits.unitActive = false;
                    setObject.GetComponent<SwitchToUnits>().canSwitch = true;
                    if (index == 3)
                    {
                        mana.waitTime -= 0.2f;
                    }
                }
            }
        }
    }
    void PickCard()
    {
        cardPick.CardPicked(index);
    }
    void SwitchCard()
    {
        if (cost <= mana.manaCount)
        {
            this.GetComponent<Image>().enabled = false;
            this.GetComponent<Button>().enabled = false;
            handofCards.hand.Remove(gameObject);
            foreach (GameObject g in handofCards.hand)
            {
                if (g.GetComponent<RectTransform>().position.x > this.GetComponent<RectTransform>().position.x)
                {
                    g.GetComponent<RectTransform>().position -= new Vector3(100, 0, 0);
                }
            }
            handofCards.currentHandSize--;
            unitPlaced = !unitPlaced;
            PlayCard();
            mana.SubtractMana(cost);
        }
    }
    void PlayCard()
    {
        setObject = (GameObject)Instantiate(unit);
        currentUnit = setObject.transform;
        placeableUnit = currentUnit.GetComponent<PlaceableUnit>();
        unitPlaced = false;
        moveUnits.unitActive = true;
    }
    bool IsLegalPosition()
    {
        if (placeableUnit.colliders.Count > 0)
        {
            return false;
        }
        return true;
    }
}
