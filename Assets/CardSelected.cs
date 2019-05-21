using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelected : MonoBehaviour
{
    public int index;
    public GameObject unit;
    protected PlaceableUnit placeableUnit;
    protected bool clicked, unitPlaced;
    CardPick cardPick;
    protected GameObject setObject;
    protected Transform currentUnit;
    // Start is called before the first frame update
    void Start()
    {
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
                unitPlaced = true;
            }
        }
    }
    void PickCard()
    {
        cardPick.CardPicked(index);
    }
    void SwitchCard()
    {
        this.GetComponent<Image>().enabled = false;
        this.GetComponent<Button>().enabled = false;
        unitPlaced = !unitPlaced;
        PlayCard();
    }
    void PlayCard()
    {
        setObject = (GameObject)Instantiate(unit);
        currentUnit = setObject.transform;
        placeableUnit = currentUnit.GetComponent<PlaceableUnit>();
        unit.GetComponent<SwitchToUnits>().canSwitch = true;
        unitPlaced = false;
    }
}
