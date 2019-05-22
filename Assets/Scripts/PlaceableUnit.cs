using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableUnit : MonoBehaviour
{
    public List<Collider> colliders = new List<Collider>();
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MapUnit")
        {
            colliders.Add(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MapUnit")
        {
            colliders.Remove(other);
        }
    }
}
