using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatVelocity : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 20f;
    public float timer = 0;
    public bool pickup;
    public bool start;

    // Makes the hat move when it is instantiated
    void Start(){
            rb.velocity = transform.right * speed;
    }
}
