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

    private void Update()
    {
        //checks to see which player has fired
        if (Input.GetButtonDown("ArrowThrowHat")) {
            throwHat(firePointP2);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            throwHat(firePointP1);
        }
    }

    //fires a hat
    public void throwHat(Transform firePoint) {
        Debug.Log("Tried to throw a hat");
        Instantiate(hatToThrow, firePoint.position, firePoint.rotation);
    }

}
