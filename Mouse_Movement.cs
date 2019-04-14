using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Movement : MonoBehaviour
{
    public GameObject[] SF = new GameObject[2];
    public GameObject InvObj;
    public GameObject Block, CurrentSelectedBlock;
    int CurrentPlacedAmmount;
    bool CanPlace = true;
    public GameObject player;
    bool indist;
    public float dist;
    bool CanPlace2 = true;
    private Inventory Inv;

    // Start is called before the first frame update
    void Start()
    {
        Inv = InvObj.GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player")
        {
            CurrentSelectedBlock = collision.gameObject;
        }
        else
        {
            CanPlace2 = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CurrentSelectedBlock = null;
        if (collision.transform.tag != "Player")
        {
            CanPlace2 = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentSelectedBlock != null)
        {
            if (Vector2.Distance(transform.position, CurrentSelectedBlock.transform.position) > 1)
            {
                CurrentSelectedBlock = null;
            }
        }

        Block = Inv.GetComponent<Inventory>().curblock;


        if (Vector2.Distance(transform.position, player.transform.position) < dist)
        {
            indist = true;
        }
        else
        {
            indist = false;
        }

        if (Input.GetMouseButton(0) && CurrentSelectedBlock != null && indist && CurrentSelectedBlock != player)
        {
            SF[1].GetComponent<AudioSource>().Play();

            if (CurrentSelectedBlock.transform.tag == "Grass")
            {
                Inv.Counts[0] += 1;
            }

            else if(CurrentSelectedBlock.transform.tag == "Dirt")
            {
                Inv.Counts[1] += 1;
            }

            else if (CurrentSelectedBlock.transform.tag == "Stone")
            {
                Inv.Counts[2] += 1;
            }
            
            else if (CurrentSelectedBlock.transform.tag == "Sand")
            {
                Inv.Counts[3] += 1;
            }

            Destroy(CurrentSelectedBlock);
        }

        if (Input.GetMouseButton(1) && CurrentSelectedBlock == null && CanPlace && indist && CanPlace2 && Inv.Counts[Inv.selected] > 0)
        {
            SF[0].GetComponent<AudioSource>().Play();
            GameObject newBlock = Instantiate(Block, new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0), Quaternion.identity);
            newBlock.transform.name = CurrentPlacedAmmount.ToString();
            newBlock.GetComponent<BlockSpawn>().hasSpawned = true;
            CurrentPlacedAmmount++;
            Inv.Counts[Inv.selected] -= 1;
            StartCoroutine("WaitforPlacement");
        }

        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        transform.position = pz;
        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(pz.y - transform.transform.position.y, pz.x - transform.transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

        transform.position = new Vector3(Mathf.RoundToInt(pz.x), Mathf.RoundToInt(pz.y), 0);

        Cursor.visible = false;
        
    }

    IEnumerator WaitforPlacement()
    {
        CanPlace = false;
        yield return new WaitForSeconds(0.1f);
        CanPlace = true;
    }
}
