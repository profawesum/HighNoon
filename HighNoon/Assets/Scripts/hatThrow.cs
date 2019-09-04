using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatThrow : MonoBehaviour
{
    [SerializeField] Hats hat;
    [SerializeField] HatHolder holderOfTheHats;
    [SerializeField] HatHolder holderOfTheHats2;
    [SerializeField] HatHolder holderOfTheHats3;
    [SerializeField] HatHolder holderOfTheHats4;

    public GameObject hatToThrow;
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

    //fires a hat
    public void throwHat(Transform firePoint) {
        hat.rb2D.gravityScale = 1;
        hat.sj2D.enabled = false;
        hat.playerEquipped = false;

        if (firePoint == firePointP1)
        {
            hatToThrow.tag = "p1Hat";
        }
        else if (firePoint == firePointP2)
        {
            hatToThrow.tag = "p2Hat";
        }
        else if (firePoint == firePointP3)
        {
            hatToThrow.tag = "p3Hat";
        }
        else
        {
            hatToThrow.tag = "p4Hat";
        }
        Instantiate(hatToThrow, firePoint.position, firePoint.rotation);
    }

    public void SetPlayer(GameObject player, int PlayerController)
    {
        switch (PlayerController)
        {
            case 1:
            {
                firePointP1 = player.GetComponent<UnityStandardAssets._2D.Player2UserControls>().FirePoint;
                    holderOfTheHats = player.GetComponent<HatHolder>();
                break;
            }
            case 2:
            {
                    firePointP2 = player.GetComponent<UnityStandardAssets._2D.Player2UserControls>().FirePoint;
                    holderOfTheHats2 = player.GetComponent<HatHolder>();
                    break;
            }
            case 3:
            {
                    firePointP3 = player.GetComponent<UnityStandardAssets._2D.Player2UserControls>().FirePoint;
                    holderOfTheHats3 = player.GetComponent<HatHolder>();
                    break;
            }
            case 4:
            {
                    firePointP4 = player.GetComponent<UnityStandardAssets._2D.Player2UserControls>().FirePoint;
                    holderOfTheHats4 = player.GetComponent<HatHolder>();
                    break;
            }
        
        }
        //Input = player.GetComponent<PlayerInput>();

        // If a text or indicator was wanted Place it in children
        //if(GetComponentInChildren<player>)
    }
    public bool UpdateHatThrow(int Player)
    {
        switch (Player)
        {
            case 1:
                {
                    if (P1Hats >= 1)
                    {
                        hat.timer = 0;
                        holderOfTheHats.removeHatWhenThrown();
                        throwHat(firePointP1);
                        P1Hats -= 1;
                        return true;
                    }
                    break;
                }

            case 2:
                {
                    if (P2Hats >= 1)
                    {
                        //hat.timer = 0;
                        holderOfTheHats2.removeHatWhenThrown();
                        throwHat(firePointP2);
                        P2Hats -= 1;
                        return true;
                    }
                    break;
                }
            case 3:
                {
                    if (P3Hats >= 1)
                    {
                        hat.timer = 0;
                        holderOfTheHats3.removeHatWhenThrown();
                        throwHat(firePointP3);
                        P3Hats -= 1;
                        return true;
                    }
                    break;
                }
            case 4:
                {
                    if (P4Hats >= 1)
                    {
                        hat.timer = 0;
                        holderOfTheHats4.removeHatWhenThrown();
                        throwHat(firePointP4);
                        P4Hats -= 1;
                        return true;
                    }
                    break;
                }
        }
        return false;
    }

}
