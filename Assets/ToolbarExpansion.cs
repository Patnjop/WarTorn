using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolbarExpansion : MonoBehaviour
{
    public Button unitToolbarButton;
    public Image Background;
    RectTransform unitToolbar;
    public Text unitArrow, unitArrow2;
    public bool expand = false;
    public int maxWidth;
    Vector2 startWidth;
    RectTransform unitButtonTransform;
    // Start is called before the first frame update
    void Start()
    {
        unitToolbarButton.onClick.AddListener(SwitchToolbar);
        unitToolbar = Background.GetComponent<RectTransform>();
        startWidth = unitToolbar.sizeDelta;
        unitArrow2.enabled = false;
    }

    void SwitchToolbar()
    {
        if (expand == false)
        {   
            unitArrow.enabled = false;
            expand = true;
        }
        else if (expand == true)
        {
            unitArrow2.enabled = false;
            expand = false;
        }
    }

    void Update()
    {
        if (expand == true && unitToolbar.sizeDelta.x <= maxWidth)
        {
            unitToolbar.position = unitToolbar.position + new Vector3(Time.deltaTime * 150f, 0, 0);
            unitToolbarButton.GetComponent<RectTransform>().position = unitToolbarButton.GetComponent<RectTransform>().position + new Vector3(Time.deltaTime * 300f, 0, 0);
            unitToolbar.sizeDelta = unitToolbar.sizeDelta + new Vector2(Time.deltaTime * 300f, 0);
        }
        if (expand == false && unitToolbar.sizeDelta.x > startWidth.x)
        {
            unitToolbar.position = unitToolbar.position - new Vector3(Time.deltaTime * 150f, 0, 0);
            unitToolbarButton.GetComponent<RectTransform>().position = unitToolbarButton.GetComponent<RectTransform>().position - new Vector3(Time.deltaTime * 300f, 0, 0);
            unitToolbar.sizeDelta = unitToolbar.sizeDelta - new Vector2(Time.deltaTime * 300f, 0);
        }
        if (unitToolbar.sizeDelta.x >= maxWidth)
        {
            unitArrow2.enabled = true;
        }
        if (unitToolbar.sizeDelta.x <= startWidth.x)
        {
            unitArrow.enabled = true;
        }
    }
}
