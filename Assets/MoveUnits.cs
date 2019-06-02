using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnits : MonoBehaviour
{
    public bool unitActive;
    UnitCount unitCount;
    Vector3 topLeft;
    SwitchToUnits switchToUnits;
    // Start is called before the first frame update
    void Start()
    {
        unitCount = GameObject.Find("MapManager").GetComponent<UnitCount>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 m = Input.mousePosition;
        m = new Vector3(m.x, m.y, 9);
        Vector3 p = Camera.main.ScreenToWorldPoint(m);

        if (Input.GetMouseButtonDown(1) && unitActive == false && unitCount.selectedUnits.Count > 0)
        {
            int i = 0;
            switchToUnits = unitCount.selectedUnits[0].GetComponentInParent<SwitchToUnits>();
            for (int g = 0; g < switchToUnits.unitperRow; g++)
            {
                if (unitCount.selectedUnits[g].GetComponent<UnitBehaviour>().leader == true)
                {
                    switchToUnits = unitCount.selectedUnits[g].GetComponentInParent<SwitchToUnits>();
                    topLeft = p + new Vector3(-(switchToUnits.xScale / 2) + (switchToUnits.unitScale / 2),
                    0.1f, (switchToUnits.zScale / 2) - (switchToUnits.unitScale / 2));
                }
                for (int c = 0; c < switchToUnits.unitperCol; c++)
                {
                    unitCount.selectedUnits[i].GetComponent<UnitBehaviour>().target = topLeft;
                    topLeft = topLeft - new Vector3(0, 0, switchToUnits.unitScale + switchToUnits.gapSizeZ);
                    i++;
                }
                Debug.Log("ding");
                topLeft = topLeft + new Vector3(switchToUnits.unitScale + switchToUnits.gapSizeX, 0, switchToUnits.unitperCol * (switchToUnits.unitScale + switchToUnits.gapSizeZ));
            }
            
        }
    }
}
