using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menumove : MonoBehaviour
{

    public void playGame() {
        Application.LoadLevel(1);
    }

    public void Quit() { 
        Application.Quit();

    }




}
