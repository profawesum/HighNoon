using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatSpawn : MonoBehaviour
{


    public GameObject hatToThrow;

    // Update is called once per frame
    void Update()
    {
        float value = Random.Range(-150f, 180f);
        Debug.Log(value);
        if (value >= 175f)
        {
            Instantiate(hatToThrow, transform.position, transform.rotation);
            hatToThrow.GetComponent<Rigidbody2D>().gravityScale = 12;
        }

    }
}
