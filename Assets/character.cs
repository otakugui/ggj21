using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public bool onGround;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        if(collision.collider.tag == "Ground")
        {
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = false;
        }
    }
}
