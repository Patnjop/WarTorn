using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextRound : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(SetNextRound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetNextRound()
    {

    }
}
