using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hats : MonoBehaviour
{

    public Rigidbody2D rb2D;
    public SpringJoint2D sj2D;

    public float hatSpeed;
    public float timer;
    public bool playerEquipped;

    private void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        sj2D = gameObject.GetComponent<SpringJoint2D>();
    }

    private void Update()
    {
        if (rb2D.gravityScale != -20)
        {
            if (playerEquipped != true)
            {
                timer += Time.deltaTime;
                if (timer <= 0.5f)
                {
                    gameObject.tag = "thrownHat";
                    rb2D.AddForce(transform.right * hatSpeed);
                    Debug.Log("Got to adding force");
                }
                else
                {
                    gameObject.tag = "Hats";
                    rb2D.gravityScale = 9.8f;
                    rb2D.AddForce(transform.right * -hatSpeed);
                    timer = 0;
                }
            }
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
                playerEquipped = true;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = -20;
                gameObject.GetComponent<SpringJoint2D>().enabled = true;
    }
}
