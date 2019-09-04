using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class HatHolder : MonoBehaviour
{

    [SerializeField]
    float frequencyFirst, distanceFirst, dampingRatioFirst, dragFirst, angularDragFirst , gravityfirst;

    [SerializeField]
    float frequencyLinks, distanceLinks, dampingRatioLinks, dragLinks, angularDragLinks, gravityLinks;

    [SerializeField]
    Vector2 anchorFirst, connectedAnchorFirst;

    [SerializeField]
    Vector2 anchorLinks, connectedAnchorLinks;

    [SerializeField]
    public List<GameObject> HatList;

    float speed  = 0.1f;
    float time;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (HatList.Contains(collision.gameObject) == false)
        {
            if (collision.CompareTag("Hats") && HatList.Count > 0)
            {
                int number = HatList.Count;
                collision.GetComponent<SpringJoint2D>().connectedBody = HatList[(number - 1)].GetComponent<Rigidbody2D>();
                collision.GetComponent<SpringJoint2D>().frequency = frequencyLinks;
                collision.GetComponent<SpringJoint2D>().distance = distanceLinks;
                collision.GetComponent<SpringJoint2D>().dampingRatio = dampingRatioLinks;
                collision.GetComponent<SpringJoint2D>().anchor = anchorLinks;
                collision.GetComponent<SpringJoint2D>().connectedAnchor = connectedAnchorLinks;
                collision.GetComponent<Rigidbody2D>().gravityScale = gravityLinks;
                collision.GetComponent<Rigidbody2D>().mass = 0.0001f;
                collision.GetComponent<Rigidbody2D>().drag = dragLinks;
                collision.GetComponent<Rigidbody2D>().angularDrag = angularDragLinks;
                HatList.Add(collision.gameObject);
                collision.gameObject.tag = "equippedHats";


            }
            else if (collision.CompareTag("Hats"))
            {
                collision.GetComponent<SpringJoint2D>().connectedBody = this.gameObject.GetComponent<Rigidbody2D>();
                collision.GetComponent<SpringJoint2D>().frequency = frequencyFirst;
                collision.GetComponent<SpringJoint2D>().distance = distanceFirst;
                collision.GetComponent<SpringJoint2D>().dampingRatio = dampingRatioFirst;
                collision.GetComponent<SpringJoint2D>().anchor = anchorFirst;
                collision.GetComponent<SpringJoint2D>().connectedAnchor = connectedAnchorFirst;
                collision.GetComponent<Rigidbody2D>().gravityScale = -gravityfirst;
                collision.GetComponent<Rigidbody2D>().mass = 0.0001f;
                collision.GetComponent<Rigidbody2D>().drag = dragFirst;
                collision.GetComponent<Rigidbody2D>().angularDrag = angularDragFirst;
                HatList.Add(collision.gameObject);
                collision.gameObject.tag = "equippedHats";
            }

            if (collision.tag == "Player1") {
                removeHatWhenHit();
            }
            if (collision.tag == "Player2") {
                removeHatWhenHit();
            }
        }
    }

    private void FixedUpdate()
    {
        if (time <= 1)
        {
            time += Time.deltaTime;
        }
    }

    public void removeHatWhenHit() {


        Debug.Log("got here");
            float directionX = Random.Range(-20f, 20f);
            float directionY = Random.Range(-12.5f, 8f);

            GameObject temp = HatList.Last();
            temp.GetComponent<SpringJoint2D>().connectedBody = null;
            temp.GetComponent<SpringJoint2D>().connectedAnchor = new Vector2(directionX, directionY);
            temp.GetComponent<Rigidbody2D>().AddForce(new Vector2(directionX, directionY).normalized * speed);
            temp.tag = "Hats";
            HatList.Remove(temp);
        
    }

    public void removeHatWhenThrown() {

        GameObject temp = HatList.Last();
        temp.GetComponent<SpringJoint2D>().connectedBody = null;
        HatList.Remove(temp);
        Destroy(temp);
    }
}
