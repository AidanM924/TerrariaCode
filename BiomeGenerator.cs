using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeGenerator : MonoBehaviour
{
    public GameObject[] Blocks =  new GameObject[3];
    float currenty;
    float currenty1;
    public int currentx;
    public int currentx1;
    int biome;
    public int bedrockLevel;

    public GameObject Player;
    public int interval;
    int intervalchecker = 0;
    float newcurrenty;
    int count;
    bool MUSTSPAWN, cannaturallyspawn;
    public GameObject BedRock;

    // Start is called before the first frame update
    void Start()
    {
        biome = Random.Range(0, 3);
        //0 = grass
        //1 = dirt
        //2 = sand

        GameObject newInstanceBlock = Instantiate(Blocks[biome], transform.position, Quaternion.identity);
        newInstanceBlock.GetComponent<BlockSpawn>().bedRockLevel = bedrockLevel;
        Instantiate(BedRock, new Vector3(0, bedrockLevel, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (count < 20)
        {
            MUSTSPAWN = true;
            cannaturallyspawn = false;
        }

        else if (count >= 20)
        {
            MUSTSPAWN = false;
            cannaturallyspawn = true;
        }

        if (intervalchecker > interval)
        {
            biome = Random.Range(0, 3);
            intervalchecker = 0;
        }

        if (currenty1 <= bedrockLevel + 5)
        {
            currenty1 = bedrockLevel + 5;
        }

        if (currenty <= bedrockLevel + 5)
        {
            currenty = bedrockLevel + 5;
        }

        if (Mathf.Abs(Mathf.RoundToInt(Player.transform.position.x)) >= Mathf.Abs(currentx) - 20 && cannaturallyspawn || Mathf.Abs(Mathf.RoundToInt(Player.transform.position.x)) >= Mathf.Abs(currentx1) - 20 && cannaturallyspawn || MUSTSPAWN)
        {
            CreateBlock();
        }
    }

    void CreateBlock()
    { 
            newcurrenty += Random.Range(-2.4f, 2.4f);
            newcurrenty = Mathf.RoundToInt(newcurrenty);
            currenty1 += Random.Range(-2.4f, 2.4f);
            currenty1 = Mathf.RoundToInt(currenty1);
            currentx1 -= 1;
            currentx += 1;
            GameObject newRightBlock = Instantiate(Blocks[biome], new Vector3(transform.position.x + currentx, newcurrenty, 0), Quaternion.identity);
            newRightBlock.GetComponent<BlockSpawn>().bedRockLevel = bedrockLevel;
            GameObject newLeftBlock = Instantiate(Blocks[biome], new Vector3(transform.position.x + currentx1, currenty1, 0), Quaternion.identity);
            newLeftBlock.GetComponent<BlockSpawn>().bedRockLevel = bedrockLevel;
            count += 1;
            intervalchecker += 1;

        Instantiate(BedRock, new Vector3(transform.position.x + currentx, bedrockLevel, 0), Quaternion.identity);
        Instantiate(BedRock, new Vector3(transform.position.x + currentx1, bedrockLevel, 0), Quaternion.identity);
    }
}