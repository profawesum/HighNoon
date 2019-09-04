using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerToControllerAssigner : MonoBehaviour
{
    private List<PlayerControl> PlayerControls = new List<PlayerControl>();
    private List<int> assignedControllers = new List<int>();
    [SerializeField] private PlayerPanel[] playerPanels;

    [SerializeField] private float maxTime = 15.0f;
    private float timer;
    private bool isStart = false;
    private bool isCount = false;

    private void Awake()
    {
        playerPanels = FindObjectsOfType<PlayerPanel>().OrderBy(t => t.PlayerNumber).ToArray();
    }
    void Start()
    {
        timer = maxTime;
    }

    void Update()
    {
        
        for (int i = 1; i <= 6; i++)
        {
            //if(Input.GetButton("J" + i + "Y"))
            //{
            //    //Back
            //}
            if (assignedControllers.Contains(i))
            {
            }
            else if (Input.GetButtonDown("J" + i + "A") && !isStart)
            {
                Debug.LogWarning("Assigned: " + i);
                AddPlayerController(i);
                break;
            }
        }
        if(isStart)
        {
            return;
        }
        isCount = checkAssigned();
        if(timer > 0.0f && isCount)
        {
            timer -= Time.deltaTime;
            //Text would be set here
        }
        else if(timer > 0.0f && !isCount)
        {
            timer = maxTime;
        }
        else if(timer <= 0.0f && isCount && !isStart)
        {
            foreach(PlayerPanel playerPanel in playerPanels)
            {
                if (playerPanel.HasControllerAssigned == true)
                {
                    playerPanel.GameStart();
                }
                else if (playerPanel.HasControllerAssigned == false)
                {
                    playerPanel.ClearImage();
                }
            }
            isCount = false;
            isStart = true;
        }
        return;
    }
    public PlayerControl AddPlayerController(int controller)
    {
        assignedControllers.Add(controller);
        for (int i = 0; i < playerPanels.Length; i++)
        {
            if (playerPanels[i].HasControllerAssigned == false)
            {
                return playerPanels[i].AssignController(controller);
            }
        }
        return null;
    }
    private bool checkAssigned()
    {
        int PlayerCount = 0;
        for(int i = 0; i < playerPanels.Length; i++)
        {
            if (playerPanels[i].HasControllerAssigned == true)
            {
                PlayerCount++;
            }
            if(PlayerCount > 1)
            {
                return true;
            }
        }
        return false;
    }
}
