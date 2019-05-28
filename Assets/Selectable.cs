using UnityEngine;

public class Selectable : MonoBehaviour
{

    internal bool isSelected
    {
        get
        {
            return _isSelected;
        }
        set
        {
            _isSelected = value;
            //Replace this with your custom code. What do you want to happen to a Selectable when it get's (de)selected?
            Renderer r = GetComponentInChildren<Renderer>();
            if (r != null)
                r.GetComponent<UnitBehaviour>().selected = value ? true : false;
        }
    }

    private bool _isSelected;

    void OnEnable()
    {
        RTSSelection.selectables.Add(this);
    }

    void OnDisable()
    {
        RTSSelection.selectables.Remove(this);
    }

}