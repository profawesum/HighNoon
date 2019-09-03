using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatThrow : MonoBehaviour
{


    [SerializeField] Hats hat;

    public GameObject hatToThrow;

    public Transform firePointP1;
    public Transform firePointP2;
    public Transform firePointP3;
    public Transform firePointP4;

    public float P1Hats;
    public float P2Hats;
    public float P3Hats;
    public float P4Hats;

    public void addHats(int player) {

        switch (player){
            case 1:
                Debug.Log("SwitchCase");
                P1Hats++;
                Debug.Log(P1Hats);
                break;
            case 2:
                P2Hats++;
                break;
            case 3:
                P3Hats++;
                break;
            case 4:
                P4Hats++;
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        //checks to see which player has fired
        //p2
        if (Input.GetButtonDown("ArrowThrowHat")) {
            if (P2Hats >= 1)
            {
                throwHat(firePointP2);
                P2Hats -= 1;
            }
        }
        //p1
        if (Input.GetButtonDown("Fire1"))
        {
            if (P1Hats >= 1)
            {
                throwHat(firePointP1);
                P1Hats -= 1;
            }
        }
    }

    //fires a hat
    public void throwHat(Transform firePoint) {
        hat.rb2D.gravityScale = 1;
        hat.sj2D.enabled = false;
        hat.playerEquipped = false;
        Instantiate(hatToThrow, firePoint.position, firePoint.rotation);
    }

}
