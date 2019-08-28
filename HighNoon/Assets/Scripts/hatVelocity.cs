using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatVelocity : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 20f;
    public float timer = 0;

    // Makes the hat move when it is instantiated
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        //destroys the hat once the timer has reached a set amount
        timer += 1 * Time.deltaTime;

        if (timer >= 2) {
            Destroy(gameObject);
        }
    }
}
