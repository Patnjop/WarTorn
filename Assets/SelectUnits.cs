using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnits : MonoBehaviour
{
    
    public RectTransform SelectBox;
    
    Vector3 initialPos;
    Vector3 endPos;
    // Start is called before the first frame update
    void Start()
    {
        SelectBox.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                initialPos = hit.point; 
            }
        }
            
        if (Input.GetMouseButton(0))
        {
            if (!SelectBox.gameObject.activeInHierarchy)
            {
                SelectBox.gameObject.SetActive(true);
            }

            endPos = Input.mousePosition;

            Vector3 squareStart = Camera.main.WorldToScreenPoint(initialPos);
            squareStart.z = 0f;

            Vector3 centre = (squareStart + endPos) / 2f;

            SelectBox.position = centre;

            float sizeX = Mathf.Abs(endPos.x - squareStart.x);
            float sizeY = Mathf.Abs(endPos.y - squareStart.y );

            SelectBox.sizeDelta = new Vector2(sizeX, sizeY);
        }

        if (Input.GetMouseButtonUp(0))
        {
            SelectBox.gameObject.SetActive(false);
        }
    }
}
