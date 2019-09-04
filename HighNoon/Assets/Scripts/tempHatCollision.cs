using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempHatCollision : MonoBehaviour
{

    [SerializeField] hatThrow throwHat;

    private void OnTriggerEnter2D(Collider2D collision){

            if (collision.tag == "Player1"){
                Debug.Log("Hats");
                throwHat.addHats(1);

            }
            if (collision.tag == "Player2"){
                Debug.Log("Hats P2");
                throwHat.addHats(2);
        }
            if (collision.tag == "Player3"){
                throwHat.addHats(3);
        }
            if (collision.tag == "Player4"){
                throwHat.addHats(4);
        }
            if (collision.tag == "floor") {
                Destroy(gameObject);
            }
    }
}
