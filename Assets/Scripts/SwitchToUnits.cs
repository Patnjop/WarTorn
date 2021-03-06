﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToUnits : MonoBehaviour
{
    List<GameObject> allunits = new List<GameObject>();
    public float xScale, zScale;
    public float gapSizeY;
    public float unitScale;
    public float gapSizeX, gapSizeZ;
    public int unitperRow, unitperCol;
    public GameObject unit;
    public bool canSwitch;
    public Vector3 target;
    Vector3 topLeft;
    UnitCount unitCount;

    // Start is called before the first frame update
    void Start()
    {
        unitCount = GameObject.Find("MapManager").GetComponent<UnitCount>();
        canSwitch = false;
        xScale = transform.localScale.x;
        zScale = transform.localScale.z;
        unitScale = xScale / (unitperRow + 1);
        gapSizeX = unitScale / 4;
        gapSizeZ = (zScale - (unitperCol * unitScale)) / (unitperCol - 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (canSwitch == true)
        {
            Switch();
            canSwitch = false;
        }
        transform.position = Vector3.MoveTowards(this.transform.position, target, 0.5f * Time.deltaTime);
    }

    public void Switch()
    {
        //Instantiating each individual unit
        topLeft = transform.position + new Vector3(-(xScale / 2) + (unitScale / 2), gapSizeY, (zScale / 2) - (unitScale / 2));
        for(int r = 0; r< unitperRow; r++)
        {
            for (int c = 0; c < unitperCol; c++)
            {
                GameObject dude = Instantiate(unit, topLeft, Quaternion.identity);
                if (r == 0 && c == 0)
                {
                    dude.GetComponent<UnitBehaviour>().leader = true;
                }
                allunits.Add(dude);   
                topLeft = topLeft - new Vector3(0, 0, unitScale + gapSizeZ);
            }
            topLeft = topLeft + new Vector3(unitScale + gapSizeX, 0, unitperCol * (unitScale + gapSizeZ));
        }
        foreach (GameObject d in allunits)
        {
            d.transform.SetParent(this.transform);
        }
        unitCount.totalUnitCount.Add(this.gameObject);
        this.GetComponent<MeshRenderer>().enabled = false;
    }
}
