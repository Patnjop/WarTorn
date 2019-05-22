using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public GameObject filledMana, EmptyMana, ManaBarEmpty, ManaBarFill;
    GameObject fillBar;
    public List<GameObject> filled = new List<GameObject>();
    public int maxMana;
    public bool manatoAdd, startFill;
    public int manaCount;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (manatoAdd == true)
        {
            StartCoroutine("AddMana");
            manatoAdd = false;
            startFill = true;
        }
        if (startFill == true && manaCount < maxMana)
        {
            if (fillBar.GetComponent<RectTransform>().sizeDelta.y < 240)
            {
                fillBar.GetComponent<RectTransform>().sizeDelta += new Vector2(0, Time.deltaTime * 240 / waitTime);
                fillBar.GetComponent<RectTransform>().position += new Vector3(0, Time.deltaTime * 120 / waitTime, 0);
            }
            else {
                fillBar.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 0);
                fillBar.GetComponent<RectTransform>().position = new Vector3(15, 830, 0);
            }
        }
    }

    public IEnumerator InitialMana()
    {
        GameObject bar = Instantiate(ManaBarEmpty, new Vector3(15, 950, 0), Quaternion.identity);
        bar.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        fillBar = Instantiate(ManaBarFill, new Vector3(15, 830, 0), Quaternion.identity);
        fillBar.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        for (int i = 0; i < maxMana; i++)
        {
            GameObject mana = Instantiate(EmptyMana, new Vector3(50, 1050 - (i * 50), 0), Quaternion.identity);
            mana.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
            yield return new WaitForSeconds(0.3f);
        }
        manatoAdd = true;
    }

    public IEnumerator AddMana()
    {
        if (manaCount < maxMana)
        {
            yield return new WaitForSeconds(waitTime);
            GameObject newMana = Instantiate(filledMana, new Vector3(50, 850 + ((manaCount) * 50), 0), Quaternion.identity);
            newMana.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
            filled.Add(newMana);
            manaCount++;
            manatoAdd = true;
        }
    }
    public void SubtractMana(int c)
    {
        Debug.Log("called");
        for (int i = 0; i < c; i++)
        {
            Destroy(filled[manaCount - 1]);
            filled.Remove(filled[manaCount - 1]);
            manaCount--;
        }
    }
}
