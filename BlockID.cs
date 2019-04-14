using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockID : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D Col)
    {
        int x = int.Parse(transform.name);
        int y = int.Parse(Col.transform.name);

        if (x > y)
        {
            Destroy(Col.gameObject);
        }
        else if (x == y)
        {
            Destroy(Col.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
