using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatThrow : MonoBehaviour
{


    [SerializeField] Hats hat;
    [SerializeField] HatHolder holderOfTheHats;
    [SerializeField] HatHolder holderOfTheHats2;

    public Animator animate;
    public Animator animateP1;

    public GameObject hatToThrow;
    private PlayerControl player;
    //private PlayerInput Input;
    private int PlayerNumber;

    public Transform firePointP1;
    public Transform firePointP2;
    public Transform firePointP3;
    public Transform firePointP4;

    public float P1Hats;
    public float P2Hats;
    public float P3Hats;
    public float P4Hats;

    public float attackTimer;

    public void addHats(int player) {
        switch (player){
            case 1:
                {
                    P1Hats += 1;
                    break;
                }
            case 2:
                {
                    P2Hats += 1;
                    break;
                }
            case 3:
                {
                    P3Hats += 1;
                    break;
                }
            case 4:
                {
                    P4Hats += 1;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    private void Update()
    {
        //checks to see which player has fired
        //p2
        if (Input.GetButtonDown("ArrowThrowHat")) {
            if (P2Hats >= 1)
            {
                animate.SetBool("isAttacking", true);
                hat.timer = 0;
                holderOfTheHats2.removeHatWhenThrown();
                throwHat(firePointP2);
                P2Hats -= 1;
                attackTimer = 0;
            }
        }
        attackTimer+= Time.deltaTime;

        if (attackTimer >= 0.25f) {
            attackTimer = 0;
            animate.SetBool("isAttacking", false);
        }
        if (Input.GetAxis("ArrowHorizontal") != 0)
        {
            animate.SetBool("run", true);
        }
        else {
            animate.SetBool("run", false);
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            animateP1.SetBool("run", true);
        }
        else
        {
            animateP1.SetBool("run", false);
        }

        //p1
        if (Input.GetButtonDown("Fire1"))
        {
            if (P1Hats >= 1)
            {
                hat.timer = 0;
                holderOfTheHats.removeHatWhenThrown();
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

        if (firePoint == firePointP1)
        {
            hatToThrow.tag = "p1Hat";
        }
        else {
            hatToThrow.tag = "p2Hat";
        }
        Instantiate(hatToThrow, firePoint.position, firePoint.rotation);
    }

    public void SetPlayer(PlayerControl player)
    {
        this.player = player;
        PlayerNumber = player.PlayerNumber;
        //Input = player.GetComponent<PlayerInput>();

        // If a text or indicator was wanted Place it in children
        //if(GetComponentInChildren<player>)
    }

}
