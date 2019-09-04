using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempHatCollision : MonoBehaviour
{

    [SerializeField] hatThrow throwHat;
    [SerializeField] HatHolder holder;
    [SerializeField] HatHolder holder2;
    [SerializeField] HatHolder holder3;
    [SerializeField] HatHolder holder4;

    SpriteRenderer m_SpriteRenderer;

    private void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    private void Awake()
    {
        throwHat = FindObjectOfType<hatThrow>();
    }

    private void OnTriggerEnter2D(Collider2D collision){

            if (collision.tag == "Player1"){
                Debug.Log("Hats");
                throwHat.addHats(1);
            m_SpriteRenderer.color = Color.red;

            }
            if (collision.tag == "Player2"){
                Debug.Log("Hats P2");
                throwHat.addHats(2);
            m_SpriteRenderer.color = Color.blue;
        }
            if (collision.tag == "Player3"){
            Debug.Log("Hats P3");
            throwHat.addHats(3);
            m_SpriteRenderer.color = Color.yellow;
        }
            if (collision.tag == "Player4"){
            Debug.Log("Hats P4");
            throwHat.addHats(4);
            m_SpriteRenderer.color = Color.green;
        }
            if (collision.tag == "floor") {
                Destroy(gameObject);
            }
        if (collision.tag == "equippedHats" && this.tag == "p1Hat")
        {
            holder.removeHatWhenHit();
        }
        if (collision.tag == "equippedHats" && this.tag == "p2Hat")
        {
            holder2.removeHatWhenHit();
        }
        if (collision.tag == "equippedHats" && this.tag == "p3Hat")
        {
            holder3.removeHatWhenHit();
        }
        if (collision.tag == "equippedHats" && this.tag == "p4Hat")
        {
            holder4.removeHatWhenHit();
        }
    }
}
