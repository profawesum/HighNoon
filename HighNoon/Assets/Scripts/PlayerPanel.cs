using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField] PlayerControl player;
    public int PlayerNumber;
    public bool HasControllerAssigned = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerNumber = player.PlayerNumber;
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
        //Text turns green
        HasControllerAssigned = true;
        return player;
    }

    public void GameStart()
    {
        player.GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
