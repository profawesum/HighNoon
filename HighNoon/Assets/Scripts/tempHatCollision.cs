using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempHatCollision : MonoBehaviour
{

    [SerializeField] hatThrow throwHat;
    [SerializeField] hatVelocity velo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.tag == "Player1")
            {
                Debug.Log("Hats");
                throwHat.P1Hats ++;
                Destroy(gameObject);
            }
            if (collision.tag == "Player2")
            {
                Debug.Log("Hats P2");
                throwHat.P2Hats ++;
                Destroy(gameObject);
            }
            if (collision.tag == "Player3")
            {
                throwHat.P3Hats ++;
                Destroy(gameObject);
            }
            if (collision.tag == "Player4")
            {
                throwHat.P4Hats ++;
                Destroy(gameObject);
            }
    }
}
