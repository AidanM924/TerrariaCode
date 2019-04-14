using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPos : MonoBehaviour
{
    public GameObject Pos;
    public Vector3 Addative;
    public Vector3 Subtractive;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, (Pos.transform.position - Subtractive) + Addative, 0.05f);


    }
}
