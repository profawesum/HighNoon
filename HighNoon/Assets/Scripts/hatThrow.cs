using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatThrow : MonoBehaviour
{
    public GameObject hatToThrow;
    public Transform firePointP1;
    public Transform firePointP2;
    public Transform firePointP3;
    public Transform firePointP4;

    public int P1Hats;
    public int P2Hats;
    public int P3Hats;
    public int P4Hats;

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
        Debug.Log("Tried to throw a hat");
        Instantiate(hatToThrow, firePoint.position, firePoint.rotation);
    }

}
