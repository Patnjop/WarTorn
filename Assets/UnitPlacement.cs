using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        SetUnit(units[0]);
        toolbarExpansion = UIManager.GetComponent<ToolbarExpansion>();
    }

    // Update is called once per frame
    void Update()
    {
        classIndex = toolbarExpansion.unitSelected;
        if (currentUnit != null && !unitPlaced)
        {
            Vector3 m = Input.mousePosition;
            m = new Vector3(m.x, m.y, 9);
            Vector3 p = Camera.main.ScreenToWorldPoint(m);
            currentUnit.position = new Vector3(p.x, 0.1f, p.z);
            if (Input.GetMouseButtonDown(1))
            {
                if (IsLegalPosition())
                {
                    unitPlaced = true;
                    SetUnit(units[toolbarExpansion.unitSelected]);
                }
            }
        }
        if (toolbarExpansion.expand == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                toolbarExpansion.unitSelected = 0;
                toolbarExpansion.SwitchToolbar();
                SwitchUnit(units[toolbarExpansion.unitSelected]);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                toolbarExpansion.unitSelected = 1;
                SwitchUnit(units[toolbarExpansion.unitSelected]);
                toolbarExpansion.SwitchToolbar();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                toolbarExpansion.unitSelected = 2;
                SwitchUnit(units[toolbarExpansion.unitSelected]);
                toolbarExpansion.SwitchToolbar();
            }
        }
    }
    bool IsLegalPosition()
    {
        if (placeableUnit.colliders.Count > 0)
        {
            return false;
        }
        return true;
    }
    public void SetUnit(GameObject g)
    {
        setObject = (GameObject)Instantiate(g);
        currentUnit = setObject.transform;
        placeableUnit = currentUnit.GetComponent<PlaceableUnit>();
        unitPlaced = false;
    }

    public void SwitchUnit(GameObject s)
    {
        temp = setObject;
        setObject = (GameObject)Instantiate(s);
        Destroy(temp);
        currentUnit = setObject.transform;
        placeableUnit = currentUnit.GetComponent<PlaceableUnit>();
    }
}



