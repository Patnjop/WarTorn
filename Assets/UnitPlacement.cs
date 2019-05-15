using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPlacement : MonoBehaviour
{
    public GameObject[] units;
    public Material BlueInfantryMat;
    public GameObject UIManager;
    ToolbarExpansion toolbarExpansion;
    public GameObject setObject;
    bool unitPlaced;
    int classIndex;
    Transform currentUnit;
    Transform tempUnit;
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
                unitPlaced = true;
                SetUnit(units[toolbarExpansion.unitSelected]);
            }
        }
    }
    public void SetUnit(GameObject g)
    {
        setObject = (GameObject)Instantiate(g);
        currentUnit = setObject.transform;
        if (tempUnit != null)
        {
            Destroy(toolbarExpansion.temp);
        }
        unitPlaced = false;
    }

    public void SwitchUnit(GameObject s)
    {
        setObject = (GameObject)Instantiate(s);
        currentUnit = setObject.transform;
        unitPlaced = false;
    }
}



