using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightDay : MonoBehaviour
{
    public float timeval;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeval < 0.5f)
        {
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (timeval > 0.5f)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
        }
        timeval = Mathf.PingPong(Time.time/100, 0.75f);
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Vector4(0,0,0, timeval);
    }
}
