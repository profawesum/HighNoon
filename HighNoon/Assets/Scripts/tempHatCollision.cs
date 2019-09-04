using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempHatCollision : MonoBehaviour
{

    [SerializeField] hatThrow throwHat;
    [SerializeField] HatHolder holder;
    [SerializeField] HatHolder holder2;

    public AudioClip pickupSound;
    public AudioSource source;

    SpriteRenderer m_SpriteRenderer;

    private void Start()
    {
        source.clip = pickupSound;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision){

            if (collision.tag == "Player1"){
                Debug.Log("Hats");
                throwHat.addHats(1);
            source.Play();
            m_SpriteRenderer.color = Color.red;

            }
            if (collision.tag == "Player2"){
                Debug.Log("Hats P2");
                throwHat.addHats(2);
            source.Play();
            m_SpriteRenderer.color = Color.blue;
        }
            if (collision.tag == "Player3"){
                throwHat.addHats(3);
            source.Play();
            m_SpriteRenderer.color = Color.yellow;
        }
            if (collision.tag == "Player4"){
                throwHat.addHats(4);
            source.Play();
            m_SpriteRenderer.color = Color.green;
        }
            if (collision.tag == "floor") {
                Destroy(gameObject);
            }
        if (collision.tag == "equippedHats" && this.tag == "p1Hat")
        {
            holder2.removeHatWhenHit();
        }
        if (collision.tag == "equippedHats" && this.tag == "p2Hat")
        {
            holder.removeHatWhenHit();
        }
    }
}
