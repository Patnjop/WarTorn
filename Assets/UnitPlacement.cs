using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPlacement : MonoBehaviour
{
    public GameObject[] units;
    public Material BlueInfantryMat;
    public GameObject UIManager, temp;
    ToolbarExpansion toolbarExpansion;
    PlaceableUnit placeableUnit;
    public GameObject setObject;
    bool unitPlaced;
    int classIndex;
    int count;
    Transform currentUnit;

    public int goldCount;
    int cost = 20;
    public Text goldText; 
    // Start is called before the first frame update
    void Start()
    {
        SetUnit(units[0]);
        toolbarExpansion = UIManager.GetComponent<ToolbarExpansion>();
    }

    // Update is called once per frame
    void Update()
    {
        //currency count
        goldText.text = goldCount + " coins left";
        classIndex = toolbarExpansion.unitSelected;

        //Mouse tracking for Units
        if (currentUnit != null && !unitPlaced)
        {
            Vector3 m = Input.mousePosition;
            m = new Vector3(m.x, m.y, 9);
            Vector3 p = Camera.main.ScreenToWorldPoint(m);
            currentUnit.position = new Vector3(p.x, 0.1f, p.z);
            //Set Unit down
            if (Input.GetMouseButtonDown(1) && goldCount > cost)
            {
                if (IsLegalPosition())
                {
                    goldCount -= cost;
                    unitPlaced = true;
                    SetUnit(units[toolbarExpansion.unitSelected]);
                }
            }
        }
        //Selecting new Unit
        if (toolbarExpansion.expand == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                cost = 20;
                toolbarExpansion.unitSelected = 0;
                toolbarExpansion.SwitchToolbar();
                SwitchUnit(units[toolbarExpansion.unitSelected]);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                cost = 50;
                toolbarExpansion.unitSelected = 1;
                SwitchUnit(units[toolbarExpansion.unitSelected]);
                toolbarExpansion.SwitchToolbar();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                cost = 30;
                toolbarExpansion.unitSelected = 2;
                SwitchUnit(units[toolbarExpansion.unitSelected]);
                toolbarExpansion.SwitchToolbar();
            }
        }
    }
    //Checking for unique place for unit
    bool IsLegalPosition()
    {
        if (placeableUnit.colliders.Count > 0)
        {
            return false;
        }
        return true;
    }
    //Place unit
    public void SetUnit(GameObject g)
    {
        setObject = (GameObject)Instantiate(g);
        currentUnit = setObject.transform;
        placeableUnit = currentUnit.GetComponent<PlaceableUnit>();
        unitPlaced = false;
    }
    //Switch unit place
    public void SwitchUnit(GameObject s)
    {
        temp = setObject;
        setObject = (GameObject)Instantiate(s);
        Destroy(temp);
        currentUnit = setObject.transform;
        placeableUnit = currentUnit.GetComponent<PlaceableUnit>();
    }
}



