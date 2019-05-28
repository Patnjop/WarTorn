using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnits : MonoBehaviour
{
    public bool unitActive;
    UnitCount unitCount;
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
        if (Input.GetMouseButton(1) && unitActive == false)
        {
            foreach (GameObject g in unitCount.selectedUnits)
            {
                g.GetComponent<UnitBehaviour>().target = new Vector3(p.x, 0.1f, p.z);
            }
        }
    }
}
