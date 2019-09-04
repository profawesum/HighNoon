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
    List<GameObject> HatList;

    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
            }
        }
    }
}
