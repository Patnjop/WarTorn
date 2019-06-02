﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyTypes;
    public int rnd;
    int width = 1, unitHeight;
    public float waitTime;
    bool summoning = false;

    public List<GameObject> unitList = new List<GameObject>(); 
    public int InfantryCount, ArcheryCount, CavalryCount, FarmerCount;

    private void Update()
    {
        if (summoning == false)
        {
            unitList.Clear();
            SelectUnit();
            Invoke("PlayUnit", waitTime);
            summoning = true;
        }
    }

    void PlayUnit()
    { 
        Instantiate(unitList[rnd], new Vector3(-8.5f + (width * Random.Range(0,18)), 0, unitHeight), Quaternion.identity);
        summoning = false;
    }

    void SelectUnit()
    {
        for (int i = 0; i < InfantryCount; i++)
        {
            unitList.Add(EnemyTypes[0]);
        }
        for (int a = 0; a < ArcheryCount; a++)
        {
            unitList.Add(EnemyTypes[1]);
        }
        for (int c = 0; c < CavalryCount; c++)
        {
            unitList.Add(EnemyTypes[2]);
        }
        for (int f = 0; f < FarmerCount; f++)
        {
            unitList.Add(EnemyTypes[3]);
        }
        rnd = Random.Range(0, unitList.Count);
        if (rnd < InfantryCount)
        {
            waitTime = 1.5f;
            unitHeight = 1;
        }
        else if (rnd >= InfantryCount && rnd < (InfantryCount + ArcheryCount))
        {
            waitTime = 2;
            unitHeight = 2;
        }
        else if (rnd >= (InfantryCount + ArcheryCount) && rnd < (InfantryCount + ArcheryCount + CavalryCount))
        {
            waitTime = 3;
            unitHeight = 1;
        }
        else
        {
            waitTime = 3;
            unitHeight = 3;
        }
    }
}
