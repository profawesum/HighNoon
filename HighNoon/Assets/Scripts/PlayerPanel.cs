using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField] private hatThrow hatThrow;
    [SerializeField] PlayerControl player;
    public int PlayerNumber;
    public bool HasControllerAssigned = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerNumber = player.PlayerNumber;

        // image start
    }
    public bool isReady()
    {
        if (!HasControllerAssigned)
            return false;

        return true;
    }

    public PlayerControl AssignController(int controller)
    {
        player.Input.SetControllerInput(controller);
        //Change image here
        switch (controller)
        {
            case 1:
                {
                    break;
                }

            case 2:
                {
                    break;
                }
        }
        HasControllerAssigned = true;
        return player;
    }

    public void GameStart()
    {
        player.GameStart();
    }

    public void ClearImage()
    {
        //clear image stuff
        //deactivate
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
