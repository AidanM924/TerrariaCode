using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTextMovement : MonoBehaviour
{
    public GameObject Enable_Objects;
    public float speed;
    bool can = true;
    bool canjump = true, abletojump;
    public float jumpforce;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        abletojump = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position.x < 0)
        {
            can = false;
            Enable_Objects.SetActive(true);
            Enable_Objects.transform.GetChild(0).gameObject.SetActive(true);

        }

        if (can)
        {
            transform.Translate(Vector2.left * speed);
            if (canjump && abletojump)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpforce);
                StartCoroutine("Jump");
            }
        }

    }
    IEnumerator Jump()
    {
        canjump = false;
        abletojump = false;
        yield return new WaitForSeconds(0.5f);
        canjump = true;
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
