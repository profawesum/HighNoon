using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{

    public float timer = 120;
    public Text timerText;

    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;
        timerText.text = "Time Remaining: " + timer.ToString("F2");

        if (timer <= 0) { 
            timer = 0;
            //load the win screen
            Application.LoadLevel(2);
        }
    }
}
