﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenReset : MonoBehaviour
{

    public void Reset()
    {
        Application.LoadLevel(1);
    }

    public void quitGame() {
        Application.Quit();
    }




}
