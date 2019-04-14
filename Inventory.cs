using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject curblock;
    public GameObject Grass, Stone, Dirt, Sand;
    public int[] Counts; // 0 = grass, 1 = dirt, 2 = stone, 3 = sand;
    public int selected = 0;
    public int Currentselected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Counts.Length; i++)
        {
            if (Counts[i] > 64)
            {
                Counts[i] = 64;
            }
        }

        transform.GetChild(0).transform.GetChild(2).GetComponent<TextMesh>().text = "" + Counts[0];
        transform.GetChild(1).transform.GetChild(2).GetComponent<TextMesh>().text = "" + Counts[1];
        transform.GetChild(2).transform.GetChild(2).GetComponent<TextMesh>().text = "" + Counts[2];
        transform.GetChild(3).transform.GetChild(2).GetComponent<TextMesh>().text = "" + Counts[3];
        if (selected == 0)
        {
            transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
        }
        if (selected == 1)
        {
            transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
        }
        if (selected == 2)
        {
            transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
            transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
        }
        if (selected == 3)
        {
            transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
        }


        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            selected -= 1;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            selected += 1;
        }

        if (selected < 0)
        {
            selected = 3;
        }
        if (selected > 3)
        {
            selected = 0;
        }
        Currentselected = Mathf.RoundToInt(selected);

        if (Currentselected == 0)
        {
            curblock = Grass;
        }
        else if (Currentselected == 2)
        {
            curblock = Stone;
        }
        else if (Currentselected == 1)
        {
            curblock = Dirt;
        }
        else if (Currentselected == 3)
        {
            curblock = Sand;
        }
    }
}
