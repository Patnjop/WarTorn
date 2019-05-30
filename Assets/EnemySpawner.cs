using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyTypes;
    public List<GameObject> unitstoPick = new List<GameObject>();

    public int infantryCount, archeryCount, farmerCount, cavalryCount;
    public int EnemyMana, maxMana, EnemyWaitTime;
    int rnd, temp;
    bool manatoAdd = true;
    public bool unitSummoning, unitPicked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manatoAdd == true)
        {
            StartCoroutine("ManaRegen");
            manatoAdd = false;
        }
        if (unitSummoning == false)
        {
            PickUnit();
            unitPicked = false;
            unitSummoning = true;
        }
    }

    IEnumerator ManaRegen()
    {
        if (EnemyMana < maxMana)
        {
            yield return new WaitForSeconds(EnemyWaitTime);
            EnemyMana++;
        }
        manatoAdd = true;
    }

    void PickUnit()
    {
        unitstoPick = new List<GameObject>();
        for (int i = 0; i < infantryCount; i++)
        {
            unitstoPick.Add(EnemyTypes[0]);
        }
        for (int i = 0; i < archeryCount; i++)
        {
            unitstoPick.Add(EnemyTypes[1]);
        }
        for (int i = 0; i < cavalryCount; i++)
        {
            unitstoPick.Add(EnemyTypes[2]);
        }
        for (int i = 0; i < farmerCount; i++)
        {
            unitstoPick.Add(EnemyTypes[3]);
        }
        rnd = Random.Range(0, unitstoPick.Count);
        Debug.Log(rnd);
        if (rnd < (infantryCount + archeryCount) && unitPicked == false)
        {
            Instantiate(unitstoPick[rnd], new Vector3(0, 0, 0), Quaternion.identity);
            unitPicked = true;
            unitSummoning = false;
        }
        else if (rnd >= (infantryCount + archeryCount) && unitPicked == false)
        {
            Instantiate(unitstoPick[rnd], new Vector3(0, 0, 0), Quaternion.identity);
            unitPicked = true;
            unitSummoning = false;
        }
    }
}
