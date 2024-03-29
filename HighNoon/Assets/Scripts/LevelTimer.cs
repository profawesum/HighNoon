﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{

    public float timer = 90;
    public Text timerText;


    public Transform player1;
    public Transform player2;
    public Transform target;


    public Camera cam;


    [SerializeField] HatHolder holderOfTheHats;
    [SerializeField] HatHolder holderOfTheHats2;


    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;
        timerText.text = "Time Remaining: " + timer.ToString("F2");

        if (timer <= 0) { 
            //timer = 0;
            //Time.timeScale = 0;
            if (holderOfTheHats.HatList.Count >= holderOfTheHats2.HatList.Count)
            {
                timerText.text = "Red Player Wins";
                target = player1;
            }
            else {
                timerText.text = "Blue Player Wins";
                target = player2;
             }
            cam.transform.position = (target.transform.position - new Vector3(0.0f, 0.0f, 2.0f));
            cam.orthographicSize = 5;

            if (timer <= -7) {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
