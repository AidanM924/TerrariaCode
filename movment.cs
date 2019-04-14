using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
    public GameObject[] SF = new GameObject[2];
    public int scaler;
    public int prevscaler;

    public float movement_Speed;
    public float Jump_Force;
    bool allowjump = true;
    bool canjump;
    float stepmanager;

    void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.transform.tag == "Grass" || Col.transform.tag == "Dirt" || Col.transform.tag == "Stone" || Col.transform.tag == "Sand" || Col.transform.tag == "Player")
        {
            canjump = true;
        }
    }

    void OnCollisionExit2D(Collision2D Col)
    {
        if (Col.transform.tag == "Grass" || Col.transform.tag == "Dirt" || Col.transform.tag == "Stone" || Col.transform.tag == "Sand" || Col.transform.tag == "Player")
        {
            canjump = false;
        }
    }

    void LateUpdate()
    {


        if (Input.GetKey(KeyCode.Space) && canjump && allowjump)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * Jump_Force);
            SF[0].GetComponent<AudioSource>().Play();
            StartCoroutine("waitforJump");
        }

        float x = Input.GetAxis("Horizontal");

            transform.Translate(Vector2.right * x * movement_Speed);

            GetComponent<Animator>().SetFloat("x", Mathf.Abs(x));

        stepmanager += Mathf.Abs(x);
        if (stepmanager >= 10)
        {
            SF[1].GetComponent<AudioSource>().Play();
            stepmanager = 0;
        }



        if (x < 0)
        {
            transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
        }

        if (x > 0)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }
    }

    IEnumerator waitforJump()
    {
        allowjump = false;
        yield return new WaitForSeconds(0.5f);
        allowjump = true;
    }
}