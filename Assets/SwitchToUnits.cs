using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToUnits : MonoBehaviour
{
    float xScale, zScale;
    public float gapSizeY;
    float unitScale;
    float gapSizeX, gapSizeZ;
    public int unitperRow, unitperCol;
    public GameObject unit;
    public bool canSwitch = false;
    Vector3 topLeft;
    // Start is called before the first frame update
    void Start()
    {
        xScale = transform.localScale.x;
        zScale = transform.localScale.z;
        unitScale = xScale / (unitperRow + 1);
        gapSizeX = unitScale / 4;
        gapSizeZ = (zScale - (unitperCol * unitScale)) / (unitperCol - 1);
    }

    // Update is called once per frame
    void Update()
    {
        //checking for input and eligibility
        if (Input.GetKeyDown(KeyCode.F) && canSwitch)
        {
            Switch();
        }
    }

    void Switch()
    {
        //Instantiating each individual unit
        topLeft = transform.position + new Vector3(-(xScale / 2) + (unitScale / 2), gapSizeY, (zScale / 2) - (unitScale / 2));
        gameObject.SetActive(false);
        for(int r = 0; r< unitperRow; r++)
        {
            for (int c = 0; c < unitperCol; c++)
            {
                Instantiate(unit, topLeft, Quaternion.identity);
                topLeft = topLeft - new Vector3(0, 0, unitScale + gapSizeZ);
            }
            topLeft = topLeft + new Vector3(unitScale + gapSizeX, 0, unitperCol * (unitScale + gapSizeZ));
        }
    }
}
