using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerControl player;
    private string horizontalAxis;
    private string aButton;
    private string bButton;

    public float Horizontal { get; set; }

    public int controllerNumber;

    public enum Button
    {
        A,
        B,
    }

    private void Awake()
    {
        player = GetComponent<PlayerControl>();
    }
    internal bool ButtonIsDown(Button button)
    {
        switch (button)
        {
            case Button.A:
                return Input.GetButton(aButton);
            case Button.B:
                return Input.GetButton(bButton);
        }
        return false;
    }
    internal void SetControllerInput(int number)
    {
        controllerNumber = number;
        horizontalAxis = "J" + controllerNumber + "Horizontal";
        aButton = "J" + controllerNumber + "A";
        bButton = "J" + controllerNumber + "B";
        Debug.Log("My Controller Number is: " + controllerNumber);
    }

    private void FixedUpdate()
    {
        if(controllerNumber > 0)
        {
            Horizontal = Input.GetAxis(horizontalAxis);
        }
    }
}
