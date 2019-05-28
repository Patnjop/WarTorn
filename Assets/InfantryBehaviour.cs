using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    TowerManager towerManager;
    public string enemyColour;
    public Vector3 currentPos, target;
    public float dist, ringWidth;
    public bool selected, ringSpawned;
    public GameObject selectRing;
    GameObject ring;

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
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = this.transform.position;
        if (selected == true && ringSpawned == false)
        {
            ring = Instantiate(selectRing, new Vector3(currentPos.x, 0.005f, currentPos.z), Quaternion.identity);
            ring.transform.localScale = new Vector3(ringWidth, ringWidth, ringWidth);
            ring.transform.SetParent(this.transform);
            ringSpawned = true;
        }
    }
}
