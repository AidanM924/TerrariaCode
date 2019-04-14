using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    public int bedRockLevel;
    public GameObject Child;
    public bool hasSpawned;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > bedRockLevel + 1 && !hasSpawned)
        {
            GameObject ChildObj = Instantiate(Child, new Vector3(transform.position.x, transform.position.y - 1, 0), Quaternion.identity);
            ChildObj.GetComponent<BlockSpawn>().bedRockLevel = bedRockLevel;
            hasSpawned = true;
        }
    }
}
