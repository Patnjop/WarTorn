using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    TowerManager towerManager;
    public string enemyColour;
    public Vector3 currentPos, target;
    public float dist, ringWidth, ringHeight;
    public bool selected, ringSpawned;
    public GameObject selectRing;
    GameObject ring;
    UnitCount unitCount;

    public enum BehaviourState
    {
        Offense,
        Defense,
        Protect,
    }

    public BehaviourState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = BehaviourState.Offense;
        towerManager = GameObject.Find("TowerManager").GetComponent<TowerManager>();
        target = GameObject.Find("Red Tower").transform.position;
        unitCount = GameObject.Find("MapManager").GetComponent<UnitCount>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = this.transform.position;
        if (selected == true && ringSpawned == false)
        {
            if (ring == null)
            {
                ring = Instantiate(selectRing, new Vector3(currentPos.x, 0.005f, currentPos.z), Quaternion.identity);
                ring.transform.localScale = new Vector3(ringWidth, ringWidth, ringHeight);
                ring.transform.SetParent(this.transform);
            }
            ring.SetActive(true);
            ringSpawned = true;
            if (!unitCount.selectedUnits.Contains(this.gameObject))
            {
                unitCount.selectedUnits.Add(this.gameObject);
            }
        }
        else if (selected == false && ringSpawned == true)
        {
            ring.SetActive(false);
            ringSpawned = false;
            if (unitCount.selectedUnits.Contains(this.gameObject))
            {
                unitCount.selectedUnits.Remove(this.gameObject);
            }
        }

        if (currentState == BehaviourState.Offense)
        {
            transform.position = Vector3.MoveTowards(currentPos, target, 0.5f * Time.deltaTime);
        }
    }
}
