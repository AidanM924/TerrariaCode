using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextrenderSettings : MonoBehaviour
{
    string SortingLayerName = "Default";
        int SortingOrder = 4;
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().sortingLayerName = SortingLayerName;
        gameObject.GetComponent<MeshRenderer>().sortingOrder = SortingOrder;
    }
}
