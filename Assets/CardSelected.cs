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
    protected bool clicked, unitPlaced;
    CardPick cardPick;
    Mana mana;
    protected GameObject setObject;
    protected Transform currentUnit;
    // Start is called before the first frame update
    void Start()
    {
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
        unit.GetComponent<SwitchToUnits>().canSwitch = true;
        unitPlaced = false;
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
