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
    public bool timeReset;
    public float maxTime;

    private void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        sj2D = gameObject.GetComponent<SpringJoint2D>();
        timeReset = true;
    }

    private void Update()
    {
        if (rb2D.gravityScale != -20)
        {
            if (playerEquipped != true)
            {
                timer += Time.deltaTime;
                if (timer <= maxTime)
                {
                    rb2D.AddForce(transform.right * hatSpeed);
                }
                else {
                    gameObject.tag = "Hats";
                    rb2D.gravityScale = 9.8f;
                    rb2D.velocity = new Vector2(0,0);
                }
            }
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player1" || collision.tag == "Player2" || collision.tag == "Player3" || collision.tag == "Player4")
        {
            playerEquipped = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = -20;
            gameObject.GetComponent<SpringJoint2D>().enabled = true;
        }
    }
}
