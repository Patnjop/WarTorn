using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject[] RedTowers;
    public GameObject[] BlueTowers;

    // Start is called before the first frame update
    void Start()
    {
        RedTowers = GameObject.FindGameObjectsWithTag("RedTower");
        BlueTowers = GameObject.FindGameObjectsWithTag("BlueTower");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
