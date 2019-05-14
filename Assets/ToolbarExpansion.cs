using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolbarExpansion : MonoBehaviour
{
    public Button unitToolbarButton;
    public GameObject[] unitTypes;
    public Image Background;
    RectTransform unitToolbar;
    public Text unitArrow, unitArrow2;
    public bool expand, chosen = false;
    public int maxWidth, unitSelected, unitSpeed;
    Vector2 startWidth;
    RectTransform unitButtonTransform;
    public UnitPlacement unitPlacement;
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
            StartCoroutine("Appear");
            expand = true;
        }
        else if (expand == true)
        {
            unitArrow2.enabled = false;
            StartCoroutine("Disappear");
            expand = false;
        }
    }

    void Update()
    {
        if (unitSelected == 0)
        {
            unitSpeed = 0;
        }
        if (unitSelected >= 1)
        {
            unitSpeed = (unitSelected * 80);
        }


        if (expand == true && unitToolbar.sizeDelta.x <= maxWidth)
        {
            unitToolbar.position = unitToolbar.position + new Vector3(Time.deltaTime * 150f, 0, 0);
            unitToolbarButton.GetComponent<RectTransform>().position = unitToolbarButton.GetComponent<RectTransform>().position + new Vector3(Time.deltaTime * 300f, 0, 0);
            unitToolbar.sizeDelta = unitToolbar.sizeDelta + new Vector2(Time.deltaTime * 300f, 0);
            for (int i = 0; i < unitTypes.Length; i++)
            {
                if (unitTypes[i].GetComponent<RectTransform>().position.x <= 35 + (i * 70))
                {
                    unitTypes[i].GetComponent<RectTransform>().position = unitTypes[i].GetComponent<RectTransform>().position + new Vector3(Time.deltaTime * i * 148, 0, 0);
                }
            }
        }
        if (expand == false && unitToolbar.sizeDelta.x > startWidth.x)
        {
            unitToolbar.position = unitToolbar.position - new Vector3(Time.deltaTime * 150f, 0, 0);
            unitToolbarButton.GetComponent<RectTransform>().position = unitToolbarButton.GetComponent<RectTransform>().position - new Vector3(Time.deltaTime * 300f, 0, 0);
            unitToolbar.sizeDelta = unitToolbar.sizeDelta - new Vector2(Time.deltaTime * 300f, 0);
            for (int g = 0; g < unitTypes.Length; g++)
            {
                if (unitTypes[g].GetComponent<RectTransform>().position.x > 35)
                {
                    unitTypes[g].GetComponent<RectTransform>().position = unitTypes[g].GetComponent<RectTransform>().position - new Vector3(Time.deltaTime * g * 148, 0, 0);
                }
            }
        }


        if (unitToolbar.sizeDelta.x >= maxWidth)
        {
            unitArrow2.enabled = true;
        }
        if (unitToolbar.sizeDelta.x <= startWidth.x)
        {
            unitArrow.enabled = true;
        }

        if (expand == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                unitSelected = 0;
                SwitchToolbar();
                unitPlacement.SetUnit(unitPlacement.units[unitSelected]);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                unitSelected = 1;
                unitPlacement.SetUnit(unitPlacement.units[unitSelected]);
                SwitchToolbar();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                unitSelected = 2;
                SwitchToolbar();
            }
        }
    }
    IEnumerator Appear()
    {
        for (int a = 0; a < unitTypes.Length; a++)
        {
            yield return new WaitForSeconds(0.1f * a);
            unitTypes[a].GetComponent<Image>().enabled = true;
            unitTypes[a].GetComponent<Button>().enabled = true;
        }
    }
    IEnumerator Disappear()
    {
        for (int a = 2; a > -1; a--)
        {
            if (a != unitSelected)
            {
                yield return new WaitForSeconds(0.1f * a);
                unitTypes[a].GetComponent<Image>().enabled = false;
                unitTypes[a].GetComponent<Button>().enabled = false;
            }
        }
    }
}
